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

        public Emailer mail = new Emailer;

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

        public void teamjoinreq(string cname, string tname)
        {
            mail.emailer()
        }
        public void jointeamack()
        {
            // send an email off to the player, saying that 'cname' has accepted and you're part of 'teamname'.  He/she will now recieve messages related to this team.
        }
        public void newteamevent(string[] players)
        {
            // a player's coach has posted a new event, tell everyone on the team about it.  Use a string array full of player's emails on the team to fill out the 'to' column.
        }
    }
}
