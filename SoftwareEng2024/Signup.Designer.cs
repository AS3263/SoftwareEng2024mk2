namespace SoftwareEng2024
{
    partial class Signup
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
            this.button1 = new System.Windows.Forms.Button();
            this.learnmore1 = new System.Windows.Forms.Button();
            this.cmbInterests = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMembershipType = new System.Windows.Forms.ComboBox();
            this.lnkReturnToMain = new System.Windows.Forms.LinkLabel();
            this.btnToggleConfirmPassword = new System.Windows.Forms.Button();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSignup = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::SoftwareEng2024.Properties.Resources.toghther_culter;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 726);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.learnmore1);
            this.panel2.Controls.Add(this.cmbInterests);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbMembershipType);
            this.panel2.Controls.Add(this.lnkReturnToMain);
            this.panel2.Controls.Add(this.btnToggleConfirmPassword);
            this.panel2.Controls.Add(this.btnTogglePassword);
            this.panel2.Controls.Add(this.lblLogo);
            this.panel2.Controls.Add(this.txtConfirmPassword);
            this.panel2.Controls.Add(this.btnSignup);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.lnkLogin);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.lblEmail);
            this.panel2.Controls.Add(this.lblPassword);
            this.panel2.Controls.Add(this.lblConfirmPassword);
            this.panel2.Location = new System.Drawing.Point(298, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 583);
            this.panel2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(502, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 27);
            this.button1.TabIndex = 21;
            this.button1.Text = "Learn More";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // learnmore1
            // 
            this.learnmore1.Location = new System.Drawing.Point(502, 327);
            this.learnmore1.Name = "learnmore1";
            this.learnmore1.Size = new System.Drawing.Size(98, 30);
            this.learnmore1.TabIndex = 20;
            this.learnmore1.Text = "Learn More";
            this.learnmore1.UseVisualStyleBackColor = true;
            this.learnmore1.Click += new System.EventHandler(this.learnmore1_Click);
            // 
            // cmbInterests
            // 
            this.cmbInterests.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbInterests.FormattingEnabled = true;
            this.cmbInterests.Location = new System.Drawing.Point(168, 375);
            this.cmbInterests.Name = "cmbInterests";
            this.cmbInterests.Size = new System.Drawing.Size(328, 24);
            this.cmbInterests.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(20, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Choose interest";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(20, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 52);
            this.label1.TabIndex = 17;
            this.label1.Text = "Choose Membership Type";
            // 
            // cmbMembershipType
            // 
            this.cmbMembershipType.FormattingEnabled = true;
            this.cmbMembershipType.Location = new System.Drawing.Point(168, 333);
            this.cmbMembershipType.Name = "cmbMembershipType";
            this.cmbMembershipType.Size = new System.Drawing.Size(328, 24);
            this.cmbMembershipType.TabIndex = 16;
            // 
            // lnkReturnToMain
            // 
            this.lnkReturnToMain.AutoSize = true;
            this.lnkReturnToMain.Location = new System.Drawing.Point(286, 512);
            this.lnkReturnToMain.Name = "lnkReturnToMain";
            this.lnkReturnToMain.Size = new System.Drawing.Size(92, 16);
            this.lnkReturnToMain.TabIndex = 15;
            this.lnkReturnToMain.TabStop = true;
            this.lnkReturnToMain.Text = "Return to Main";
            this.lnkReturnToMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturnToMain_LinkClicked);
            // 
            // btnToggleConfirmPassword
            // 
            this.btnToggleConfirmPassword.Location = new System.Drawing.Point(502, 272);
            this.btnToggleConfirmPassword.Name = "btnToggleConfirmPassword";
            this.btnToggleConfirmPassword.Size = new System.Drawing.Size(75, 30);
            this.btnToggleConfirmPassword.TabIndex = 14;
            this.btnToggleConfirmPassword.Text = "Show";
            this.btnToggleConfirmPassword.UseVisualStyleBackColor = true;
            this.btnToggleConfirmPassword.Click += new System.EventHandler(this.btnToggleConfirmPassword_Click);
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.Location = new System.Drawing.Point(502, 223);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(75, 30);
            this.btnTogglePassword.TabIndex = 13;
            this.btnTogglePassword.Text = "Show";
            this.btnTogglePassword.UseVisualStyleBackColor = true;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Impact", 25.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(245, 11);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(150, 52);
            this.lblLogo.TabIndex = 12;
            this.lblLogo.Text = "Sign up";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(170, 272);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(326, 30);
            this.txtConfirmPassword.TabIndex = 9;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // btnSignup
            // 
            this.btnSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSignup.Location = new System.Drawing.Point(276, 426);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(102, 42);
            this.btnSignup.TabIndex = 10;
            this.btnSignup.Text = "Sign Up";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(170, 223);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(326, 30);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Location = new System.Drawing.Point(229, 485);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(201, 16);
            this.lnkLogin.TabIndex = 11;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Already have an account? Log In";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(170, 177);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(326, 30);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(170, 128);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(326, 30);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(170, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(326, 30);
            this.txtName.TabIndex = 5;
            this.txtName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsername.Location = new System.Drawing.Point(78, 138);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 20);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            this.lblUsername.Click += new System.EventHandler(this.PlaceholderLabel_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.LightGray;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Location = new System.Drawing.Point(111, 87);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.PlaceholderLabel_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(111, 187);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            this.lblEmail.Click += new System.EventHandler(this.PlaceholderLabel_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPassword.Location = new System.Drawing.Point(78, 233);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(83, 20);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.PlaceholderLabel_Click);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblConfirmPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConfirmPassword.Location = new System.Drawing.Point(70, 272);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(92, 48);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Confirm Password";
            this.lblConfirmPassword.Click += new System.EventHandler(this.PlaceholderLabel_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 726);
            this.Controls.Add(this.panel1);
            this.Name = "Signup";
            this.Text = "Signup";
            this.Load += new System.EventHandler(this.Signup_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.LinkLabel lnkLogin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnToggleConfirmPassword;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.LinkLabel lnkReturnToMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMembershipType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button learnmore1;
        private System.Windows.Forms.ComboBox cmbInterests;
    }
}