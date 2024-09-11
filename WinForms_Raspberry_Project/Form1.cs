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

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlQuery = $"SELECT * FROM BUTTON";
            ViewQueryResultInDataGridView(conn, sqlQuery, dataGridView1);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}