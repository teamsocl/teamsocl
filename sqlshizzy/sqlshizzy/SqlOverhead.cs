using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class SqlOverhead
    {
        public SqlConnection conn = new SqlConnection(ConnString());  //UID=sa;PWD=testserver
        public SqlCommand cmd;
        public SqlDataReader reader;
        public Emailer mailer = new Emailer();
        

        static string ConnString()
        {
            //return bit1 + server + bit3 + database + bit3 + 5 + uid + bit7 + password;
            return "Server=10.33.36.70;Database=teamsocl;UID=sa;PWD=testserver"; //LAB
            //return "Server=localhost;Database=teamsocl;User Id=sa;PWD=team12socl34"; //LEXIT
        }

        public void excepter(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            Console.ReadLine();
            Console.WriteLine("Connetion error! please log-in again!\n");
        }

        public string getdtg()
        {
            string dtg = "";

            conn.Open();

            cmd = new SqlCommand("SELECT CURRENT_TIMESTAMP", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    dtg = reader.GetValue(0).ToString();
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            dtg = dtg.Substring(0, 16);
            conn.Close();

            return dtg;
        }
        //MR1 Messaging Methods
        public bool checkmr1message()
        {
            conn.Open();

            cmd = new SqlCommand("SELECT [subject] FROM [dbo].[mr1]", conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows == false)
            { conn.Close(); reader.Close(); return false; }

            reader.Close();
            conn.Close();
            return true;

        }

        public void sendMr1Message()
        {
            conn.Open();
            int to=0, from=0;

            string MESSAGE = "";
            string SUBJECT = "";

            cmd = new SqlCommand("SELECT * FROM [dbo].[mr1]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    from = reader.GetInt32(1);
                    to = reader.GetInt32(3);
                    SUBJECT = reader.GetString(5);
                    MESSAGE = reader.GetString(6);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();
            Console.WriteLine(to.ToString() + from.ToString() + SUBJECT + MESSAGE);
            //Clear out the MR1 table message
            ClearMr1MessageTop();
            Console.WriteLine("MR1 Cleaned up");
            
            mailer.emailer(uidToEmail(from), uidToEmail(to), SUBJECT, MESSAGE);
        }

        public void ClearMr1MessageTop()
        {
            conn.Open();
            

            cmd = new SqlCommand("DELETE TOP (1) FROM [dbo].[mr1]", conn);
            

            try
            {
                cmd.ExecuteNonQuery();

            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();
           

        }
       //MR2 Message methods
        public bool checkmr2message()
        {
            conn.Open();

            cmd = new SqlCommand("SELECT [subject] FROM [dbo].[mr2]", conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows == false)
            { conn.Close(); reader.Close(); return false; }

            reader.Close();
            conn.Close();
            return true;

        }

        public void sendMr2Message()
        {
            conn.Open();
            int to = 0, from = 0;

            string MESSAGE = "";
            string SUBJECT = "";

            cmd = new SqlCommand("SELECT * FROM [dbo].[mr2]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    from = reader.GetInt32(1);
                    to = reader.GetInt32(3);
                    SUBJECT = reader.GetString(5);
                    MESSAGE = reader.GetString(6);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();
            Console.WriteLine(to.ToString() + from.ToString() + SUBJECT + MESSAGE);
            //Clear out the MR2 table message
            ClearMr2MessageTop();
            Console.WriteLine("MR2 Cleaned up");

            mailer.emailer(uidToEmail(from), uidToEmail(to), SUBJECT, MESSAGE);
        }

        public void ClearMr2MessageTop()
        {
            conn.Open();


            cmd = new SqlCommand("DELETE TOP (1) FROM [dbo].[mr2]", conn);


            try
            {
                cmd.ExecuteNonQuery();

            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();


        }


        //MWelc Message methods
        public bool checkmwelcmessage()
        {
            conn.Open();

            cmd = new SqlCommand("SELECT [uid] FROM [dbo].[mwelc]", conn);
            reader = cmd.ExecuteReader();
            
            if (reader.HasRows == false)
            { conn.Close(); reader.Close(); return false; }

            reader.Close();
            conn.Close();
            return true;

        }

        public void sendmwelcMessage()
        {
            conn.Open();
            int to = 0;

            cmd = new SqlCommand("SELECT * FROM [dbo].[mwelc]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    to = reader.GetInt32(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            // get toos name and put it in string name

            string NAME = uidToName(to);

            string MESSAGE = "Hey "+ NAME + ", Thanks for joining TeamSocl!";
            string SUBJECT = "Welcome to TeamSocl!";

            conn.Close();
            Console.WriteLine(to.ToString() + SUBJECT + MESSAGE);
            //Clear out the mwelc table message
            ClearmwelcMessageTop();
            Console.WriteLine("MWelc Cleaned up");

            mailer.emailer("Teamsocl@outlook.com", uidToEmail(to) , SUBJECT, MESSAGE);
        }

        public void ClearmwelcMessageTop()
        {
            conn.Open();


            cmd = new SqlCommand("DELETE TOP (1) FROM [dbo].[mwelc]", conn);


            try
            {
                cmd.ExecuteNonQuery();

            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();


        }
        
        //Common Tools 


        public string uidToEmail(int uid)
        {
            conn.Close();
            conn.Open();
            string email = "";

            cmd = new SqlCommand("SELECT [email] FROM [dbo].[users] WHERE [uid]="+uid, conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    email = reader.GetString(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();

            return email;
        }
        
        public string uidToName(int uid)
        {
            conn.Close();
            conn.Open();
            string name = "";

            cmd = new SqlCommand("SELECT [first_name] FROM [dbo].[users] WHERE [uid]=" + uid, conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();

            return name;
        }
    }
}
