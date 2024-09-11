using System;
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
        static string buttonStatus = "-1";
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
            
            Console.WriteLine("Try host on eth0 or wlan0?");
            string hostChoice = Console.ReadLine();
            if (hostChoice == "eth0")
            {
                Console.WriteLine("Trying host ip 192.168.247.55 (should be eth0)");
                ipAddress = IPAddress.Parse("192.168.247.55");
            }
            else if (hostChoice == "wlan0")
            {
                Console.WriteLine("Trying host ip 192.168.11.3 (should be wlan0)");
                ipAddress = IPAddress.Parse("192.168.11.3");
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
            else if (data == "TOGGLE DIODE<EOF>")
            {
                //Console.WriteLine("Understood, toggle diode");
                _serialPort.Write("1");
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
            while (true)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    //Console.WriteLine(message);
                    string[] serialData = message.Split(';');
                    if (serialData.Length > 1)
                    {
                        temperature = serialData[0];
                        buttonStatus = serialData[1];
                    }
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
                Thread.Sleep(500);
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
    }
}
