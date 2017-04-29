namespace SimpleLineClient
{
    partial class StartForm
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
            this.Register = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RegisterPanel = new System.Windows.Forms.Panel();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.Login = new System.Windows.Forms.Button();
            this.UserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectPanel = new System.Windows.Forms.Panel();
            this.LoginSelect = new System.Windows.Forms.Button();
            this.RegisterSelect = new System.Windows.Forms.Button();
            this.RegisterPanel.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            this.SelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(145, 36);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 0;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(73, 10);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(147, 20);
            this.Username.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username : ";
            // 
            // RegisterPanel
            // 
            this.RegisterPanel.Controls.Add(this.label1);
            this.RegisterPanel.Controls.Add(this.Register);
            this.RegisterPanel.Controls.Add(this.Username);
            this.RegisterPanel.Location = new System.Drawing.Point(12, 12);
            this.RegisterPanel.Name = "RegisterPanel";
            this.RegisterPanel.Size = new System.Drawing.Size(240, 82);
            this.RegisterPanel.TabIndex = 3;
            this.RegisterPanel.Visible = false;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.Login);
            this.LoginPanel.Controls.Add(this.UserID);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Location = new System.Drawing.Point(12, 12);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(240, 82);
            this.LoginPanel.TabIndex = 3;
            this.LoginPanel.Visible = false;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(145, 36);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 2;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // UserID
            // 
            this.UserID.Location = new System.Drawing.Point(58, 10);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(162, 20);
            this.UserID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserID : ";
            // 
            // SelectPanel
            // 
            this.SelectPanel.Controls.Add(this.RegisterSelect);
            this.SelectPanel.Controls.Add(this.LoginSelect);
            this.SelectPanel.Location = new System.Drawing.Point(12, 12);
            this.SelectPanel.Name = "SelectPanel";
            this.SelectPanel.Size = new System.Drawing.Size(240, 82);
            this.SelectPanel.TabIndex = 3;
            // 
            // LoginSelect
            // 
            this.LoginSelect.Location = new System.Drawing.Point(23, 13);
            this.LoginSelect.Name = "LoginSelect";
            this.LoginSelect.Size = new System.Drawing.Size(197, 23);
            this.LoginSelect.TabIndex = 0;
            this.LoginSelect.Text = "Login";
            this.LoginSelect.UseVisualStyleBackColor = true;
            this.LoginSelect.Click += new System.EventHandler(this.LoginSelect_Click);
            // 
            // RegisterSelect
            // 
            this.RegisterSelect.Location = new System.Drawing.Point(23, 42);
            this.RegisterSelect.Name = "RegisterSelect";
            this.RegisterSelect.Size = new System.Drawing.Size(197, 23);
            this.RegisterSelect.TabIndex = 1;
            this.RegisterSelect.Text = "Register";
            this.RegisterSelect.UseVisualStyleBackColor = true;
            this.RegisterSelect.Click += new System.EventHandler(this.RegisterSelect_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 107);
            this.Controls.Add(this.SelectPanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.RegisterPanel);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.RegisterPanel.ResumeLayout(false);
            this.RegisterPanel.PerformLayout();
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.SelectPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel RegisterPanel;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox UserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel SelectPanel;
        private System.Windows.Forms.Button RegisterSelect;
        private System.Windows.Forms.Button LoginSelect;
    }
}