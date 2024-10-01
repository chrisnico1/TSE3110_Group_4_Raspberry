using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RaspberryServerClientForm
{



    public partial class Form1 : Form
    {
        //Global variables.
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        //Constructor
        public Form1()
        {
            InitializeComponent();
        }



        ///Functions from GUI///



        //Acknowledge alarms in alarm table and show new alarm table in dgvAlarms. [NOT COMPLETE]
        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            string sqlQuery = $"SELECT * FROM BUTTON";
            ViewQueryResultInDataGridView(conn, sqlQuery, dgvAlarm);
        }

        //Clear alarms in alarm table and show new alarm table in the dgvAlarms. [NOT COMPLETE]
        private void btnClearAlarm_Click(object sender, EventArgs e)
        {

        }

        //Toggle light on green diode. [NOT COMPLETE]
        private void btnGreenDiode_Click(object sender, EventArgs e)
        {
            byte[] request = Encoding.ASCII.GetBytes("TOGGLE DIODE<EOF>");
            string response = StartClient(request);
            //txtMsg.Text = response;
            Thread.Sleep(500);
            string greenStatus = GetDiodeStatus();
            txtTemp.Text = greenStatus;

        }



        ///Self-made methods///



        //View a query in a data grid view.
        public void ViewQueryResultInDataGridView(string conString, string sqlQuery, DataGridView dgvTemporary)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlDataAdapter sda;
                DataTable dt;
                con.Open();
                sda = new SqlDataAdapter(sqlQuery, con);
                dt = new DataTable();
                sda.Fill(dt);
                dgvTemporary.DataSource = dt;
                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        //Method for some Quant stuff.
        public string StartClient(byte[] request)
        {
            string serverMsg = "error";
            byte[] bytes = new byte[1024];
            try
            {
                // Connect to a Remote server
                string serverIP = txtIP.Text;
                IPAddress ipAddress = IPAddress.Parse(serverIP);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11800);

                // Create a TCP/IP socket.
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    // Connect to Remote EndPoint
                    sender.Connect(remoteEP);
                    //Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes("I need temperatue value<EOF>");

                    // Send the data through the socket.
                    int bytesSent = sender.Send(request);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    serverMsg = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    //Console.WriteLine("SocketException : {0}", se.ToString());
                    MessageBox.Show("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    MessageBox.Show("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return serverMsg;
        }

        //Get diode status from RaspberryPI using socket communication.
        public string GetDiodeStatus()
        {
            byte[] request = Encoding.ASCII.GetBytes("GET LIGHT<EOF>");
            string response = StartClient(request);
            if (Convert.ToInt32(response) == 0)
            {
                btnGreenDiode.BackColor = Color.White;
            }
            else if (Convert.ToInt32(response) == 1)
            {
                btnGreenDiode.BackColor = Color.Green;
            }
            return response;
        }

        //Get door status from RaspberryPI using socket communication.
        public void GetDoorStatus()
        {
            byte[] request = Encoding.ASCII.GetBytes("GET BUTTON<EOF>");
            string response = StartClient(request);
            if (Convert.ToInt32(response) == 0)
            {
                txtDoorClosed.Visible = true;
                txtDoorOpen.Visible = false;
            }
            else if (Convert.ToInt32(response) == 1)
            {
                txtDoorClosed.Visible = false;
                txtDoorOpen.Visible = true;
            }
        }






        //Show temperature in the textbox. [NOT TESTED]
        public string ShowCurrentTemperature()
        {
            byte[] request = Encoding.ASCII.GetBytes("GET TEMPERATURE<EOF>");
            string response = StartClient(request) + "°C";
            return response;
        }

        //Timer for doing tasks on a time interval. [NOT TESTED]
        private void tmrSampleTime_Tick(object sender, EventArgs e)
        {
            string temperature = ShowCurrentTemperature();
            txtCurrentTemperature.Text = temperature;
            GetDoorStatus();
        }




        //TEMPORARY----------------------------------------------------------------
        //NOT TESTED
        private void btnTemp_Click(object sender, EventArgs e)
        {
            InsertRow("ALARM", "2", "1", DateTime.Now, "message");
            string sqlQuery = @"SELECT* FROM ALARM ORDER BY AlarmId ASC;";
            ViewQueryResultInDataGridView(conn, sqlQuery, dgvAlarm);
        }

        // Method to insert four values into a table, where the third value is DateTime (DateTime.Now from C#)
        public void InsertRow(string tableName, object value1, object value2, DateTime value3, object value4)
        {
            // SQL query with parameters
            string query = $"INSERT INTO {tableName} VALUES (@Value1, @Value2, @Value3, @Value4)";

            // Using block to ensure proper disposal of resources
            using (SqlConnection connection = new SqlConnection(conn))
            {
                // Create the SQL command with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the command
                command.Parameters.AddWithValue("@Value1", value1);
                command.Parameters.AddWithValue("@Value2", value2);
                command.Parameters.AddWithValue("@Value3", value3);  // Passing DateTime.Now here
                command.Parameters.AddWithValue("@Value4", value4);

                // Open the connection
                connection.Open();

                // Execute the query
                command.ExecuteNonQuery();
            }
        }

    }
}
