using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail; //add EASendMail namespace

namespace teamsocl
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
                Console.WriteLine("start to send email ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
                return false;
            }
            return true;
        }
    }
}
