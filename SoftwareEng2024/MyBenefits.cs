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
    public partial class MyBenefits : Form
    {
        private int memberId; // Store the MemberID
        private bool isPanelExpanded = false;
        private int panelWidth;
        private int panel2Width = 150; // Reduced width for panel2
        private int slideSpeed = 10;  // Adjust this for smoothness
        private int gapSize = 10;

        public MyBenefits(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId;// Assign the MemberID

            panel2.Width = 0; // Start with the panel fully collapsed
            panel2.Visible = true; // Ensure the panel is visible
            panelContent.Left = panel2.Right + gapSize;
        }

        private void MyBenefits_Load(object sender, EventArgs e)
        {
            LoadBenefits(memberId); // Load benefits on form load
        }
        private void LoadBenefits(int memberId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Get MembershipTypeID for the member
                    int membershipTypeId = 0;
                    string memberQuery = "SELECT MembershipTypeID FROM Members WHERE MemberID = @MemberID";

                    using (SqlCommand cmd = new SqlCommand(memberQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            membershipTypeId = Convert.ToInt32(result); // Extract MembershipTypeID
                        }
                        else
                        {
                            MessageBox.Show("Member not found.");
                            return; // Stop if the member doesn't exist
                        }
                    }

                    // Step 2: Fetch all benefits based on MembershipTypeID logic
                    string benefitsQuery = "SELECT BenefitName, Description, ApplicableMembershipTypeID FROM Benefits";

                    using (SqlCommand cmd = new SqlCommand(benefitsQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            benefitsView.Nodes.Clear(); // Clear existing nodes in the TreeView
                            panelContent.Controls.Clear(); // Clear existing controls in panelContent

                            // Optional: Adjust panelContent size here
                            panelContent.Width = 600; // Example: Adjust the width of the panel content

                            // Update the TreeView size and style
                            benefitsView.Width = panelContent.Width - 20; // Example: Fit TreeView within the panel
                            benefitsView.Font = new Font("Segoe UI", 12); // Increase font size for better visibility

                            while (reader.Read())
                            {
                                string benefitName = reader["BenefitName"].ToString();
                                string benefitDescription = reader["Description"].ToString();
                                int applicableMembershipTypeId = Convert.ToInt32(reader["ApplicableMembershipTypeID"]);

                                // Apply logic to include benefits based on MembershipTypeID
                                if (applicableMembershipTypeId <= membershipTypeId)
                                {
                                    // Add benefit as a parent node and description as a child node
                                    TreeNode parentNode = new TreeNode(benefitName);
                                    parentNode.Nodes.Add(benefitDescription); // Add description as a child node
                                    benefitsView.Nodes.Add(parentNode);
                                }
                            }

                            // Step 3: Handle case where no benefits are found
                            if (benefitsView.Nodes.Count == 0)
                            {
                                TreeNode noBenefitsNode = new TreeNode("No benefits available for your membership type.");
                                benefitsView.Nodes.Add(noBenefitsNode);
                            }

                            // Add TreeView to panelContent
                            panelContent.Controls.Add(benefitsView);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading benefits: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isPanelExpanded = !isPanelExpanded;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelExpanded)
            {
                // Expand the panel
                if (panel2.Width < panel2Width) // Use the reduced width value
                {
                    panel2.Width += slideSpeed;
                    panelContent.Left = panel2.Right + gapSize; // Add gap between panel4 and panelContent
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
                    panelContent.Left = panel2.Right + gapSize; // Maintain gap when collapsing
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully collapsed
                }
            }
        }
    }
}
