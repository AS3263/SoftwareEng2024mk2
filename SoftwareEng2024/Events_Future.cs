using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEng2024
{
    public partial class Events_Future : Form
    {
        public Events_Future()
        {
            InitializeComponent();
        }

        private void Events_Future_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Define the SQL query to fetch data
                    string query = "SELECT * FROM [Table] WHERE Event_IsPast = 0";

                    // Create the data adapter
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Create a DataTable to hold the fetched data
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable using the data adapter
                    dataAdapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridViewFutureEvents.DataSource = dataTable;

                    dataGridViewFutureEvents.ReadOnly = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridViewFutureEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PastEventsBtn_Click(object sender, EventArgs e)
        {
            Events_Past f2 = new Events_Past();
            f2.Show();
        }

        private void FutureEventsbtn_Click(object sender, EventArgs e)
        {
            Events_Future f2 = new Events_Future();
            f2.Show();
        }
    }
}
