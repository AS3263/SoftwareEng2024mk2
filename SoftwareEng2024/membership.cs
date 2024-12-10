using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEng2024
{
    public partial class membership : Form
    {
        public membership()
        {
            InitializeComponent();
        }
        private void membership_Load(object sender, EventArgs e)
        {

        }
        public void Showmembership()
        {
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            communitymember communitymemeber = new communitymember();
            communitymemeber.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            communitymember communitymemeber = new communitymember();
            communitymemeber.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            communitymember communitymemeber = new communitymember();
            communitymemeber.Show();
            this.Hide();
        }

        private void membership_Load_1(object sender, EventArgs e)
        {

        }
    }
}
