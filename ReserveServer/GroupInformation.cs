using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveServer
{
    public class GroupInformation
    {
        public User user;
        public string groupname;
        public string groupid;
        public int command;
        public enum operation { Create, Join, Leave };

        public GroupInformation()
        {

        }

        public GroupInformation(User user)
        {
            this.user = user;
        }
    }
}
