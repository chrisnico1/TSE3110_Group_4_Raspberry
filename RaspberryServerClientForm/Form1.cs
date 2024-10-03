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
using TextBox = System.Windows.Forms.TextBox;

namespace RaspberryServerClientForm
{
    /// <summary>
    /// Timestamp from the database is using UTC time, meaning they are -2 hours wrong from local time in the summer.
    /// </summary>


    public partial class Form1 : Form
    {
        // Global variables //

        //Connection string to database.
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        // Constructor //
        public Form1()
        {
            InitializeComponent();

            //Event subscription to make the timer start when a new IP is entered in txtIP.
            txtIP.KeyPress += new KeyPressEventHandler(txtIP_KeyPress);
            tmrSampleTime.Tick += new EventHandler(tmrSampleTime_Tick);
        }



        /// Functions from GUI ///



        //Enables the timer when the 'ENTER' key is pressed inside txtIP. [COMPLETE]
        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tmrSampleTime.Start();
                e.Handled = true; //Prevents the 'ding' sound
            }
        }

        //Clear all alarms in alarm table. [COMPLETE]
        private void btnClearAllAlarms_Click(object sender, EventArgs e)
        {
            //Creating the query
            string sqlQuery = "DELETE FROM ALARM;";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                //Open the connection.
                connection.Open();

                //Execute the query.
                command.ExecuteNonQuery();

                //Close the connection.
                connection.Close();
            }
        }

        //Toggle light on green diode and show on GUI. [COMPLETE]
        private void btnGreenDiode_Click(object sender, EventArgs e)
        {
            //Using a byte stream through socket communication on LAN network.
            byte[] request = Encoding.ASCII.GetBytes("TOGGLE DIODE<EOF>");
            string response = StartClient(request);
            string greenStatus = GetDiodeStatus();
            txtTemp.Text = greenStatus;
        }

        //Method to turn off the red alarm diode. [COMPLETE]
        public void TurnOffRedDiode()
        {
            //Using a byte stream through socket communication on LAN network.
            byte[] request = Encoding.ASCII.GetBytes("ALARM OFF<EOF>");
            string response = StartClient(request);
        }

        //Method to turn on the red alarm diode. [COMPLETE]
        public void TurnOnRedDiode()
        {
            //Using a byte stream through socket communication on LAN network.
            byte[] request = Encoding.ASCII.GetBytes("ALARM ON<EOF>");
            string response = StartClient(request);
        }

        // Method to check if there are any values in the ALARM table. [COMPLETE]
        private void CheckIfAnyValueInTable()
        {
            //Stores the last found data from the first column of the table inside a variable.
            try
            {
                //Creating the query.
                string sqlQuery = $@"SELECT * FROM ALARM";
                SqlConnection connection = new SqlConnection(conn);
                SqlCommand sql = new SqlCommand(sqlQuery, connection);

                //Open the connection.
                connection.Open();

                //Executing the reader function.
                SqlDataReader dataReader = sql.ExecuteReader();

                //Creating a variable to store the found data.
                string retrievedTableValue = "";

                //Cheching the first column for all rows.
                while (dataReader.Read() == true)
                {
                    retrievedTableValue = dataReader[0].ToString();
                }

                //Close the connection.
                connection.Close();

                //Toggles the red alarm diode if there are any or no alarms.
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



        /// Methods ///



        //Metthod to view a query in a data grid view. [COMPLETE]
        public void ViewQueryResultInDataGridView(string sqlQuery, DataGridView dgvTemporary)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conn);
                SqlDataAdapter sda;
                DataTable dt;
                connection.Open();
                sda = new SqlDataAdapter(sqlQuery, connection);
                dt = new DataTable();
                sda.Fill(dt);
                dgvTemporary.DataSource = dt;
                connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        //Method for handling data request over socket communication. [COMPLETE]
        public string StartClient(byte[] request)
        {
            //Default server message is "error".
            string serverMsg = "error";
            byte[] bytes = new byte[1024];
            try
            {
                //Connect to a remote server.
                string serverIP = txtIP.Text;
                IPAddress ipAddress = IPAddress.Parse(serverIP);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11800);

                //Create a TCP/IP socket.
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                //Connect the socket to the remote endpoint and catch any errors.
                try
                {
                    //Connect to remote endpoint.
                    sender.Connect(remoteEP);

                    //Send the data through the socket.
                    int bytesSent = sender.Send(request);

                    //Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    serverMsg = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // MIDLERTIDIG KODE:-----------------------------------------------------------------------------------------
                    txtTemp.AppendText(serverMsg + "\r\n");

                    //Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    MessageBox.Show("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return serverMsg;
        }

        //Get green diode status from RaspberryPI. [COMPLETE]
        public string GetDiodeStatus()
        {
            //Checks whether or not the raspberrypi has activated its output to toggle the diode.

            //Using a byte stream through socket communication on LAN network.
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

        //Get door status from RaspberryPI. [COMPLETE]
        public void GetDoorStatus()
        {
            //Checks the input state on the raspberrypi and changes the door animation on the GUI.

            //Using a byte stream through socket communication on LAN network.
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

        //Show temperature in the textbox. [COMPLETE]
        public void ShowCurrentTemperature(TextBox txtTemporary)
        {
            //Using a byte stream through socket communication on LAN network.
            byte[] request = Encoding.ASCII.GetBytes("GET TEMPERATURE<EOF>");

            //Gets the last temperature reading.
            string response = StartClient(request);

            //Show current temperature in a text box with celsius unit.
            txtTemporary.Text = response + "°C";
        }

        //Timer for doing tasks on a time interval. [COMPLETE]
        private void tmrSampleTime_Tick(object sender, EventArgs e)
        {
            //Get and show current temperature.
            ShowCurrentTemperature(txtCurrentTemperature);

            //Get door status.
            GetDoorStatus();

            //Show all alarms in ALARM table inside dgvAlarm.
            string sqlQuery = @"SELECT* FROM ALARM ORDER BY AlarmId ASC;";
            ViewQueryResultInDataGridView(sqlQuery, dgvAlarm);

            //Check to turn on/off the red diode.
            CheckIfAnyValueInTable();
        }



        //-------------------------------------------------TEMPORARY--------------------------------------------------------------


        //Makes an alarm in the alarm table and shows it.
        private void btnTemp_Click(object sender, EventArgs e)
        {
            txtTemp.Clear();
            InsertRow("ALARM", "2", "1", "message");
        }

        //Method to insert four values into a table, where the third value is DateTime (DateTime.Now from C#)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnClearAllAlarms_MouseHover(object sender, EventArgs e)
        {
            btnClearAllAlarms.BackColor = Color.Orange;
            btnClearAllAlarms.ForeColor = Color.Black;
        }

        private void btnClearAllAlarms_MouseLeave(object sender, EventArgs e)
        {
            btnClearAllAlarms.BackColor = Color.FromArgb(39, 39, 58);
            btnClearAllAlarms.ForeColor = Color.White;
        }
    }
}
