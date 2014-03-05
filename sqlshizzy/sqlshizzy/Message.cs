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

        private SqlOverheadServer SqlConn = new SqlOverheadServer();
        public Emailer mail = new Emailer();

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

        public void teamjoinreq(int cuid, int tid, int uid)
        {
            string recipientfna = "";
            string recipientlna = "";

            SqlConn.uid2name(uid, ref recipientfna, ref recipientlna);

            string recipientem = SqlConn.uid2email(uid);
            
            //get user's email and name via user table

            string tname = SqlConn.tid2name(tid);

            //get team's name from its tid

            string cname = "";
            
            SqlConn.uid2name(cuid, ref cname);

            //get coach's name from his uid

            string subject = "TeamSocl, "+recipientfna+ " "+recipientlna
                + " would like to join team "+ tname;
            string body = "Hello "+cname+", "+recipientfna+ " "+recipientlna
                + " would like to join team "+ tname+ ". Please login to the "
                + "TeamSocl app and confirm or deny this user's request to "
                + "join your team.  Thanks!";

            mail.emailer("teamsocl@outlook.com", recipientem, subject, body);
        }

        public void jointeamack(int cuid, int tid, int uid)
        {
            // send an email off to the player, saying that 'cname' has accepted and you're part of 'teamname'.  He/she will now recieve messages related to this team.
            string recipientfna = "";

            SqlConn.uid2name(uid, ref recipientfna);

            string recipientem = SqlConn.uid2email(uid);
            
            //get user's email and name via user table

            string tname = SqlConn.tid2name(tid);

            //get team's name from its tid

            string cname = "";
            
            SqlConn.uid2name(cuid, ref cname);

            //get coach's name from his uid

            string subject = "TeamSocl, the "+tname+ "s have accepted you!";
            string body = "Hello "+recipientfna+", the "+ tname+ "s have "
                + "accepted you! Please login to the TeamSocl app to review "
                + "up and coming team events.  Thanks!";
            
            mail.emailer("teamsocl@outlook.com", recipientem,subject,body);
        }
        public void newteamevent(string[] players)
        {
            // a player's coach has posted a new event, tell everyone on the team about it.  Use a string array full of player's emails on the team to fill out the 'to' column.
        }
    }
}
