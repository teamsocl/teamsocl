using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//test

namespace TeamSoclApp
{
    class EventHandlerServer
    {
        public static string wwwroot = @"C:\wamp\www\working\";

        static DBvals[] DBUser;
        public static DBvals DBload = new DBvals();
        static Message message = new Message();

        static SqlOverheadServer SqlConn = new SqlOverheadServer();

        static bool continueR;

        // event/message handling - POOR

        public static void messagehandler()
        {

        }


        // LOG-AUTH SECTION - WORKING - 90%

        public static void splash()  // splash display - DONE
        {
            Console.WriteLine("#######################################################");
            Console.WriteLine("#        Welcome to Go Team Go Live v 1.0.a           #");
            Console.WriteLine("#     while using the console version of GTGL,        #");
            Console.WriteLine("#     'q' entered in any prompt should escape!        #");
            Console.WriteLine("#         please press (any) key when ready.          #");
            Console.WriteLine("#######################################################");
            Console.ReadKey();
        }

        static bool validator(string dbPassword, string password)  // validates authentication - DONE
        {
            if (password == "") return false;
            if (dbPassword == password) return true;                             // password validator widget
            else return false;
        }

        // USER REGISTRATION - WORKING 90%

        static void reginflater(string sourcePath) //int uid - 90%
        {
            //testing
            //int uid;
            //testing

            double rando;

            string pathToCreate;
            string sourcePathBase;

            Random rng = new Random(); rando = rng.Next(1000000, 9999999);
            pathToCreate = sourcePath + rando.ToString() + "\\";
            System.IO.Directory.CreateDirectory(pathToCreate);

            sourcePathBase = sourcePath + @"base\";

            string fileName1 = "index.html";
            string fileName2 = "insert.php";

            //System.IO.File.Create(@"C:\inetpub\wwwroot\working\base\insert2.txt");

            string toinsert = " phpinfo() ";

            System.IO.File.WriteAllText(sourcePathBase + @"insert2.txt", toinsert);

            {
                try
                {
                    // create the ProcessStartInfo using "cmd" as the program to be run,
                    // and "/c " as the parameters.
                    // Incidentally, /c tells cmd that we want it to execute the command that follows,
                    // and then exit.
                    System.Diagnostics.ProcessStartInfo procStartInfo =
                        new System.Diagnostics.ProcessStartInfo("cmd", @"/c type "
                            + sourcePathBase + @"insert1.txt "
                            + sourcePathBase + @"insert2.txt "
                            + sourcePathBase + @"insert3.txt > "
                            + sourcePathBase + @"insert.php");

                    // The following commands are needed to redirect the standard output.
                    // This means that it will be redirected to the Process.StandardOutput StreamReader.
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    // Do not create the black window.
                    procStartInfo.CreateNoWindow = true;
                    // Now we create a process, assign its ProcessStartInfo and start it
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo = procStartInfo;
                    proc.Start();
                    // Get the output into a string
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    Console.WriteLine(result);
                }
                catch (Exception objException)
                {
                    Console.WriteLine(objException);
                }
            }

            System.IO.File.Delete(sourcePathBase + "insert2.txt");

            System.IO.File.Copy(sourcePathBase + fileName1, pathToCreate + fileName1, true);

            System.IO.File.Copy(sourcePathBase + fileName2, pathToCreate + fileName2, true);

            Console.WriteLine("browse to: " + pathToCreate + @"index.html");
        }

