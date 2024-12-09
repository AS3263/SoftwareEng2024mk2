namespace SoftwareEng2024
{
    partial class Events_Future
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FutureEventsbtn = new System.Windows.Forms.Button();
            this.PastEventsBtn = new System.Windows.Forms.Button();
            this.dataGridViewFutureEvents = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFutureEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.dataGridViewFutureEvents);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 618);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.FutureEventsbtn);
            this.panel2.Controls.Add(this.PastEventsBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 139);
            this.panel2.TabIndex = 2;
            // 
            // FutureEventsbtn
            // 
            this.FutureEventsbtn.Location = new System.Drawing.Point(557, 44);
            this.FutureEventsbtn.Name = "FutureEventsbtn";
            this.FutureEventsbtn.Size = new System.Drawing.Size(178, 59);
            this.FutureEventsbtn.TabIndex = 1;
            this.FutureEventsbtn.Text = "Future Events";
            this.FutureEventsbtn.UseVisualStyleBackColor = true;
            this.FutureEventsbtn.Click += new System.EventHandler(this.FutureEventsbtn_Click);
            // 
            // PastEventsBtn
            // 
            this.PastEventsBtn.Location = new System.Drawing.Point(148, 44);
            this.PastEventsBtn.Name = "PastEventsBtn";
            this.PastEventsBtn.Size = new System.Drawing.Size(178, 59);
            this.PastEventsBtn.TabIndex = 0;
            this.PastEventsBtn.Text = "Past Events";
            this.PastEventsBtn.UseVisualStyleBackColor = true;
            this.PastEventsBtn.Click += new System.EventHandler(this.PastEventsBtn_Click);
            // 
            // dataGridViewFutureEvents
            // 
            this.dataGridViewFutureEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFutureEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFutureEvents.Location = new System.Drawing.Point(0, 139);
            this.dataGridViewFutureEvents.Name = "dataGridViewFutureEvents";
            this.dataGridViewFutureEvents.RowHeadersWidth = 51;
            this.dataGridViewFutureEvents.RowTemplate.Height = 24;
            this.dataGridViewFutureEvents.Size = new System.Drawing.Size(873, 479);
            this.dataGridViewFutureEvents.TabIndex = 3;
            this.dataGridViewFutureEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFutureEvents_CellContentClick);
            // 
            // Events_Future
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 618);
            this.Controls.Add(this.panel1);
            this.Name = "Events_Future";
            this.Text = "Events_Future";
            this.Load += new System.EventHandler(this.Events_Future_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFutureEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewFutureEvents;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button FutureEventsbtn;
        private System.Windows.Forms.Button PastEventsBtn;
    }
}