using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;

namespace TeamSoclApp
{
    public class Emailer
    {
        public bool emailer(string from, string to, string subject, string body)
        {


            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Set sender email address, please change it to yours
            oMail.From = from;

            // Set recipient email address, please change it to yours
            oMail.To = to;

            // Set email subject
            oMail.Subject = subject;

            // Set email body
            oMail.TextBody = body;

            // Your SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.live.com");

            // User and password for ESMTP authentication, if your server doesn't require
            // User authentication, please remove the following codes.            
            oServer.User = "teamsocl@outlook.com";
            oServer.Password = "team12socl34";

            // If your smtp server requires TLS connection, please add this line
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            //If your smtp server requires implicit SSL connection on 465 port, please add this line
            oServer.Port = 587;
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            try
            {
                oSmtp.SendMail(oServer, oMail);
            }
            catch (Exception e)
            {
                globals.error.Append(" MAIL ERROR: " + e);
                return false;
            }
            return true;
        }
    }
}
