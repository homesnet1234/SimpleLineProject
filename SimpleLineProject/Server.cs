using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace SimpleLineProject
{
    public partial class Server : Form
    {
        TcpListener list;
        bool isOnline;
        List<User> users;
        List<Group> groups;
        Dictionary<string, NetworkStream> clientUsers;
        Queue<Tuple<User, Message>> message_buffer; // message for offline user, send when user online

        public Server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isOnline = false;
            Online.Enabled = true;
            Offline.Enabled = false;

            list.Stop();
        }

        private void Online_Click(object sender, EventArgs e)
        {
            message_buffer = new Queue<Tuple<User, Message>>();
            users = new List<User>();
            groups = new List<Group>();
            clientUsers = new Dictionary<string, NetworkStream>();
            UpdateUI();

            isOnline = true;
            Online.Enabled = false;
            Offline.Enabled = true;

            list = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
            list.Start();

            Thread t1 = new Thread(new ThreadStart(WaitForConnect));
            t1.Start();
        }

        // update status of user and group
        private void UpdateUI()
        {
            Invoke((MethodInvoker)delegate
            {
                if (!isOnline)
                    return;

                OnlineList.Clear();

                foreach (User u in users)
                {
                    if (!u.online)
                        continue;
                    OnlineList.AppendText(u.UserId + " " + u.Username);
                    OnlineList.AppendText("\n");
                }

                foreach (Group g in groups)
                {
                    OnlineList.AppendText(g.groupid + " " + g.groupname + " " + g.GetSizeOfMembers());
                    OnlineList.AppendText("\n");

                    for (int i = 0; i < g.GetSizeOfMembers(); i++)
                    {
                        OnlineList.AppendText("\t" + g.GetMember(i).UserId + " " + g.GetMember(i).Username + " " + g.GetMember(i).online);
                        OnlineList.AppendText("\n");
                    }
                }
            });
        }

        // wait use connect to server
        private void WaitForConnect()
        {
            while (isOnline)
            {
                TcpClient client = null;
                try
                {
                    client = list.AcceptTcpClient();

                    Thread t1 = new Thread(new ParameterizedThreadStart(ClientManage));
                    t1.IsBackground = true;
                    t1.Start(client);
                }
                catch (SocketException)
                {
                    if (client != null)
                        client.Close();
                }
            }
        }

        // manage each user that online
        private void ClientManage(object obj)
        {
            TcpClient client = obj as TcpClient;
            NetworkStream stream = client.GetStream();
            User user = null;

            try
            {
                while (stream.CanRead && isOnline)
                {
                    byte[] buffer = new byte[1000000];
                    stream.Read(buffer, 0, buffer.Length);
                    
                    XmlSerializer xml;
                    MemoryStream mem = new MemoryStream(buffer);
                    XmlReader reader = XmlReader.Create(new MemoryStream(buffer));

                    // User
                    xml = new XmlSerializer(typeof(User));
                    if (xml.CanDeserialize(reader))
                    {
                        user = xml.Deserialize(mem) as User;

                        if (string.IsNullOrEmpty(user.UserId))
                        {
                            user.UserId = users.Count.ToString("00000");
                            users.Add(user);
                            UpdateUI();
                        }
                        else
                        {
                            user = users[Int32.Parse(user.UserId)];
                            users[Int32.Parse(user.UserId)].online = true;
                            UpdateUI();
                        }

                        clientUsers.Add(user.UserId, stream);
                        mem = new MemoryStream();
                        xml.Serialize(mem, user);
                        buffer = mem.ToArray();

                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();


                        xml = new XmlSerializer(typeof(GroupInformation));
                        foreach (GroupInformation gin in users[Int32.Parse(user.UserId)].groupinfoes)
                        {
                            mem = new MemoryStream();
                            xml.Serialize(mem, gin);
                            buffer = mem.ToArray();

                            Thread.Sleep(50);
                            stream.Write(buffer, 0, buffer.Length);
                            stream.Flush();
                        }

                        xml = new XmlSerializer(typeof(Message));
                        lock (message_buffer)
                        {
                            for (int i = 0; i < message_buffer.Count; i++)
                            {
                                Tuple<User, Message> m_b = message_buffer.Dequeue();
                                User u = m_b.Item1;
                                Message m = m_b.Item2;

                                if (user.Equals(u))
                                {
                                    mem = new MemoryStream();
                                    xml.Serialize(mem, m);
                                    buffer = mem.ToArray();

                                    Thread.Sleep(50);
                                    stream.Write(buffer, 0, buffer.Length);
                                    stream.Flush();
                                }
                            }
                        }

                        continue;
                    }

                    // GroupInformation
                    xml = new XmlSerializer(typeof(GroupInformation));
                    if (xml.CanDeserialize(reader))
                    {
                        GroupInformation groupinfo = xml.Deserialize(mem) as GroupInformation;

                        if (string.IsNullOrEmpty(groupinfo.groupid))
                        {
                            groupinfo.groupid = groups.Count.ToString("00000");
                            Group group = new Group();
                            group.groupid = groupinfo.groupid;
                            group.groupname = groupinfo.groupname;
                            groups.Add(group);
                        }
                        else
                        {
                            groupinfo.groupname = groups[Int32.Parse(groupinfo.groupid)].groupname;
                            groupinfo.groupid = string.Format("00000", groupinfo.groupid);
                        }

                        users[Int32.Parse(groupinfo.user.UserId)].groupinfoes.Add(groupinfo);
                        groups[Int32.Parse(groupinfo.groupid)].AddMember(users[Int32.Parse(groupinfo.user.UserId)]);
                        UpdateUI();

                        mem = new MemoryStream();
                        xml.Serialize(mem, groupinfo);
                        buffer = mem.ToArray();

                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();

                        continue;
                    }

                    // Message
                    xml = new XmlSerializer(typeof(Message));
                    if (xml.CanDeserialize(reader))
                    {
                        Message message = xml.Deserialize(mem) as Message;
                        Group group = groups[Int32.Parse(message.To.groupid)];

                        for (int i = 0; i < group.GetSizeOfMembers(); i++)
                        {
                            User u = group.GetMember(i);
                            if (u.online)
                            {
                                NetworkStream st = clientUsers[u.UserId];
                                mem = new MemoryStream();
                                xml.Serialize(mem, message);
                                buffer = mem.ToArray();

                                Thread.Sleep(50);
                                st.Write(buffer, 0, buffer.Length);
                                st.Flush();
                            }
                            else
                                message_buffer.Enqueue(new Tuple<User, Message>(u, message));

                        }
                    }
                }
            }
            catch (Exception)
            {
                clientUsers.Remove(user.UserId);
                users[Int32.Parse(user.UserId)].online = false;
                stream.Close();
                client.Close();
                UpdateUI();
            }
            finally
            {
                clientUsers.Remove(user.UserId);
                users[Int32.Parse(user.UserId)].online = false;
                stream.Close();
                client.Close();
                UpdateUI();
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            isOnline = false;
            if (list != null)
                list.Stop();

            e.Cancel = false;
        }
    }
}
