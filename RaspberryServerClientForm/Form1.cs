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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;

namespace RaspberryServerClientForm
{
    /// <summary>
    /// Timestamp from the database is using UTC time.
    /// </summary>


    public partial class Form1 : Form
    {
        //Global variables.
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        //Constructor
        public Form1()
        {
            InitializeComponent();

            // Event subscription to make the timer start when new IP is entered.
            txtIP.KeyPress += new KeyPressEventHandler(txtIP_KeyPress);
            tmrSampleTime.Tick += new EventHandler(tmrSampleTime_Tick);

            // ULTRA MIDLERTIDIG KODE
            txtTemp.Clear();
        }



        ///Functions from GUI///



        //Clear all alarms in alarm table. [COMPLETE]
        private void btnClearAllAlarms_Click(object sender, EventArgs e)
        {
            // Creating the query
            string sqlQuery = "DELETE FROM ALARM;";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                // Open the connection
                connection.Open();

                // Execute the query
                command.ExecuteNonQuery();

                // Close the connection
                connection.Close();
            }
        }

        //Toggle light on green diode. [MAYBE COMPLETE]
        private void btnGreenDiode_Click(object sender, EventArgs e)
        {
            byte[] request = Encoding.ASCII.GetBytes("TOGGLE DIODE<EOF>");
            string response = StartClient(request);
            //Thread.Sleep(500);
            string greenStatus = GetDiodeStatus();
            txtTemp.Text = greenStatus;
        }

        // Method to turn off the red alarm diode. [COMPLETE]
        public void TurnOffRedDiode()
        {
            byte[] request = Encoding.ASCII.GetBytes("ALARM OFF<EOF>");
            string response = StartClient(request);
        }

        // Method to turn on the red alarm diode. [COMPLETE]
        public void TurnOnRedDiode()
        {
            byte[] request = Encoding.ASCII.GetBytes("ALARM ON<EOF>");
            string response = StartClient(request);
        }

        // Method to check if there are any values in the ALARM table. [COMPLETE]
        private void CheckIfAnyValueInTable()
        {
            try
            {
                string sqlQuery = $@"SELECT * FROM ALARM";
                SqlConnection connection = new SqlConnection(conn);
                SqlCommand sql = new SqlCommand(sqlQuery, connection);

                // Open the connection
                connection.Open();

                // Executing the reader function
                SqlDataReader dataReader = sql.ExecuteReader();

                string retrievedTableValue = "";
                while (dataReader.Read() == true)
                {
                    retrievedTableValue = dataReader[0].ToString();
                }

                // Close the connection
                connection.Close();


                if (retrievedTableValue.Length > 0)
                {
                    TurnOnRedDiode();
                }
                else
                {
                    TurnOffRedDiode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                    // Send the data through the socket.
                    int bytesSent = sender.Send(request);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    serverMsg = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // MIDLERTIDIG KODE:
                    txtTemp.AppendText(serverMsg + "\r\n");

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

            // Show all alarms in ALARM table inside dgvAlarm. [COMPLETE]
            string sqlQuery = @"SELECT* FROM ALARM ORDER BY AlarmId ASC;";
            ViewQueryResultInDataGridView(conn, sqlQuery, dgvAlarm);

            // Check to turn on/off the red diode. [NOT TESTED]
            CheckIfAnyValueInTable();
        }




        //TEMPORARY----------------------------------------------------------------
        //NOT TESTED
        private void btnTemp_Click(object sender, EventArgs e)
        {
            InsertRow("ALARM", "2", "1", "message");
        }

        // Method to insert four values into a table, where the third value is DateTime (DateTime.Now from C#)
        public void InsertRow(string tableName, object value1, object value2, object value3)
        {
            // SQL query with parameters
            string query = $"INSERT INTO {tableName} (AlarmCat, AlarmCode, AlarmMessage) VALUES (@Value1, @Value2, @Value3)";

            // Using block to ensure proper disposal of resources
            using (SqlConnection connection = new SqlConnection(conn))
            {
                // Create the SQL command with the query and the connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the command
                command.Parameters.AddWithValue("@Value1", value1);
                command.Parameters.AddWithValue("@Value2", value2);
                command.Parameters.AddWithValue("@Value3", value3);

                // Open the connection
                connection.Open();

                // Execute the query
                command.ExecuteNonQuery();
            }
        }

        // Enables the timer when the 'ENTER' key is pressed inside the txtIP. [COMPLETE]
        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tmrSampleTime.Start();
                e.Handled = true; // Prevents the 'ding' sound
            }
        }

    }
}
