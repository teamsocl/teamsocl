using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamsocl
{
    class Message
    {
        public int mid;
        public int fromuid;
        public int touid;
        public EventHandler.Event EventType;
        public string message;
        public bool resolved;
        public DateTime dtg;

        public Message()
        {
            this.mid = 0;
            this.fromuid = 0;
            this.touid = 0;
            this.EventType = EventHandler.Event.mail;
            this.message = "";
            this.resolved = false;
            this.dtg = DateTime.Now;
        }
    }
}
