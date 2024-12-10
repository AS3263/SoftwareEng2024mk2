using System.Windows.Forms;

namespace SoftwareEng2024
{
    partial class memberchat
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.Membership = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Profile_icon = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.Event = new System.Windows.Forms.Button();
            this.CONBTN = new System.Windows.Forms.Button();
            this.Home_icon = new System.Windows.Forms.PictureBox();
            this.ChatBox_Button = new System.Windows.Forms.Button();
            this.Chat_icon = new System.Windows.Forms.PictureBox();
            this.Event_icon = new System.Windows.Forms.PictureBox();
            this.Memebrship_icon = new System.Windows.Forms.PictureBox();
            this.Profile = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            this.lblChatWith = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Profile_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chat_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Memebrship_icon)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblChatWith);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.panelContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 715);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCoral;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.Home);
            this.panel2.Controls.Add(this.Membership);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.Profile_icon);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.Event);
            this.panel2.Controls.Add(this.CONBTN);
            this.panel2.Controls.Add(this.Home_icon);
            this.panel2.Controls.Add(this.ChatBox_Button);
            this.panel2.Controls.Add(this.Chat_icon);
            this.panel2.Controls.Add(this.Event_icon);
            this.panel2.Controls.Add(this.Memebrship_icon);
            this.panel2.Controls.Add(this.Profile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 557);
            this.panel2.TabIndex = 55;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(72, 290);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 32);
            this.button4.TabIndex = 46;
            this.button4.Text = "Chat";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(72, 29);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(118, 34);
            this.Home.TabIndex = 34;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Membership
            // 
            this.Membership.Location = new System.Drawing.Point(72, 252);
            this.Membership.Name = "Membership";
            this.Membership.Size = new System.Drawing.Size(118, 32);
            this.Membership.TabIndex = 37;
            this.Membership.Text = "Membership";
            this.Membership.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SoftwareEng2024.Properties.Resources.logout;
            this.pictureBox1.Location = new System.Drawing.Point(25, 493);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // Profile_icon
            // 
            this.Profile_icon.Image = global::SoftwareEng2024.Properties.Resources.user;
            this.Profile_icon.Location = new System.Drawing.Point(22, 77);
            this.Profile_icon.Name = "Profile_icon";
            this.Profile_icon.Size = new System.Drawing.Size(44, 34);
            this.Profile_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Profile_icon.TabIndex = 38;
            this.Profile_icon.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(75, 495);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(105, 32);
            this.btnLogout.TabIndex = 43;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Event
            // 
            this.Event.Location = new System.Drawing.Point(72, 166);
            this.Event.Name = "Event";
            this.Event.Size = new System.Drawing.Size(118, 32);
            this.Event.TabIndex = 36;
            this.Event.Text = "Event";
            this.Event.UseVisualStyleBackColor = true;
            this.Event.Click += new System.EventHandler(this.Event_Click);
            // 
            // CONBTN
            // 
            this.CONBTN.Location = new System.Drawing.Point(72, 209);
            this.CONBTN.Name = "CONBTN";
            this.CONBTN.Size = new System.Drawing.Size(118, 34);
            this.CONBTN.TabIndex = 45;
            this.CONBTN.Text = "Digital Content";
            this.CONBTN.UseVisualStyleBackColor = true;
            this.CONBTN.Click += new System.EventHandler(this.CONBTN_Click);
            // 
            // Home_icon
            // 
            this.Home_icon.Image = global::SoftwareEng2024.Properties.Resources.home;
            this.Home_icon.Location = new System.Drawing.Point(22, 29);
            this.Home_icon.Name = "Home_icon";
            this.Home_icon.Size = new System.Drawing.Size(44, 34);
            this.Home_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Home_icon.TabIndex = 39;
            this.Home_icon.TabStop = false;
            // 
            // ChatBox_Button
            // 
            this.ChatBox_Button.Location = new System.Drawing.Point(72, 124);
            this.ChatBox_Button.Name = "ChatBox_Button";
            this.ChatBox_Button.Size = new System.Drawing.Size(118, 32);
            this.ChatBox_Button.TabIndex = 35;
            this.ChatBox_Button.Text = "ChatBox";
            this.ChatBox_Button.UseVisualStyleBackColor = true;
            // 
            // Chat_icon
            // 
            this.Chat_icon.Image = global::SoftwareEng2024.Properties.Resources.message;
            this.Chat_icon.Location = new System.Drawing.Point(22, 122);
            this.Chat_icon.Name = "Chat_icon";
            this.Chat_icon.Size = new System.Drawing.Size(44, 34);
            this.Chat_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chat_icon.TabIndex = 40;
            this.Chat_icon.TabStop = false;
            // 
            // Event_icon
            // 
            this.Event_icon.Image = global::SoftwareEng2024.Properties.Resources.calendar_check;
            this.Event_icon.Location = new System.Drawing.Point(22, 164);
            this.Event_icon.Name = "Event_icon";
            this.Event_icon.Size = new System.Drawing.Size(44, 34);
            this.Event_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Event_icon.TabIndex = 41;
            this.Event_icon.TabStop = false;
            // 
            // Memebrship_icon
            // 
            this.Memebrship_icon.Image = global::SoftwareEng2024.Properties.Resources.membership;
            this.Memebrship_icon.Location = new System.Drawing.Point(22, 209);
            this.Memebrship_icon.Name = "Memebrship_icon";
            this.Memebrship_icon.Size = new System.Drawing.Size(44, 34);
            this.Memebrship_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Memebrship_icon.TabIndex = 42;
            this.Memebrship_icon.TabStop = false;
            // 
            // Profile
            // 
            this.Profile.Location = new System.Drawing.Point(72, 77);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(118, 34);
            this.Profile.TabIndex = 33;
            this.Profile.Text = "Profile";
            this.Profile.UseVisualStyleBackColor = true;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCoral;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1012, 158);
            this.panel3.TabIndex = 31;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::SoftwareEng2024.Properties.Resources.menu;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(12, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 38);
            this.button2.TabIndex = 11;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(66, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 48);
            this.label4.TabIndex = 10;
            this.label4.Text = "CAMBRIDGE";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(61, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 106);
            this.label2.TabIndex = 9;
            this.label2.Text = "Together \r\nCulture";
            // 
            // dgvMessages
            // 
            this.dgvMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMessages.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessages.Location = new System.Drawing.Point(3, 8);
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.RowHeadersWidth = 51;
            this.dgvMessages.RowTemplate.Height = 24;
            this.dgvMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessages.Size = new System.Drawing.Size(961, 473);
            this.dgvMessages.TabIndex = 22;
            // 
            // lblChatWith
            // 
            this.lblChatWith.AutoSize = true;
            this.lblChatWith.BackColor = System.Drawing.Color.IndianRed;
            this.lblChatWith.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatWith.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblChatWith.Location = new System.Drawing.Point(24, 172);
            this.lblChatWith.Name = "lblChatWith";
            this.lblChatWith.Size = new System.Drawing.Size(114, 31);
            this.lblChatWith.TabIndex = 21;
            this.lblChatWith.Text = "chat with";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(901, 663);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(81, 34);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(21, 663);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(874, 34);
            this.txtMessage.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgvMessages);
            this.panelContent.Location = new System.Drawing.Point(12, 164);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(997, 551);
            this.panelContent.TabIndex = 56;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // memberchat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 715);
            this.Controls.Add(this.panel1);
            this.Name = "memberchat";
            this.Text = "memberchat";
            this.Load += new System.EventHandler(this.memberchat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Profile_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chat_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Event_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Memebrship_icon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblChatWith;
        private DataGridView dgvMessages;
        private Panel panel3;
        private Button button2;
        private Label label4;
        private Label label2;
        private Panel panel2;
        private Button button4;
        private Button Home;
        private Button Membership;
        private PictureBox pictureBox1;
        private PictureBox Profile_icon;
        private Button btnLogout;
        private Button Event;
        private Button CONBTN;
        private PictureBox Home_icon;
        private Button ChatBox_Button;
        private PictureBox Chat_icon;
        private PictureBox Event_icon;
        private PictureBox Memebrship_icon;
        private Button Profile;
        private Timer timer1;
        private Panel panelContent;
    }
}