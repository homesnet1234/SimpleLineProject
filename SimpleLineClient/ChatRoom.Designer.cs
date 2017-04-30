namespace SimpleLineClient
{
    partial class ChatRoom
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
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.ChatMessage = new System.Windows.Forms.RichTextBox();
            this.Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatBox.Location = new System.Drawing.Point(-1, 59);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(471, 346);
            this.ChatBox.TabIndex = 0;
            this.ChatBox.Text = "";
            // 
            // ChatMessage
            // 
            this.ChatMessage.Location = new System.Drawing.Point(-1, 406);
            this.ChatMessage.Name = "ChatMessage";
            this.ChatMessage.Size = new System.Drawing.Size(416, 59);
            this.ChatMessage.TabIndex = 1;
            this.ChatMessage.Text = "";
            this.ChatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyDown);
            this.ChatMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyUp);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(412, 405);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(50, 59);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 461);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.ChatMessage);
            this.Controls.Add(this.ChatBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatRoom_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.ChatRoom_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatRoom_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChatRoom_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.RichTextBox ChatMessage;
        private System.Windows.Forms.Button Send;
    }
}