using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveServer
{
    class Group
    {
        public string groupname;
        public string groupid;
        private List<User> members;

        public Group()
        {
            members = new List<User>();
        }

        public Group(string groupname) : this()
        {
            this.groupname = groupname;
        }

        public void AddMember(User member)
        {
            members.Add(member);
        }

        public User GetMember(int index)
        {
            return members[index];
        }

        public int GetSizeOfMembers()
        {
            return members.Count;
        }

        public void RemoveMember(User member)
        {
            members.Remove(member);
        }
    }
}
