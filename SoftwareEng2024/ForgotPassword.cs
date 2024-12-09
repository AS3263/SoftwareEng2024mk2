using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace SoftwareEng2024
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                // Show error if email field is empty
                lblError.Text = "Please enter your email address.";
                lblError.ForeColor = System.Drawing.Color.Black;
                lblError.Visible = true;
                return;
            }

            if (IsEmailRegistered(email))
            {
                lblError.Text = "A password reset link has been sent to your email.";
                lblError.ForeColor = System.Drawing.Color.Black;
                lblError.Visible = true;
            }
            else
            {
                // If email does not exist, show error message
                lblError.Text = "We cannot find your email.";
                lblError.ForeColor = System.Drawing.Color.Black;
                lblError.Visible = true;
            }
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate back to the Login form
            var loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private bool IsEmailRegistered(string email)
        {
            try
            {
                // Get connection string from App.config
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to check if the email exists
                    string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        return Convert.ToInt32(command.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error in case of exception
                MessageBox.Show($"Error checking email: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