        static void reginflater(bool debug) //int uid  (LAB!!!)
        {
            //testing
            //int uid;
            //testing

            double rando;

            string pathToCreate;
            string sourcePath = @"C:\wamp\www\working\";

            Random rng = new Random(); rando = rng.Next(1000000, 9999999);
            pathToCreate = sourcePath + rando.ToString() + "\\";
            System.IO.Directory.CreateDirectory(pathToCreate);

            sourcePath = sourcePath + "base\\";

            string fileName1 = "index.html";
            string fileName2 = "insert.php";

            //System.IO.File.Create(@"C:\inetpub\wwwroot\working\base\insert2.txt");

            string toinsert = " phpinfo() ";

            System.IO.File.WriteAllText(@"C:\wamp\www\working\base\insert2.txt", toinsert);

            {
                try
                {
                    // create the ProcessStartInfo using "cmd" as the program to be run,
                    // and "/c " as the parameters.
                    // Incidentally, /c tells cmd that we want it to execute the command that follows,
                    // and then exit.
                    System.Diagnostics.ProcessStartInfo procStartInfo =
                        new System.Diagnostics.ProcessStartInfo("cmd", "/c " + @"type c:\wamp\www\working\base\insert1.txt c:\wamp\www\working\base\insert2.txt c:\wamp\www\working\base\insert3.txt > c:\wamp\www\working\base\insert.php");

                    // The following commands are needed to redirect the standard output.
                    // This means that it will be redirected to the Process.StandardOutput StreamReader.
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    // Do not create the black window.
                    procStartInfo.CreateNoWindow = true;
                    // Now we create a process, assign its ProcessStartInfo and start it
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo = procStartInfo;
                    proc.Start();
                    // Get the output into a string
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    Console.WriteLine(result);
                }
                catch (Exception objException)
                {
                    Console.WriteLine(objException);
                }
            }

            System.IO.File.Delete(@"C:\wamp\www\working\base\insert2.txt");

            System.IO.File.Copy(sourcePath + fileName1, pathToCreate + fileName1, true);

            System.IO.File.Copy(sourcePath + fileName2, pathToCreate + fileName2, true);

            Console.WriteLine("browse to: " + pathToCreate + "\\index.html");

        }


        // USER JOIN TEAM - POOR

        public bool messagecatcher()
        {
            return true;
        }
        
        public bool jointeamplayer()
        {
            //if (SqlConn.jointeamplayer(int tid) == false) return false;
            return true;
        }

        //public bool jointeamack(int tid, int uid)
        //{



        //    if (User.TID1 == 0)
        //    { if (SqlConn.filluserstid(1, tid) == false) return false; }
        //    else if (User.TID2 == 0)
        //    { if (SqlConn.filluserstid(2, tid) == false) return false; }
        //    else if (User.TID3 == 0)
        //    { if (SqlConn.filluserstid(3, tid) == false) return false; }
        //    else if (User.TID4 == 0)
        //    { if (SqlConn.filluserstid(4, tid) == false) return false; }
        //    else
        //    {
        //        //send mail to coach saying player's aready in too many teams
        //        //send mail to player letting him know he cant join cuz he's full
        //    }



        //    return true;
        //} // NOT FINISHED



        // CLIENT SIDE MESSAGING - POOR

        public bool catchdaemonmessage()  //INCOMPLETE
        {
            // query message via sqloverhead's fetchdaemonmessage for 1 message that isn't "completed"/1, and still "active"/0 in daemond message queue...
            string messagetype = "";
            switch (messagetype)
            {
                case "1":  //change
                    {
                        break;
                    }
                case "2":  //change
                    {
                        break;
                    }
            }
            return true;
        }

        public bool teamcaster(string message) // NOT FINISHED
        {

            return true;
        }

        // SERVER SIDE MESSAGING - POOR

        public void jointeamcoachmailer() // NOT FINISHED
        {

        }

        // ADMIN MESSAGING - POOR

        public bool broadcaster(string message)  // NOT FINNISHED
        {
            // broadcast with TID of 0 into broadcast table
            return true;
        }

        // DASHBOARD FEATURES - POOR

