using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEng2024
{
    public partial class Memberdashboard : Form
    {
        private int memberId; // Store the logged-in member's ID
        private bool isPanelExpanded = false;
        private int panelWidth;
        private int panel1Width = 150; // Reduced width for panel1
        private int slideSpeed = 10;  // Adjust this for smoothness
        private int gapSize = 10;

        public Memberdashboard(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId; // Assign the logged-in MemberID
            panel1.Width = 0; // Start with the panel fully collapsed
            panel1.Visible = true; // Ensure the panel is visible
            panelContent.Left = panel1.Right + gapSize;
        }

        private void CONBTN_Click(object sender, EventArgs e)
        {
            
            DCM dcmForm = new DCM(memberId);
            dcmForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Return to Main page
            var mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private void ChatBox_Button_Click(object sender, EventArgs e)
        {
            var chatboxForm = new Form1();
            chatboxForm.Show();
            this.Hide();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            int memberId = this.memberId; // Ensure memberId is available in memberdashboard
            Profile PROFILEForm = new Profile(memberId);
            PROFILEForm.Show();
            this.Hide();

        }

        private void Memberdashboard_Load(object sender, EventArgs e)
        {
            LoadMembershipType(); // Load the membership type when the form loads
            LoadInterest();// Populate label
            LoadUnreadMessagesCount();

        }

        private void Mybenefits_Click(object sender, EventArgs e)
        {
            MyBenefits benefitsForm = new MyBenefits(memberId);
            benefitsForm.Show();
            this.Hide();
        }

        private void BTNMYBENEFITS_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadMembershipType()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get the membership type for the logged-in member
                    string query = @"
                        SELECT MT.TypeName
                        FROM Members M
                        INNER JOIN MembershipTypes MT ON M.MembershipTypeID = MT.MembershipTypeID
                        WHERE M.MemberID = @MemberID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string membershipType = result.ToString();
                            lblmembershiptype.Text = $"Membership Type: {membershipType}"; // Display membership type in label
                        }
                        else
                        {
                            lblmembershiptype.Text = "Membership Type: Not Found"; // Default message if no type is found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching membership type: {ex.Message}");
            }
        }
        private void LoadInterest()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get the interests for the member
                    string query = @"
                SELECT I.InterestName
                FROM MemberInterests MI
                INNER JOIN Interests I ON MI.InterestID = I.InterestID
                WHERE MI.MemberID = @MemberID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder interests = new StringBuilder();
                            while (reader.Read())
                            {
                                interests.Append(reader["InterestName"].ToString() + ", ");
                            }

                            // Remove trailing comma and space
                            if (interests.Length > 0)
                            {
                                interests.Length -= 2;
                            }

                            lblinterest.Text = interests.Length > 0 ? $"Interests: {interests}" : "Interests: None";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching interests: {ex.Message}");
            }
        }

        private void CHAT_Click(object sender, EventArgs e)
        {
            // Opens the chat search form passing the currently logged in MemberID
            var chatForm = new chat(memberId);
            chatForm.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadUnreadMessagesCount()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT COUNT(*) AS UnreadCount
                FROM Messages
                WHERE ReceiverID = @MemberID 
                  AND IsRead = 0;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        int unreadCount = (int)cmd.ExecuteScalar();

                        // Update the label with the count
                        UpdateUnreadNotification(unreadCount);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading unread messages count: " + ex.Message);
            }
        }

        private void UpdateUnreadNotification(int count)
        {
            if (count > 0)
            {
                lblUnreadCount.Visible = true;
                lblUnreadCount.Text = count.ToString();

            }
            else
            {
                // If no unread messages, hide the label
                lblUnreadCount.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelExpanded)
            {
                // Expand the panel
                if (panel1.Width < panel1Width) // Use the reduced width value
                {
                    panel1.Width += slideSpeed;
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully expanded
                }
            }
            else
            {
                // Collapse the panel
                if (panel1.Width > 0)
                {
                    panel1.Width -= slideSpeed;
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully collapsed
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            isPanelExpanded = !isPanelExpanded;
            timer1.Start();
        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Event_Click(object sender, EventArgs e)
        {
            Events_Main eventsMain = new Events_Main();
            eventsMain.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Events_Main eventsMain = new Events_Main();
            eventsMain.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            DCM dcmForm = new DCM(memberId);
            dcmForm.Show();
            this.Hide();

        }
    }
}
