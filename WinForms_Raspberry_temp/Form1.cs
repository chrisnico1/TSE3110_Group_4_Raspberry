using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace WinFormsTestOne
{
    public partial class Form1 : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }


        ///Functions from GUI///


        private void Form1_Load(object sender, EventArgs e)
        {

        }


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


        //Toggle the green lamp on/off. [NOT COMPLETE]
        private void rdoGreenLight_CheckedChanged(object sender, EventArgs e)
        {


        }


        ///Self-made methods///


        //View a query in the datagridview.
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

        private void btnDiode_Click(object sender, EventArgs e)
        {

        }
    }
}