        static bool pullteamtable(int tid) // TEST ME!!!
        {
            string teamname = "";
            int tcount = 0;

            // Pull team's name via its team ID.

            teamname = SqlConn.tid2name(tid);

            // Pull how many people are on that team via teamname

            tcount = SqlConn.teammemcount(teamname);

            // tcount = SqlConn.teammemcount(SqlConn.tid2name(tid);
            // Pull each UID on a team and put them into an array

            int[] uids = new int[tcount];

            SqlConn.teamuids(ref uids, teamname, tcount);

            // Pull each set of UID's stuff and put them into the DBUsers array.

            DBUser = new DBvals[tcount];

            SqlConn.teamusersdata(ref DBUser, uids);

            return true;

        }

        // CLEANUP - GOOD

        // GENERAL FUNCTIONS - GOOD

        public static void connresetter()  // resets the SQL connection - DONE
        {
            SqlConn.conn.Close();
            SqlConn.conn.Open();

            Console.WriteLine("Conn reset!");
            Console.ReadKey();
        }

        static string weather()  // weather function to be implemented in full later - 90%
        {
            string answer = "";

            Console.Write("enter a zipcode: ");
            string zip1 = Console.ReadLine();

            XmlDocument doc = new XmlDocument();
            doc.Load("http://xml.weather.yahoo.com/forecastrss?p=" + zip1);

            // Set up namespace manager for XPath  
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get forecast with XPath  
            XmlNodeList nodes = doc.SelectNodes("/rss/channel/item/yweather:forecast", ns);

            try
            {
                Console.Write("Todays weather for " + zip1 + ": ");
                answer = nodes[0].Attributes["day"].InnerText + ": " +
                    nodes[0].Attributes["text"].InnerText + ", " +
                    nodes[0].Attributes["low"].InnerText + "F - " +
                    nodes[0].Attributes["high"].InnerText + "F\n";
            }
            catch (Exception)
            {
                answer = "Weather service not currently available!";
            }
            return answer;
        }

        // Console Version

        public static void Texty()
        {
            // Sploosh
            splash();

        }

        // test functions!!!

        static string RunSelectString(string input, int returns, SqlConnection conn)
        {
            string output = "";
            SqlCommand cmd;
            SqlDataReader reader;

            cmd = new SqlCommand(input, conn);
            reader = cmd.ExecuteReader();

            Console.Clear();

            while (reader.Read())
            {

                for (int i = 0; i < returns; i++)
                {
                    Console.Write(reader.GetName(i) + " \t ");
                }
                Console.WriteLine("\n");

                do
                {
                    for (int i = 0; i < returns; i++)
                    {
                        Console.Write(reader.GetValue(i) + " \t ");
                    }
                    Console.WriteLine("\n");
                }
                while (reader.Read());
                Console.ReadKey();
                reader.Close();
                return output;

            }
            return output;
        }  // test only

        /*static bool datapull(SqlConnection conn)
{
    cmd = new SqlCommand("SELECT [first_name],[last_name],[nickname]" +
            ",[email],[roster_num],[admin],[tids1],[tids2],[tids3],[tids4]" +
            ",[phone] FROM [dbo].[users] WHERE [uid] = " + User.UID, conn);
    reader = cmd.ExecuteReader();

    try
    {
        while (reader.Read())
        {
            User.FName = reader.GetString(0);
            User.LName = reader.GetString(1);
            User.NName = reader.GetString(2);
            User.EMail = reader.GetString(3);
            User.RNumber = reader.GetInt32(4);
            User.Admin = reader.GetBoolean(5);
            User.TID1 = reader.GetInt32(6);
            User.TID2 = reader.GetInt32(7);
            User.TID3 = reader.GetInt32(8);
            User.TID4 = reader.GetInt32(9);
            User.PhoneNumber = reader.GetInt64(10);
        }

        reader.Close();
    }

    catch (Exception e)
    {
        Console.WriteLine("ERROR: " + e);
        Console.ReadLine();

        Console.WriteLine("Connetion error! please log-in again!");
        return false;
    }

    return true;
}*/


    }
}
