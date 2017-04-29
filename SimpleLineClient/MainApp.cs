using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace SimpleLineClient
{
    public partial class MainApp : Form
    {
        private TcpClient client;
        private User user;
        private NetworkStream stream;
        private List<ChatRoom> rooms;
        private int chat_startpoint = 60;

        public MainApp()
        {
            InitializeComponent();
            this.MouseWheel += Form1_MouseWheel;

            client = new TcpClient("169.254.53.150", 8888);
            rooms = new List<ChatRoom>();
            stream = client.GetStream();

            Form startForm = new StartForm();
            startForm.ShowDialog();

            user = new User();

            if (!string.IsNullOrEmpty(StartForm.userid))
                user.UserId = StartForm.userid;
            else
                user.Username = StartForm.username;

            XmlSerializer xml = new XmlSerializer(typeof(User));
            MemoryStream mem = new MemoryStream();

            xml.Serialize(mem, user);
            byte[] buffer = mem.ToArray();

            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            Thread networkthread = new Thread(NetworkManager);
            networkthread.Start();
        }

        private void NetworkManager()
        {
            XmlSerializer xml;
            MemoryStream mem;

            while (stream.CanRead)
            {
                byte[] buffer = new byte[1000000];
                try
                {
                    stream.Read(buffer, 0, buffer.Length);
                }
                catch (Exception)
                {
                    break;
                }

                mem = new MemoryStream(buffer);
                XmlReader reader = XmlReader.Create(new MemoryStream(buffer));

                // User
                xml = new XmlSerializer(typeof(User));
                if (xml.CanDeserialize(reader))
                {
                    User user = xml.Deserialize(mem) as User;
                    this.user = user;

                    continue;
                }

                // Message
                xml = new XmlSerializer(typeof(Message));
                if (xml.CanDeserialize(reader))
                {
                    Message message = xml.Deserialize(mem) as Message;

                    foreach (ChatRoom r in rooms)
                    {
                        if (r.groupinfo.groupid == message.To.groupid)
                        {
                            if (r.Visible)
                                r.AddReadedMessage(message);
                            else
                            {
                                r.AddUnReadMessage(message);
                                Invoke((MethodInvoker)(() => this.Refresh()));
                            }
                        }
                    }

                    continue;
                }

                // GroupInfomation
                xml = new XmlSerializer(typeof(GroupInformation));
                if (xml.CanDeserialize(reader))
                {
                    GroupInformation groupinfo = xml.Deserialize(mem) as GroupInformation;

                    // Create ChatRoom
                    ChatRoom room = new ChatRoom(user, groupinfo, stream);
                    rooms.Add(room);

                    Invoke((MethodInvoker)(() => this.Refresh()));

                    continue;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("tahoma", 18);

            for (int i = 0; i < rooms.Count; i++)
            {
                g.DrawImage(Image.FromFile("./res/img/group_icon_deflaut.png"), 6, 6 + chat_startpoint + 80 * i, 71, 71);
                g.DrawLine(Pens.LightGray, 90, chat_startpoint + (i + 1) * 80, this.Width - this.PreferredSize.Width, chat_startpoint + (i + 1) * 80);
                g.DrawString(rooms[i].groupinfo.groupname + " : " + rooms[i].groupinfo.groupid, font, Brushes.Black,
                    new RectangleF(90, chat_startpoint + 10 + 80 * i, this.Width - this.PreferredSize.Width, 80));
                if (rooms[i].GetSizeUnReadMessage() > 0)
                {
                    g.FillEllipse(Brushes.Red, this.Width - this.PreferredSize.Width - 50, chat_startpoint + 50 + 80 * i, 20, 20);
                    g.DrawEllipse(Pens.Red, this.Width - this.PreferredSize.Width - 50, chat_startpoint + 50 + 80 * i, 20, 20);
                }
            }

            // TitleBar Color
            g.FillRectangle(Brushes.ForestGreen, 0, 0, this.Width - this.PreferredSize.Width, 60);
            g.DrawImage(Image.FromFile("./res/img/addfriend_icon.png"), this.Width - this.PreferredSize.Width - 45, 12, 40, 40);
            g.DrawString(user.Username, font, Brushes.White, new RectangleF(20, 15, this.Width - this.PreferredSize.Width - 45, 60));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y <= 60 && e.X >= this.Width - this.PreferredSize.Width - 45)
            {
                GroupForm groupform = new GroupForm();
                if (groupform.ShowDialog() != DialogResult.OK)
                    return;

                GroupInformation groupinfo = new GroupInformation(this.user);
                XmlSerializer xml = new XmlSerializer(typeof(GroupInformation));
                MemoryStream mem = new MemoryStream();

                if (!string.IsNullOrEmpty(groupform.groupid))
                {
                    groupinfo.groupid = groupform.groupid;
                    xml.Serialize(mem, groupinfo);

                    byte[] buffer = mem.ToArray();

                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
                else
                {
                    groupinfo.groupname = groupform.groupname;
                    xml.Serialize(mem, groupinfo);

                    byte[] buffer = mem.ToArray();

                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
            }
            else if (e.Y > 60)
            {
                if (e.Y > rooms.Count * 80 + 60)
                    return;

                rooms[(e.Y - chat_startpoint) / 80].Show();
            }

            this.Refresh();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (rooms.Count * 80 < this.Height - this.PreferredSize.Height - 60)
                return;

            if (e.Delta < 0 && chat_startpoint + rooms.Count * 80 >= this.Height - this.PreferredSize.Height)
                chat_startpoint -= 20;
            else if (e.Delta > 0 && chat_startpoint < 60)
                chat_startpoint += 20;

            this.Refresh();
        }

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            stream.Close();
            client.Close();

            e.Cancel = false;
        }

    }
}
