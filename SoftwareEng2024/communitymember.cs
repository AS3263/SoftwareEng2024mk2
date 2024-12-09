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
    public partial class communitymember : Form
    {
        private bool isPanelExpanded = false;
        private int panelWidth;
        private int panel5Width = 150; // Reduced width for panel5
        private int slideSpeed = 10;  // Adjust this for smoothness
        private int gapSize = 10;
        public communitymember()
        {
            InitializeComponent();

            panel5.Width = 0; // Start with the panel fully collapsed
            panel5.Visible = true; // Ensure the panel is visible
            panelContent.Left = panel5.Right + gapSize;
        }

        private void communitymember_Load(object sender, EventArgs e)
        {
            InitializeComponent();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelExpanded)
            {
                // Expand the panel
                if (panel5.Width < panel5Width) // Use the reduced width value
                {
                    panel5.Width += slideSpeed;
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully expanded
                }
            }
            else
            {
                // Collapse the panel
                if (panel5.Width > 0)
                {
                    panel5.Width -= slideSpeed;
                }
                else
                {
                    timer1.Stop(); // Stop the timer when fully collapsed
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isPanelExpanded = !isPanelExpanded;
            timer1.Start();
        }
    }
}
