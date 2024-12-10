using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics; // for Process.Start
using System.Drawing;
using System.Windows.Forms;

namespace SoftwareEng2024
{
    public partial class DCM : Form
    {
        private int memberId;

        private bool isPanelExpanded = false;
        private int panelWidth;
        private int panel4Width = 150; // Reduced width for panel4
        private int slideSpeed = 10;  // Adjust this for smoothness
        private int gapSize = 10;

        public DCM(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId; // Assign the logged-in MemberID

            LoadAllContent();
            LoadMemberAccessedContent();

            panelWidth = 200; // Set the desired width
            panel4.Width = 0; // Start with the panel collapsed
            panel4.Visible = true;
            panel1.Left = panel4.Right;
        }

        private void LoadAllContent()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Include ModuleID in the select statement
                string query = "SELECT ModuleID, ModuleName, Description, ContentURL FROM DigitalContentModules";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;

                // Hide the ContentURL and ModuleID columns
                if (dataGridView1.Columns.Contains("ContentURL"))
                    dataGridView1.Columns["ContentURL"].Visible = false;
                if (dataGridView1.Columns.Contains("ModuleID"))
                    dataGridView1.Columns["ModuleID"].Visible = false;

                // Add a Button Column for opening URLs if it doesn't exist
                if (!dataGridView1.Columns.Contains("OpenURLButton"))
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Open Content",
                        Text = "Go",
                        Name = "OpenURLButton",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(buttonColumn);
                }

                // Auto-size columns
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (dataGridView1.Columns.Contains("Description"))
                    dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadMemberAccessedContent()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        DCM.ModuleName, 
                        DCM.Description, 
                        DCM.ContentURL,
                        MCA.AccessDate
                    FROM MemberContentAccessed MCA
                    INNER JOIN DigitalContentModules DCM ON MCA.ModuleID = DCM.ModuleID
                    WHERE MCA.MemberID = @MemberID
                    ORDER BY MCA.AccessDate DESC;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberId);

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    dataGridView2.DataSource = dt;

                    // Hide the ContentURL column
                    if (dataGridView2.Columns.Contains("ContentURL"))
                        dataGridView2.Columns["ContentURL"].Visible = false;

                    // Add a Button Column for opening URLs if it doesn't exist
                    if (!dataGridView2.Columns.Contains("OpenURLButton"))
                    {
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                        {
                            HeaderText = "Open Content",
                            Text = "Go",
                            Name = "OpenURLButton",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridView2.Columns.Add(buttonColumn);
                    }

                    // Auto-size columns
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (dataGridView2.Columns.Contains("Description"))
                        dataGridView2.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    // Rename columns for better readability
                    if (dataGridView2.Columns.Contains("ModuleName"))
                        dataGridView2.Columns["ModuleName"].HeaderText = "Content Name";
                    if (dataGridView2.Columns.Contains("AccessDate"))
                        dataGridView2.Columns["AccessDate"].HeaderText = "Accessed On";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle opening content from the main content list
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "OpenURLButton")
            {
                try
                {
                    string contentURL = dataGridView1.Rows[e.RowIndex].Cells["ContentURL"].Value?.ToString();
                    // Get the ModuleID for inserting access record
                    int moduleID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ModuleID"].Value);

                    if (!string.IsNullOrEmpty(contentURL) && Uri.IsWellFormedUriString(contentURL, UriKind.Absolute))
                    {
                        // Insert record into MemberContentAccessed
                        InsertAccessRecord(moduleID, memberId);

                        // Refresh the member accessed content grid
                        LoadMemberAccessedContent();

                        // Open the URL in the default web browser
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = contentURL,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("The URL is empty or invalid.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void InsertAccessRecord(int moduleID, int memberID)
        {
            // Insert a new record into MemberContentAccessed to track that the member accessed this content
            string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO MemberContentAccessed (ModuleID, MemberID)
                    VALUES (@ModuleID, @MemberID)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@ModuleID", moduleID);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Return to Main page
            var mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelExpanded)
            {
                // Expand the panel
                if (panel4.Width < panel4Width) // Use the reduced width value
                {
                    panel4.Width += slideSpeed;
                    panelContent.Left = panel4.Right + gapSize; // Add gap between panel4 and panelContent
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
                    panelContent.Left = panel4.Right + gapSize; // Maintain gap when collapsing
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

        private void DCM_Load(object sender, EventArgs e)
        {
           
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Memberdashboard memberDashboard = new Memberdashboard(memberId);
            memberDashboard.Show();
            this.Hide();
        }

        private void CONBTN_Click(object sender, EventArgs e)
        {
            
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            Profile PROFILEForm = new Profile(memberId);
            PROFILEForm.Show();
            this.Hide();
        }

        private void Event_Click(object sender, EventArgs e)
        {
            Events_Main eventsMain = new Events_Main();
            eventsMain.Show();
        }

        private void ChatBox_Button_Click(object sender, EventArgs e)
        {
            var chatForm = new chat(memberId);
            chatForm.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle opening content from the member accessed content list
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "OpenURLButton")
            {
                try
                {
                    string contentURL = dataGridView2.Rows[e.RowIndex].Cells["ContentURL"].Value?.ToString();

                    if (!string.IsNullOrEmpty(contentURL) && Uri.IsWellFormedUriString(contentURL, UriKind.Absolute))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = contentURL,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("The URL is empty or invalid.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
