namespace SoftwareEng2024
{
    partial class Events_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Events_Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PastEventsBtn = new System.Windows.Forms.Button();
            this.FutureEventsbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 812);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.FutureEventsbtn);
            this.panel2.Controls.Add(this.PastEventsBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 139);
            this.panel2.TabIndex = 0;
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(527, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 300);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 300);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // Events_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 812);
            this.Controls.Add(this.panel1);
            this.Name = "Events_Main";
            this.Text = "Events_Main";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PastEventsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FutureEventsbtn;
        private System.Windows.Forms.Label label2;
    }
}