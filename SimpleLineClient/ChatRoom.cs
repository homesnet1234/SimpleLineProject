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
        private User owner;
        private List<Message> readed_message;
        private List<Message> unread_message;

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

        public void AddUnReadMessage(Message message)
        {
            unread_message.Add(message);
        }

        public void AddReadedMessage(Message message)
        {
            readed_message.Add(message);
            UpdateUI(message.From.Username + " : " + message.message);
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.Enter))
            {
                Message message = new Message(owner, groupinfo, MessageBox.Text);
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
            Message message = new Message(owner, groupinfo, MessageBox.Text);
            MemoryStream mem = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(Message));
            xml.Serialize(mem, message);
            byte[] buffer = mem.ToArray();
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            MessageBox.Text = "";
        }

        private void MessageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                MessageBox.Text = "";
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
                    UpdateUI(m.From.Username + " : " + m.message);
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
    }
}