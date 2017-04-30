namespace SimpleLineClient
{
    partial class GroupForm
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
            this.CreatePanel = new System.Windows.Forms.Panel();
            this.Create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Groupname = new System.Windows.Forms.TextBox();
            this.JoinPanel = new System.Windows.Forms.Panel();
            this.Join = new System.Windows.Forms.Button();
            this.Groupid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectPanel = new System.Windows.Forms.Panel();
            this.JoinSelect = new System.Windows.Forms.Button();
            this.CreateSelect = new System.Windows.Forms.Button();
            this.CreatePanel.SuspendLayout();
            this.JoinPanel.SuspendLayout();
            this.SelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreatePanel
            // 
            this.CreatePanel.Controls.Add(this.Create);
            this.CreatePanel.Controls.Add(this.label1);
            this.CreatePanel.Controls.Add(this.Groupname);
            this.CreatePanel.Location = new System.Drawing.Point(12, 12);
            this.CreatePanel.Name = "CreatePanel";
            this.CreatePanel.Size = new System.Drawing.Size(260, 88);
            this.CreatePanel.TabIndex = 0;
            this.CreatePanel.Visible = false;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(167, 42);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 2;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Groupname : ";
            // 
            // Groupname
            // 
            this.Groupname.Location = new System.Drawing.Point(90, 16);
            this.Groupname.Name = "Groupname";
            this.Groupname.Size = new System.Drawing.Size(152, 20);
            this.Groupname.TabIndex = 0;
            // 
            // JoinPanel
            // 
            this.JoinPanel.Controls.Add(this.Join);
            this.JoinPanel.Controls.Add(this.Groupid);
            this.JoinPanel.Controls.Add(this.label2);
            this.JoinPanel.Location = new System.Drawing.Point(12, 12);
            this.JoinPanel.Name = "JoinPanel";
            this.JoinPanel.Size = new System.Drawing.Size(260, 88);
            this.JoinPanel.TabIndex = 1;
            this.JoinPanel.Visible = false;
            // 
            // Join
            // 
            this.Join.Location = new System.Drawing.Point(167, 43);
            this.Join.Name = "Join";
            this.Join.Size = new System.Drawing.Size(75, 23);
            this.Join.TabIndex = 2;
            this.Join.Text = "Join";
            this.Join.UseVisualStyleBackColor = true;
            this.Join.Click += new System.EventHandler(this.Join_Click);
            // 
            // Groupid
            // 
            this.Groupid.Location = new System.Drawing.Point(90, 17);
            this.Groupid.Name = "Groupid";
            this.Groupid.Size = new System.Drawing.Size(152, 20);
            this.Groupid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Groupid : ";
            // 
            // SelectPanel
            // 
            this.SelectPanel.Controls.Add(this.JoinSelect);
            this.SelectPanel.Controls.Add(this.CreateSelect);
            this.SelectPanel.Location = new System.Drawing.Point(12, 12);
            this.SelectPanel.Name = "SelectPanel";
            this.SelectPanel.Size = new System.Drawing.Size(260, 88);
            this.SelectPanel.TabIndex = 1;
            // 
            // JoinSelect
            // 
            this.JoinSelect.Location = new System.Drawing.Point(31, 51);
            this.JoinSelect.Name = "JoinSelect";
            this.JoinSelect.Size = new System.Drawing.Size(193, 23);
            this.JoinSelect.TabIndex = 1;
            this.JoinSelect.Text = "JoinGroup";
            this.JoinSelect.UseVisualStyleBackColor = true;
            this.JoinSelect.Click += new System.EventHandler(this.JoinSelect_Click);
            // 
            // CreateSelect
            // 
            this.CreateSelect.Location = new System.Drawing.Point(31, 16);
            this.CreateSelect.Name = "CreateSelect";
            this.CreateSelect.Size = new System.Drawing.Size(193, 23);
            this.CreateSelect.TabIndex = 0;
            this.CreateSelect.Text = "CreateGroup";
            this.CreateSelect.UseVisualStyleBackColor = true;
            this.CreateSelect.Click += new System.EventHandler(this.CreateSelect_Click);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 112);
            this.Controls.Add(this.SelectPanel);
            this.Controls.Add(this.CreatePanel);
            this.Controls.Add(this.JoinPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GroupForm";
            this.CreatePanel.ResumeLayout(false);
            this.CreatePanel.PerformLayout();
            this.JoinPanel.ResumeLayout(false);
            this.JoinPanel.PerformLayout();
            this.SelectPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CreatePanel;
        private System.Windows.Forms.Panel JoinPanel;
        private System.Windows.Forms.Button Join;
        private System.Windows.Forms.TextBox Groupid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Groupname;
        private System.Windows.Forms.Panel SelectPanel;
        private System.Windows.Forms.Button JoinSelect;
        private System.Windows.Forms.Button CreateSelect;
    }
}