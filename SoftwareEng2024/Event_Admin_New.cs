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
    public partial class Event_Admin_New : Form
    {
        public Event_Admin_New()
        {
            InitializeComponent();
        }

        private void Event_Admin_New_Load(object sender, EventArgs e)
        {

        }
        private void AddEventbtn_Click(object sender, EventArgs e)
        {
            // Retrieve values from TextBoxes
            string eventName = textBoxEventName.Text;
            string eventLocation = textBoxEventLocation.Text;
            DateTime eventDate = DateTime.Parse(textBoxEventDate.Text);  // Ensure proper date format
            TimeSpan startTime = TimeSpan.Parse(textBoxStartTime.Text);  // Ensure proper time format
            TimeSpan endTime = TimeSpan.Parse(textBoxEndTime.Text);  // Ensure proper time format

            // SQL query to insert data into the table
            string query = "INSERT INTO [Table] (Event_Name, Event_Location, Event_Date, Event_Start_Time, Event_End_Time) " +
                           "VALUES (@EventName, @EventLocation, @EventDate, @EventStartTime, @EventEndTime)";

            string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand object
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameters to the SQL query to prevent SQL injection
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@EventLocation", eventLocation);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@EventStartTime", startTime);
                    cmd.Parameters.AddWithValue("@EventEndTime", endTime);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the data was inserted successfully
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Event inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert event.");
                    }
                }
                catch (Exception ex)
                {
                    // Show error message if there is an issue
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
