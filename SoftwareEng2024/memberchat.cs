using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SoftwareEng2024
{
    public partial class memberchat : Form
    {
        private int memberId; // The ID of the logged-in user
        private int chatWithMemberId; // The ID of the member being chatted with
        private bool isPanelExpanded = false;
        private int panelWidth;
        private int panel2Width = 150; // Reduced width for panel2
        private int slideSpeed = 10;  // Adjust this for smoothness
        private int gapSize = 10;

        public memberchat(int memberId, int chatWithMemberId, string chatWithName)
        {
            InitializeComponent();
            this.memberId = memberId;
            this.chatWithMemberId = chatWithMemberId;

            lblChatWith.Text = $"Chat with: {chatWithName}";

            panel2.Width = 0; // Start with the panel fully collapsed
            panel2.Visible = true; // Ensure the panel is visible
            panelContent.Left = panel2.Right + gapSize;
        }

        private void memberchat_Load(object sender, EventArgs e)
        {
            // Debug:
            MessageBox.Show($"MemberChat loaded. memberId: {memberId}, chatWithMemberId: {chatWithMemberId}");

            MarkMessagesAsRead(); // Mark all unread messages in this chat as read
            LoadChatHistory();
        }

        private void MarkMessagesAsRead()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Mark all messages from chatWithMemberId to memberId as read
                    string updateQuery = @"
                        UPDATE Messages
                        SET IsRead = 1
                        WHERE ReceiverID = @MemberID AND SenderID = @ChatWithMemberID AND IsRead = 0";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        cmd.Parameters.AddWithValue("@ChatWithMemberID", chatWithMemberId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking messages as read: {ex.Message}");
            }
        }

        private void LoadChatHistory()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            CASE WHEN SenderID = @MemberID THEN 'You' ELSE 'Them' END AS Sender,
                            MessageText,
                            [Timestamp]
                        FROM Messages
                        WHERE 
                            (SenderID = @MemberID AND ReceiverID = @ChatWithMemberID)
                            OR
                            (SenderID = @ChatWithMemberID AND ReceiverID = @MemberID)
                        ORDER BY [Timestamp]";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        cmd.Parameters.AddWithValue("@ChatWithMemberID", chatWithMemberId);

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                        dgvMessages.DataSource = dt;
                        dgvMessages.Columns["MessageText"].HeaderText = "Message";
                        dgvMessages.Columns["Timestamp"].HeaderText = "Time";

                        dgvMessages.AllowUserToAddRows = false;
                        dgvMessages.RowHeadersVisible = false;
                        dgvMessages.ReadOnly = true;
                        dgvMessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        dgvMessages.Columns["Sender"].FillWeight = 20;
                        dgvMessages.Columns["MessageText"].FillWeight = 200;
                        dgvMessages.Columns["Timestamp"].FillWeight = 40;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chat history: {ex.Message}");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string messageText = txtMessage.Text.Trim();
            if (string.IsNullOrWhiteSpace(messageText))
            {
                MessageBox.Show("Message cannot be empty.");
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = @"
                        INSERT INTO Messages (SenderID, ReceiverID, MessageText, IsRead) 
                        VALUES (@SenderID, @ReceiverID, @MessageText, 0)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@SenderID", memberId);
                        cmd.Parameters.AddWithValue("@ReceiverID", chatWithMemberId);
                        cmd.Parameters.AddWithValue("@MessageText", messageText);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            // Refresh chat history
                            LoadChatHistory();
                            txtMessage.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to send message.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelExpanded)
            {
                // Expand the panel
                if (panel2.Width < panel2Width) // Use the reduced width value
                {
                    panel2.Width += slideSpeed;
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully expanded
                }
            }
            else
            {
                // Collapse the panel
                if (panel2.Width > 0)
                {
                    panel2.Width -= slideSpeed;
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully collapsed
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isPanelExpanded = !isPanelExpanded;
            timer1.Start();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Memberdashboard memberDashboard = new Memberdashboard(memberId);
            memberDashboard.Show();
            this.Hide();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            Profile PROFILEForm = new Profile(memberId);
            PROFILEForm.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var chatForm = new chat(memberId);
            chatForm.Show();
            this.Hide();
        }

        private void CONBTN_Click(object sender, EventArgs e)
        {
            DCM dcmForm = new DCM(memberId);
            dcmForm.Show();
            this.Hide();
        }

        private void Event_Click(object sender, EventArgs e)
        {
            Events_Main eventsMain = new Events_Main();
            eventsMain.Show();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Return to Main page
            var mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }
    }
}
