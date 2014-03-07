using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace TeamSoclApp
{
    public class Message : CodeBase
    {
        public int uid;
        public int cuid;
        public int tid;
        public string subject;
        public string message;
        public DateTime dtg;

        public Emailer mail = new Emailer();

        public Message()
        {
            this.uid = 0;
            this.cuid = 0;
            this.tid = 0;
            this.subject = "";
            this.message = "";

            string working = CodeBase.SqlConn.getdtg();

            this.dtg = Convert.ToDateTime(working);
        }

        public void sentwriter()
        {

        }

        public void teamjoinreq()
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

        public void jointeamack()
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
        public void newteamevent()
        {
            //string[] players;

        }
    }
}
