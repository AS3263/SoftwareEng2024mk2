using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace SoftwareEng2024
{
    public partial class chat : Form
    {
        private int memberId;
        private bool isPanelExpanded = false;
        private int panelWidth;
        private int panel4Width = 150; // Reduced width for panel4
        private int slideSpeed = 10;  // Adjust this for smoothness
        private int gapSize = 10;

        public chat(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
            panel4.Width = 0; // Start with the panel fully collapsed
            panel4.Visible = true; // Ensure the panel is visible
            panelContent.Left = panel4.Right + gapSize;
        }

        private void chat_Load(object sender, EventArgs e)
        {
            // Debug line to confirm we have the correct member ID
            MessageBox.Show("In Chat form, MemberID: " + memberId);

            LoadAllChats(); // Load the summary of all chats
        }

        private void search_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Enter a keyword to search.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT MemberID, Name 
                    FROM Members
                    WHERE Name LIKE @Search OR CAST(MemberID AS NVARCHAR) LIKE @Search";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }

                    dgvMembers.DataSource = dataTable;

                    // Check if column already added
                    if (!dgvMembers.Columns.Contains("btnChat"))
                    {
                        DataGridViewButtonColumn chatButtonColumn = new DataGridViewButtonColumn
                        {
                            HeaderText = "Chat",
                            Text = "Chat",
                            UseColumnTextForButtonValue = true,
                            Name = "btnChat"
                        };
                        dgvMembers.Columns.Add(chatButtonColumn);
                    }

                    // Basic formatting
                    dgvMembers.AllowUserToAddRows = false;
                    dgvMembers.RowHeadersVisible = false;
                    dgvMembers.ReadOnly = true;
                    dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check the column name that we actually added: "btnChat"
            if (e.ColumnIndex >= 0 && dgvMembers.Columns[e.ColumnIndex].Name == "btnChat" && e.RowIndex >= 0)
            {
                int chatWithMemberId = Convert.ToInt32(dgvMembers.Rows[e.RowIndex].Cells["MemberID"].Value);
                string chatWithName = dgvMembers.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                // Debug message to ensure correct IDs
                MessageBox.Show($"Opening chat with MemberID: {chatWithMemberId}, Name: {chatWithName}");

                var memberchatForm = new memberchat(memberId, chatWithMemberId, chatWithName);
                memberchatForm.Show();
            }
        }

        private void LoadAllChats()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT M.MemberID, M.Name,
                               MAX(Mg.[Timestamp]) AS LastMessageTime,
                               (SELECT TOP 1 Mg2.MessageText
                                FROM Messages Mg2
                                WHERE (Mg2.SenderID = @MemberID AND Mg2.ReceiverID = M.MemberID)
                                   OR (Mg2.SenderID = M.MemberID AND Mg2.ReceiverID = @MemberID)
                                ORDER BY Mg2.[Timestamp] DESC) AS LastMessage,
                               (SELECT COUNT(*)
                                FROM Messages Mg3
                                WHERE Mg3.SenderID = M.MemberID
                                  AND Mg3.ReceiverID = @MemberID
                                  AND Mg3.IsRead = 0) AS UnreadCount
                        FROM Members M
                        INNER JOIN Messages Mg
                            ON ((Mg.SenderID = @MemberID AND Mg.ReceiverID = M.MemberID)
                                OR (Mg.SenderID = M.MemberID AND Mg.ReceiverID = @MemberID))
                        GROUP BY M.MemberID, M.Name
                        ORDER BY LastMessageTime DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                        dgvAllChats.DataSource = dt;

                        // Adjust the appearance
                        dgvAllChats.AllowUserToAddRows = false;
                        dgvAllChats.RowHeadersVisible = false;
                        dgvAllChats.ReadOnly = true;
                        dgvAllChats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvAllChats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Rename columns if they exist
                        if (dgvAllChats.Columns.Contains("Name"))
                            dgvAllChats.Columns["Name"].HeaderText = "Contact";

                        if (dgvAllChats.Columns.Contains("LastMessage"))
                            dgvAllChats.Columns["LastMessage"].HeaderText = "Last Message";

                        if (dgvAllChats.Columns.Contains("LastMessageTime"))
                            dgvAllChats.Columns["LastMessageTime"].HeaderText = "Time";

                        if (dgvAllChats.Columns.Contains("UnreadCount"))
                            dgvAllChats.Columns["UnreadCount"].HeaderText = "Unread";

                        // Adjust column widths
                        if (dgvAllChats.Columns.Contains("Name"))
                            dgvAllChats.Columns["Name"].FillWeight = 100;
                        if (dgvAllChats.Columns.Contains("LastMessage"))
                            dgvAllChats.Columns["LastMessage"].FillWeight = 300;
                        if (dgvAllChats.Columns.Contains("LastMessageTime"))
                            dgvAllChats.Columns["LastMessageTime"].FillWeight = 50;
                        if (dgvAllChats.Columns.Contains("UnreadCount"))
                            dgvAllChats.Columns["UnreadCount"].FillWeight = 30;

                        // Hide MemberID if desired
                        if (dgvAllChats.Columns.Contains("MemberID"))
                            dgvAllChats.Columns["MemberID"].Visible = false;

                        // Add a Chat button column if it doesn't exist
                        if (!dgvAllChats.Columns.Contains("btnOpenChat"))
                        {
                            DataGridViewButtonColumn openChatButton = new DataGridViewButtonColumn
                            {
                                HeaderText = "Open Chat",
                                Text = "Open",
                                UseColumnTextForButtonValue = true,
                                Name = "btnOpenChat"
                            };
                            dgvAllChats.Columns.Add(openChatButton);
                        }

                        // Highlight rows with unread messages if you want
                        foreach (DataGridViewRow row in dgvAllChats.Rows)
                        {
                            if (row.Cells["UnreadCount"].Value != null)
                            {
                                int unread = Convert.ToInt32(row.Cells["UnreadCount"].Value);
                                if (unread > 0)
                                {
                                    // Make the font bold or change background color for unread
                                    row.DefaultCellStyle.Font = new Font(dgvAllChats.Font, FontStyle.Bold);
                                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chat summary: " + ex.Message);
            }
        }

        private void dgvAllChats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvAllChats.Columns[e.ColumnIndex].Name == "btnOpenChat")
            {
                // Get the selected member's ID from the row
                int selectedMemberID = Convert.ToInt32(dgvAllChats.Rows[e.RowIndex].Cells["MemberID"].Value);
                string contactName = dgvAllChats.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                // Open memberchat form
                memberchat chatForm = new memberchat(memberId, selectedMemberID, contactName);
                chatForm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelExpanded)
            {
                // Expand the panel
                if (panel4.Width < panel4Width) // Use the reduced width value
                {
                    panel4.Width += slideSpeed;
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully expanded
                }
            }
            else
            {
                // Collapse the panel
                if (panel4.Width > 0)
                {
                    panel4.Width -= slideSpeed;
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
    }
}
