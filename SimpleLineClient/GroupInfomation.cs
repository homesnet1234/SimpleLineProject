using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLineClient
{
    public class GroupInformation
    {
        public User user;
        public string groupname;
        public string groupid;

        public GroupInformation()
        {

        }

        public GroupInformation(User user)
        {
            this.user = user;
        }
    }
}
