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
    public partial class StartForm : Form
    {
        public static string username;
        public static string userid;

        public StartForm()
        {
            InitializeComponent();
        }

        private void LoginSelect_Click(object sender, EventArgs e)
        {
            SelectPanel.Visible = false;
            LoginPanel.Visible = true;
        }

        private void RegisterSelect_Click(object sender, EventArgs e)
        {
            SelectPanel.Visible = false;
            RegisterPanel.Visible = true;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            StartForm.userid = UserID.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            StartForm.username = Username.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
