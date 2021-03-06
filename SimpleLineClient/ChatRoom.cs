﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SimpleLineClient
{
    public partial class ChatRoom : Form
    {
        public GroupInformation groupinfo;
        private NetworkStream stream;
        public User owner;
        private List<Message> readed_message;
        private List<Message> unread_message;

        public NetworkStream Stream
        {
            set
            {
                if (value != null)
                    this.stream = value;
            }
        }

        public ChatRoom(User owner, GroupInformation group, NetworkStream stream)
        {
            InitializeComponent();

            readed_message = new List<Message>();
            unread_message = new List<Message>();

            this.groupinfo = group;
            this.stream = stream;
            this.owner = owner;

            this.Text = group.groupname;
        }

        private void UpdateUI(string message)
        {
            Invoke((MethodInvoker)(delegate
            {
                ChatBox.AppendText(message + "\n");
            }));
        }

        public int GetSizeUnReadMessage()
        {
            return unread_message.Count;
        }

        public void AddUnReadMessage(Message message)
        {
            unread_message.Add(message);
        }

        public void AddReadedMessage(Message message)
        {
            readed_message.Add(message);
            UpdateUI(message.From.Username + "(" + message.From.UserId + ") : " + message.message + "\n\t\t\t" 
                + DateTime.Now.TimeOfDay.Hours.ToString("00") + ":" + DateTime.Now.TimeOfDay.Minutes.ToString("00"));
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.Enter))
            {
                Message message = new Message(owner, groupinfo, ChatMessage.Text, DateTime.Now.TimeOfDay.Hours.ToString("00") 
                    + ":" + DateTime.Now.TimeOfDay.Minutes.ToString("00"));
                MemoryStream mem = new MemoryStream();
                XmlSerializer xml = new XmlSerializer(typeof(Message));
                xml.Serialize(mem, message);
                byte[] buffer = mem.ToArray();
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            Message message = new Message(owner, groupinfo, ChatMessage.Text, DateTime.Now.TimeOfDay.Hours.ToString("00") 
                + ":" + DateTime.Now.TimeOfDay.Minutes.ToString("00"));
            MemoryStream mem = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(Message));
            xml.Serialize(mem, message);
            byte[] buffer = mem.ToArray();
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            ChatMessage.Text = "";
        }

        private void MessageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                ChatMessage.Text = "";
            }
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void ChatRoom_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ChatBox.Clear();

                foreach (Message m in readed_message)
                {
                    UpdateUI(m.From.Username + "(" + m.From.UserId + ") : " + m.message + "\n\t\t\t" 
                        + DateTime.Now.TimeOfDay.Hours.ToString("00") + ":" + DateTime.Now.TimeOfDay.Minutes.ToString("00"));
                }

                if (unread_message.Count > 0)
                    UpdateUI("========UNREAD========");

                foreach (Message m in unread_message)
                {
                    AddReadedMessage(m);
                }
                unread_message.Clear();
            }
        }

        private void ChatRoom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 60 && e.X >= this.Width - 66)
            {
                if (MessageBox.Show("You want to leave group?", "LeaveGroup", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                XmlSerializer xml = new XmlSerializer(typeof(GroupInformation));
                MemoryStream mem = new MemoryStream();

                groupinfo.command = (int)GroupInformation.operation.Leave;
                groupinfo.user = this.owner;

                xml.Serialize(mem, groupinfo);
                byte[] buffer = mem.ToArray();

                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        private void ChatRoom_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int constant = -16;
            Font font_title = new Font("comic sans ms", 20);

            // Titlebar
            g.FillRectangle(Brushes.ForestGreen, 0, 0, this.Width + constant, 60);
            g.DrawImage(Image.FromFile("./res/img/leavegroup_icon.png"), this.Width + constant - 50, 8, 45, 45);
            g.DrawString(groupinfo.groupname + " (ID : " + groupinfo.groupid + ")", font_title, Brushes.White, 
                new RectangleF(20, 10, this.Width + constant - 50, 60));
        }
    }
}
