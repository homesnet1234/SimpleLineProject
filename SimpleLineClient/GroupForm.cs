using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleLineClient
{
    public partial class GroupForm : Form
    {
        public string groupname;
        public string groupid;
        public bool result;

        public GroupForm()
        {
            InitializeComponent();
            result = false;
        }

        private void CreateSelect_Click(object sender, EventArgs e)
        {
            SelectPanel.Visible = false;
            CreatePanel.Visible = true;
        }

        private void JoinSelect_Click(object sender, EventArgs e)
        {
            SelectPanel.Visible = false;
            JoinPanel.Visible = true;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            this.groupname = Groupname.Text;
            this.groupid = "";
            this.result = true;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void Join_Click(object sender, EventArgs e)
        {
            this.groupname = "";
            this.groupid = Groupid.Text;
            this.result = true;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
