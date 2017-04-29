using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLineProject
{
    public class Message
    {
        public string message;
        public User from;
        public GroupInformation to;
        public string time;

        public User From
        {
            get
            {
                return this.from;
            }
        }


        public GroupInformation To
        {
            get
            {
                return this.to;
            }
        }

        public Message()
        {

        }

        public Message(User from, GroupInformation to, string message, string time)
        {
            this.from = from;
            this.to = to;
            this.message = message;
            this.time = time;
        }
    }
}
