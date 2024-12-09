using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace SoftwareEng2024
{
    public partial class Main : Form
    {
        

        public Main()
        {
            InitializeComponent();
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Navigate to Signup Page
            var signupForm = new Signup();
            signupForm.Show();
            this.Hide();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            AboutUs AboutUsForm = new AboutUs();
            AboutUsForm.Show();
            this.Hide();


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
