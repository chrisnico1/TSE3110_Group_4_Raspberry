using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RaspberryServertest
{
    internal class Program
    {
        static SerialPort _serialPort;
        static string temperature = "0";
        static string lightStatus = "0";
        static string alarmLightStatus = "0";
        static string buttonStatus = "0";
        static int readInterval = 400;

        static bool buttonAlarmActive = false;
        static bool temperatureAlarmActive = false;
        static double temperatureLimit = 20;
        public static int Main(string[] args)
        {
            Console.WriteLine("Server: Hello!");
            Thread serverThread = new Thread(() => StartServer());
            Thread readThread = new Thread(() => Read());

            Console.Write("Use default settings for Arduino? Y/N:");
            string defaultSetting = Console.ReadLine();
            string port, baudrate;
            if (defaultSetting == "Y")
            {
                port = "/dev/ttyACM0";
                baudrate = "9600";
                Console.WriteLine("Using port: " + port + ", baudrate: " + baudrate);
            }
            else
            {
                Console.Write("Port:");
                port = Console.ReadLine();
                Console.Write("Baudrate:");
                baudrate = Console.ReadLine();
            }

            // create a SerialPort on port COM#
            _serialPort = new SerialPort(port, int.Parse(baudrate));

            // set the read/write timeouts
            _serialPort.ReadTimeout = 1500;
            _serialPort.WriteTimeout = 1500;
            _serialPort.Open();
            readThread.Start();
            //SerialCommand(); //manual testing with arduino
            StartServer();

            _serialPort.Close();
            return 0;
        }

        public static void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.247.55");
            IPEndPoint localEndPoint;
            
            Console.WriteLine("Try host on eth0 or wlan0? or custom IP (ip)?");
            string hostChoice = Console.ReadLine();
            if (hostChoice == "eth0")
            {
                Console.WriteLine("Trying host ip 192.168.97.55 (should be eth0)");
                ipAddress = IPAddress.Parse("192.168.97.55");
            }
            else if (hostChoice == "wlan0")
            {
                Console.WriteLine("Trying host ip 192.168.11.3 (should be wlan0)");
                ipAddress = IPAddress.Parse("192.168.11.3");
            }
            else if (hostChoice == "ip")
            {
                string ipCustom = Console.ReadLine();
                try
                {
                    ipAddress = IPAddress.Parse(ipCustom);
                }
                catch (Exception)
                {
                    Console.WriteLine("IP rejected, written wrong");
                }
            }
            else { Console.WriteLine("You dyslexic fuck...."); }

            try
            {
                //Socket Tcp protocol listening for 10 request at a time
                localEndPoint = new IPEndPoint(ipAddress, 11800);
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();

                    // Client data
                    string data = null;
                    byte[] bytes = null;

                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Command received : {0}", data);

                    // Reply
                    //byte[] msg = Encoding.ASCII.GetBytes("Sensor value 20");
                    byte[] msg = DataResponse(data.ToString());
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //Console.WriteLine("\n Press any key to continue...");
            //Console.ReadKey();
        }

        public static byte[] DataResponse(string data)
        {
            byte[] response = null;
            if (data == "GET BUTTON<EOF>")
            {
                //Console.WriteLine("Understood, get button status");
                response = Encoding.ASCII.GetBytes(buttonStatus);
            }
            else if (data == "GET TEMPERATURE<EOF>")
            {
                //Console.WriteLine("Understood, get temperature status");
                response = Encoding.ASCII.GetBytes(temperature);
            }
            else if (data == "GET LIGHT<EOF>")
            {
                //Console.WriteLine("Understood, get temperature status");
                response = Encoding.ASCII.GetBytes(lightStatus);
            }
            else if (data == "GET ALARMLIGHT<EOF>")
            {
                //Console.WriteLine("Understood, get temperature status");
                response = Encoding.ASCII.GetBytes(alarmLightStatus);
            }
            else if (data == "TOGGLE DIODE<EOF>")
            {
                //Console.WriteLine("Understood, toggle diode");
                _serialPort.Write("L");
                response = Encoding.ASCII.GetBytes("diode toggled");
            }
            else
            {
                Console.WriteLine("Command not understood");
                response = Encoding.ASCII.GetBytes("Default response");
            }

            return response;
        }

        public static void Read()
        {
            ClearSerialBuffer();
            int i = 0;
            int buttonPressedForIntervals = 0;
            while (true)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                    string[] serialData = message.Split(';');
                    if (serialData.Length > 1)
                    {
                        temperature = serialData[0];
                        lightStatus = serialData[1];
                        alarmLightStatus = serialData[2];
                        buttonStatus = serialData[3];
                    }

                    //Alarm if button pressed too long
                    if (Convert.ToUInt32(buttonStatus) == 1)
                    {
                        buttonPressedForIntervals++;
                    }
                    else if (Convert.ToUInt32(buttonStatus) == 0)
                    {
                        buttonPressedForIntervals = 0;
                        buttonAlarmActive = false;
                    }
                    if ((buttonPressedForIntervals > (1000/readInterval)*10) && !buttonAlarmActive)
                    {
                        Console.WriteLine("DOOR HELD OPEN FOR MORE THAN 10 SEC");
                        PostAlarmToSQL("BUTTON");
                        buttonAlarmActive = true;
                    }

                    //Alarm if temperature too high
                    if ((Convert.ToDouble(temperature) > temperatureLimit) && !temperatureAlarmActive)
                    {
                        Console.WriteLine("TEMPERATURE ABOVE 20");
                        PostAlarmToSQL("TMP");
                        temperatureAlarmActive = true;
                    }

                    //Clear serial buffer when too many lines accumulated (when raspberry reads slower than arduino)
                    if (i > 50)
                    {
                        ClearSerialBuffer();
                        i = 0;
                    }
                    i++;

                }
                catch (TimeoutException)
                {
                    //Console.WriteLine("Timeout..");
                }
                Thread.Sleep(readInterval);
            }
        }

        public static void ClearSerialBuffer()
        {
            while (_serialPort.BytesToRead > 0)
            {
                _serialPort.ReadByte();
            }
            //Console.WriteLine("Serial buffer cleared");
        }

        public static void SerialCommand()
        {
            while (true)
            {
                Console.Write("Serial Command (T/B/D):");
                string command = Console.ReadLine();
                if (command == "T")
                {
                    Console.WriteLine("Temperature: " + temperature);
                }
                else if (command == "B")
                {
                    Console.WriteLine("Button status: " + buttonStatus);
                }
                else if (command == "D")
                {
                    Console.WriteLine("Diode toggled");
                    _serialPort.Write("1");
                }
            }
        }

        static void PostAlarmToSQL(string alarmType)
        {
            //string sqlQuery = $@"
            //    UPDATE BUTTON
            //    SET ButtonStatus = {status}
            //    WHERE ButtonID = {buttonId}";
            string sqlQuery = $@"INSERT INTO ALARM VALUES ('NA','NA','2069-09-30','Yo mama')";
            if (alarmType == "TMP")
            {
                sqlQuery = $@"INSERT INTO ALARM VALUES (2,'HOT','2024-09-30','Temperature above limit')";
            }
            else if (alarmType == "BUTTON")
            {
                sqlQuery = $@"INSERT INTO ALARM VALUES (5,'OPEN','2024-09-30','Door held open too long')";
            }
            
            //CRUD operasjon Insert, brukes av btnInsert og btnGenerateWaterLevels
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                SqlConnection conFood = new SqlConnection(conn);
                SqlCommand sql = new SqlCommand(sqlQuery, conFood);
                conFood.Open();
                SqlDataReader dataReader = sql.ExecuteReader();
                string retrievedTableValue;
                while (dataReader.Read() == true)
                {
                    //retrievedTableValue = dataReader[0].ToString();
                }
                conFood.Close();
                Console.WriteLine("Alarm posted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
