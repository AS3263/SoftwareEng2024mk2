using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

namespace SoftwareEng2024
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            PopulateMembershipTypeComboBox();
            PopulateInterestComboBox();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                Label label = this.Controls["lbl" + textBox.Name.Substring(3)] as Label;
                if (label != null)
                {
                    label.Visible = false;
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                Label label = this.Controls["lbl" + textBox.Name.Substring(3)] as Label;
                if (label != null)
                {
                    label.Visible = true;
                }
            }
        }

        private void PlaceholderLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                TextBox textBox = this.Controls["txt" + label.Name.Substring(3)] as TextBox;
                if (textBox != null)
                {
                    textBox.Focus();
                }
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                btnTogglePassword.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnTogglePassword.Text = "Show";
            }
        }

        private void btnToggleConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '*')
            {
                txtConfirmPassword.PasswordChar = '\0';
                btnToggleConfirmPassword.Text = "Hide";
            }
            else
            {
                txtConfirmPassword.PasswordChar = '*';
                btnToggleConfirmPassword.Text = "Show";
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must have:\n- Minimum 8 characters\n- At least 1 uppercase letter\n- At least 1 lowercase letter\n- At least 1 number\n- At least 1 special character\n- No spaces",
                    "Password Requirements", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the password before saving to the database
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Save user to database
            if (SaveUserToDatabase(name, username, email, hashedPassword))
            {
                MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var loginForm = new login();
                loginForm.Show();
                this.Hide();
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void lnkReturnToMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private bool SaveUserToDatabase(string name, string username, string email, string hashedPassword)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("The connection string 'UserDatabaseConnection' is missing or incorrect.",
                                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Validate MembershipType selection
                            if (cmbMembershipType.SelectedValue == null)
                            {
                                MessageBox.Show("Please select a valid membership type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            // Get the selected MembershipTypeID
                            int membershipTypeId = Convert.ToInt32(cmbMembershipType.SelectedValue);

                            // Insert user data into Members table
                            string memberInsertQuery = @"
                        INSERT INTO Members (Name, Username, Email, PasswordHash, MembershipTypeID) 
                        OUTPUT INSERTED.MemberID 
                        VALUES (@Name, @Username, @Email, @PasswordHash, @MembershipTypeID)";

                            SqlCommand memberCommand = new SqlCommand(memberInsertQuery, connection, transaction);
                            memberCommand.Parameters.AddWithValue("@Name", name);
                            memberCommand.Parameters.AddWithValue("@Username", username);
                            memberCommand.Parameters.AddWithValue("@Email", email);
                            memberCommand.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                            memberCommand.Parameters.AddWithValue("@MembershipTypeID", membershipTypeId);

                            // Get the generated MemberID
                            int memberId = (int)memberCommand.ExecuteScalar();

                            // DEBUG: Log MemberID
                            Console.WriteLine($"Inserted MemberID: {memberId}");

                            // Validate Interest selection
                            if (cmbInterests.SelectedValue == null)
                            {
                                MessageBox.Show("Please select an interest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            // Get the selected InterestID
                            int interestId = Convert.ToInt32(cmbInterests.SelectedValue);

                            // Insert selected interest into MemberInterests table
                            string interestInsertQuery = @"
                        INSERT INTO MemberInterests (MemberID, InterestID) 
                        VALUES (@MemberID, @InterestID)";

                            SqlCommand interestCommand = new SqlCommand(interestInsertQuery, connection, transaction);
                            interestCommand.Parameters.AddWithValue("@MemberID", memberId);
                            interestCommand.Parameters.AddWithValue("@InterestID", interestId);
                            interestCommand.ExecuteNonQuery();

                            // Commit transaction if all inserts are successful
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on failure
                            transaction.Rollback();
                            MessageBox.Show($"Error saving member data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void PopulateMembershipTypeComboBox()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("Connection string is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to fetch membership types
                    string query = "SELECT MembershipTypeID, TypeName FROM MembershipTypes";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Check if data is returned
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No membership types found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Bind data to ComboBox
                        cmbMembershipType.DataSource = dataTable;
                        cmbMembershipType.DisplayMember = "TypeName";  // Display in ComboBox
                        cmbMembershipType.ValueMember = "MembershipTypeID";  // Underlying value
                        cmbMembershipType.SelectedIndex = -1;  // Default to no selection
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error loading membership types: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error loading membership types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PopulateInterestComboBox()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"]?.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT InterestID, InterestName FROM Interests";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cmbInterests.DataSource = dataTable;
                    cmbInterests.DisplayMember = "InterestName";
                    cmbInterests.ValueMember = "InterestID";
                    cmbInterests.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading interests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordPattern) && !password.Contains(" ");
        }

        private void learnmore1_Click(object sender, EventArgs e)
        {
            var membershipForm = new membership();
            membershipForm.Show();
            
        }
    }
}
