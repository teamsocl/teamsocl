using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace TeamSoclApp
{
    public class Emailer
    {
        public void emailer(string from, string to, string subject, string body)
         
        {


            try
            {
                SmtpClient client = new SmtpClient("smtp.live.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("teamsocl@outlook.com", "team12socl34");

                MailMessage msg = new MailMessage();
                msg.To.Add(to);
                msg.From = new MailAddress(from);
                msg.Subject = subject;
                msg.Body = body;
                Console.WriteLine("start to {0} send email ...", to);
                client.Send(msg);
                Console.WriteLine("email was sent successfully!");
                //MessageBox.Show("Please check your E-Mail for a verification link.");
            }
            
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
                
            }
            
        }
    }
}
