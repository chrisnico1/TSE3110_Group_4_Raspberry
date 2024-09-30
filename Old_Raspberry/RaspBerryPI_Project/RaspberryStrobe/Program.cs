using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Device.Gpio;
using System.Threading;

namespace RaspberryStrobe
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Blinking LED. Press Ctrl+C to end.");
            //int pin = 18;
            //using var controller = new GpioController();
            //controller.OpenPin(pin, PinMode.Output);
            //bool ledOn = true;
            //while (true)
            //{
            //    controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
            //    Thread.Sleep(1000);
            //    ledOn = !ledOn;
            //}
            int buttonId = 1;
            int status = 0;

            Console.WriteLine("Starting program! :D");

            while (true)
            {
                try
                {
                    InsertToTable(buttonId, status);
                    if (status == 0)
                    {
                        status = 1;
                    }
                    else if (status == 1)
                    {
                        status = 0;
                    }

                    Console.WriteLine("Trying to write to server..");
                    Thread.Sleep(5000);
                }
                catch
                {
                    Console.WriteLine("WOMP WOMP");
                }
                
            }

        }

        static void InsertToTable(int buttonId, int status)
        {
            string sqlQuery = $@"
                UPDATE BUTTON
                SET ButtonStatus = {status}
                WHERE ButtonID = {buttonId}";
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
                Console.WriteLine("Button status changed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
