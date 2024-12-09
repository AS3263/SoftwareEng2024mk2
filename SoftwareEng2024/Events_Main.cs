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
    public partial class Events_Main : Form
    {
        public Events_Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PastEventsBtn_Click(object sender, EventArgs e)
        {
            Events_Past f2 = new Events_Past();
            f2.Show();

        }

        private void FutureEventsbtn_Click(object sender, EventArgs e)
        {

            Events_Future f2 = new Events_Future();
            f2.Show();
        }
    }
}
