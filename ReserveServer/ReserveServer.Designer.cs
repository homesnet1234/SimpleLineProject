namespace ReserveServer
{
    partial class ReserveServer
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
            this.SuspendLayout();
            // 
            // OnlineList
            // 
            this.OnlineList.Location = new System.Drawing.Point(12, 12);
            this.OnlineList.Name = "OnlineList";
            this.OnlineList.Size = new System.Drawing.Size(260, 423);
            this.OnlineList.TabIndex = 0;
            this.OnlineList.Text = "";
            // 
            // ReserveServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 447);
            this.Controls.Add(this.OnlineList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReserveServer";
            this.Text = "ReserveServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReserveServer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox OnlineList;
    }
}

