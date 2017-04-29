namespace SimpleLineProject
{
    partial class Server
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
            this.OnlineList = new System.Windows.Forms.RichTextBox();
            this.Offline = new System.Windows.Forms.Button();
            this.Online = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OnlineList
            // 
            this.OnlineList.Location = new System.Drawing.Point(12, 12);
            this.OnlineList.Name = "OnlineList";
            this.OnlineList.Size = new System.Drawing.Size(263, 438);
            this.OnlineList.TabIndex = 0;
            this.OnlineList.Text = "";
            // 
            // Offline
            // 
            this.Offline.Enabled = false;
            this.Offline.Location = new System.Drawing.Point(200, 456);
            this.Offline.Name = "Offline";
            this.Offline.Size = new System.Drawing.Size(75, 23);
            this.Offline.TabIndex = 1;
            this.Offline.Text = "Offline";
            this.Offline.UseVisualStyleBackColor = true;
            this.Offline.Click += new System.EventHandler(this.button1_Click);
            // 
            // Online
            // 
            this.Online.Location = new System.Drawing.Point(119, 456);
            this.Online.Name = "Online";
            this.Online.Size = new System.Drawing.Size(75, 23);
            this.Online.TabIndex = 2;
            this.Online.Text = "Online";
            this.Online.UseVisualStyleBackColor = true;
            this.Online.Click += new System.EventHandler(this.Online_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 491);
            this.Controls.Add(this.Online);
            this.Controls.Add(this.Offline);
            this.Controls.Add(this.OnlineList);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox OnlineList;
        private System.Windows.Forms.Button Offline;
        private System.Windows.Forms.Button Online;
    }
}

