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

namespace RaspberryServerClientForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string GetDiodeStatus()
        {
            byte[] request = Encoding.ASCII.GetBytes("GET BUTTON<EOF>");
            string response = StartClient(request);
            if (Convert.ToInt32(response) == 0)
            {
                button1.BackColor = Color.White;
            }
            else if (Convert.ToInt32(response) == 1)
            {
                button1.BackColor = Color.Red;
            }
            return response;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string response = GetDiodeStatus();
            txtMsg.Text = response;
        }

        private void btnGetTemperature_Click(object sender, EventArgs e)
        {
            byte[] request = Encoding.ASCII.GetBytes("GET TEMPERATURE<EOF>");
            string response = StartClient(request);
            txtMsg.Text = response;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] request = Encoding.ASCII.GetBytes("TOGGLE DIODE<EOF>");
            string response = StartClient(request);
            txtMsg.Text = response;
            Thread.Sleep(500);
            string _ = GetDiodeStatus();
        }
    }
}
