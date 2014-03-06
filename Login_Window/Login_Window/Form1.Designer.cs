namespace Login_Window
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerLink = new System.Windows.Forms.LinkLabel();
            this.productLogo = new System.Windows.Forms.PictureBox();
            this.loginEmail = new System.Windows.Forms.Label();
            this.loginPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(180, 349);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(246, 20);
            this.usernameTextbox.TabIndex = 0;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(180, 375);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(246, 20);
            this.passwordTextbox.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(360, 407);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(66, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // registerLink
            // 
            this.registerLink.AutoSize = true;
            this.registerLink.Location = new System.Drawing.Point(177, 412);
            this.registerLink.Name = "registerLink";
            this.registerLink.Size = new System.Drawing.Size(129, 13);
            this.registerLink.TabIndex = 3;
            this.registerLink.TabStop = true;
            this.registerLink.Text = "Not registered? Click here";
            // 
            // productLogo
            // 
            this.productLogo.Image = global::Login_Window.Properties.Resources.Team_Social;
            this.productLogo.Location = new System.Drawing.Point(15, 12);
            this.productLogo.Name = "productLogo";
            this.productLogo.Size = new System.Drawing.Size(594, 316);
            this.productLogo.TabIndex = 4;
            this.productLogo.TabStop = false;
            // 
            // loginEmail
            // 
            this.loginEmail.AutoSize = true;
            this.loginEmail.Location = new System.Drawing.Point(118, 356);
            this.loginEmail.Name = "loginEmail";
            this.loginEmail.Size = new System.Drawing.Size(32, 13);
            this.loginEmail.TabIndex = 5;
            this.loginEmail.Text = "Email";
            // 
            // loginPassword
            // 
            this.loginPassword.AutoSize = true;
            this.loginPassword.Location = new System.Drawing.Point(118, 382);
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(53, 13);
            this.loginPassword.TabIndex = 6;
            this.loginPassword.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 455);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.loginEmail);
            this.Controls.Add(this.productLogo);
            this.Controls.Add(this.registerLink);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Team Socl";
            ((System.ComponentModel.ISupportInitialize)(this.productLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.LinkLabel registerLink;
        private System.Windows.Forms.PictureBox productLogo;
        private System.Windows.Forms.Label loginEmail;
        private System.Windows.Forms.Label loginPassword;
    }
}

