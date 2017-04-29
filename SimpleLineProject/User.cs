using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLineProject
{
    public class User
    {
        private string username;
        private string userid;
        public bool online = true;
        public List<GroupInformation> groupinfoes;

        public string UserId
        {
            get
            {
                return userid;
            }
            set
            {
                this.userid = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public User()
        {
            groupinfoes = new List<GroupInformation>();
        }

        public User(string username) : this()
        {
            this.username = username;
        }
    }
}
