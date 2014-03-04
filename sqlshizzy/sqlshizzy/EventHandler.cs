using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace teamsocl
{
    class EventHandler
    {
        public static string wwwroot = @"C:\wamp\www\working\";

        public static Persona User = new Persona();
        static DBvals[] DBUser;
        public static DBvals DBload = new DBvals();
        static Message message = new Message();

        static SqlOverhead SqlConn = new SqlOverhead();

        static WorkingInput workingInput = new WorkingInput();

        static bool continueR;

        public enum Event { mail, register, joinrq, joinack, broadcast }

        // event/message handling        

        public static void messagehandler(Event ToDo)
        {
            
            message.fromuid = User.UID;
            message.resolved = false;
            
            
            
            switch (ToDo)
            {
                case Event.mail:
                    {
                        
                        //emailer();
                        break;
                    }
                case Event.register:
                    {
                        reginflater(wwwroot);
                        break;
                    }
                case Event.joinrq:
                    {
                        break;
                    }
                case Event.joinack:
                    {
                        break;
                    }
                case Event.broadcast:
                    {
                        break;
                    }
            }
        }

        // LOG-AUTH SECTION - WORKING

        public static bool authenticator()  // authentication process
        {

            if (SqlConn.authget() == false) return false;

            if (validator(DBload.PWord, User.PWord) == true)
            {


                if (SqlConn.filluser(ref User) == false)
                {
                    Console.WriteLine("Connetion error! please log-in again!");
                    return false;
                }


                Console.WriteLine("\nsuccessfully logged in!");

                Console.WriteLine(User.FName + User.LName + User.NName + User.EMail);
                Console.WriteLine(User.RNumber.ToString() + User.PhoneNumber.ToString()
                    + User.Admin + User.TID1);

                Console.ReadKey();
                Console.Clear();
                return true;
            }

            else
            {
                Console.WriteLine("You've entered an invalid email or " 
                    + "password! (strike 'any' key to continue)");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

        }

        static void login()  // login widget
        {
            Console.Clear();
            Console.WriteLine("#######################################################");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#         Please enter your E-Mail adddress           #");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#######################################################\n");
            // check this input so noone injects on us
            User.EMail = Console.ReadLine();

            Console.WriteLine("#######################################################");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#             Please enter your Password              #");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#######################################################\n");
            // injection block check
            User.PWord = Console.ReadLine();
        }

        static bool postsplash()  // post splash screen "login or register"
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Do you want to login (L) or register (R)?");

                workingInput.Char(Console.ReadKey());

                switch (workingInput.Char())
                {
                    case 'l':
                        login();
                        return true;
                    case 'r':
                        if (register() == false) break;
                        else break;
                    case 'q':
                        continueR = false;
                        return false;
                    default:
                        Console.WriteLine("oopse!");
                        break;
                }
            }
            while (true);
        }
        
        public static void splash()  // splash display for start of program
        {
            Console.WriteLine("#######################################################");
            Console.WriteLine("#        Welcome to Go Team Go Live v 1.0.a           #");
            Console.WriteLine("#     while using the console version of GTGL,        #");
            Console.WriteLine("#     'q' entered in any prompt should escape!        #");
            Console.WriteLine("#         please press (any) key when ready.          #");
            Console.WriteLine("#######################################################");
            Console.ReadKey();
        }

        static bool validator(string dbPassword, string password)  // validates authentication
        {
            if (password == "") return false;
            if (dbPassword == password) return true;                             // password validator widget
            else return false;
        }

        // USER REGISTRATION

        static void reginflater(string sourcePath) //int uid 
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

        static bool register()  // user register widget
        {

            int rNumber, nextUID = 0, nextDID = 0;
            string fName, lName, nName, eMail, passWord;        // input area
            double phone;

            Console.Clear();
            Console.WriteLine("#######################################################");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#          Thank you for joining Team Socl!           #");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#######################################################\n");

            do
            {
                Console.WriteLine("\n\nPlease fill out the following registry");

                Console.Write("\n\nEmail: ");
                eMail = Console.ReadLine();

                if (SqlConn.is1in2row3(eMail, "security", "email") == true)
                {
                    Console.WriteLine("This E-Mail address has already been registered!\n");
                    continue;
                }

                Console.Write("\n\nFirst name: ");
                fName = Console.ReadLine();

                Console.Write("\n\nLast name: ");
                lName = Console.ReadLine();

                Console.Write("\n\nNickname: ");
                nName = Console.ReadLine();

                Console.Write("\n\nJersey number: ");
                rNumber = Convert.ToInt16(Console.ReadLine());

                // we're taking numbers as double ints here, we're going to put in a cute WPF based block deal that takes 3 for area, 3 for prefix, and 4 for suffix to correct variable input due to player data entry differentiallity.

                Console.Write("\n\nPhone number: ");
                phone = Convert.ToInt64(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("You have entered the following data: \n {0} {1} {2} {3} "
                    + "{4} {5}, you are user # {6}!\n\n Is this data correct?", fName, lName,
                    nName, rNumber, phone, eMail, nextUID);
                workingInput.String = Console.ReadLine();
                if (workingInput.String.ToLower() != "y") continue;

                do
                {
                    Console.WriteLine("Please re-enter your email:");
                    workingInput.String = Console.ReadLine();

                    if (workingInput.String == eMail) break;
                    else Console.WriteLine("You did not re-enter it correctly\n"); continue;
                }
                while (true);

                do
                {
                    Console.WriteLine("Please enter the password that you would like to create:");
                    workingInput.String = Console.ReadLine();
                    passWord = workingInput.String;

                    Console.WriteLine("Please re-enter the password that you would like to create:");
                    workingInput.String = Console.ReadLine();

                    if (workingInput.String == passWord) break;
                    else Console.WriteLine("You did not re-enter it correctly\n"); continue;
                }
                while (true);

                // Repull to block collissions if someone else registers at the same time...

                nextUID = SqlConn.getcuruid();
                nextUID++;

                if (SqlConn.regwriteuser(fName, lName, rNumber, nName, phone,
                    eMail, nextUID, passWord) == false) return false;

                nextDID = SqlConn.getcurdid();
                nextDID++;

                if (SqlConn.regwritedaemond(nextDID, nextUID)) return false;

                Console.WriteLine("{0}, Thank you for registering!", fName.ToString());
                Console.ReadKey();

                return true;

            }
            while (true);

        }

        // TEAM REGISTRATION - WORKING

        static bool teamregister()
        {
            string tName, ceMail;
            int nextTID = 0;
            double cPhone;

            Console.Clear();
            Console.WriteLine("#######################################################");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#        Thank you for coaching on Team Socl!         #");
            Console.WriteLine("#                                                     #");
            Console.WriteLine("#######################################################\n");

            do
            {
                Console.WriteLine("\n\nPlease fill out the following team registry");

                Console.Write("\n\nTeam name: ");
                tName = Console.ReadLine();

                cPhone = User.PhoneNumber;
                ceMail = User.EMail;

                Console.Write("\n\nTeam Color 1: (experimental, not implemented yet");

                Console.Write("\n\nTeam Color 1: (experimental, not implemented yet");

                Console.Clear();
                
                workingInput.String = Console.ReadLine();

                if (workingInput.String.ToLower() != "y") continue;

                // PULL the next TID available

                nextTID = SqlConn.getcurtid();

                nextTID++;

                //Console.WriteLine("You recieved UID {0}!\n", nextUID);

                //if (
                SqlConn.teamregwrite(nextTID, tName, User.FName, User.LName, User.UID); //== true)
                //{ return true; }
                break;

            }
            while (true);

            return false;
        }

        // USER JOIN TEAM

        public bool jointeamplayer()
        {
            //if (SqlConn.jointeamplayer(int tid) == false) return false;
            return true;
        }

        public bool jointeamack(int tid, int uid)
        {



            if (User.TID1 == 0)
            { if (SqlConn.filluserstid(1, tid) == false) return false; }
            else if (User.TID2 == 0)
            { if (SqlConn.filluserstid(2, tid) == false) return false; }
            else if (User.TID3 == 0)
            { if (SqlConn.filluserstid(3, tid) == false) return false; }
            else if (User.TID4 == 0)
            { if (SqlConn.filluserstid(4, tid) == false) return false; }
            else
            {
                //send mail to coach saying player's aready in too many teams
                //send mail to player letting him know he cant join cuz he's full
            }



            return true;
        } // NOT FINISHED

        public bool jointeamreq(int tid, int uid) // NOT FINISHED
        {
            int cuid = 0;
            string cname = "";
            string tname = "";

            if (SqlConn.jointeamreq(tid, ref cuid, ref cname, ref tname) == false) return false;

            // post message to daemond to email coach CUID, include name to format the email to coach


            return true;
        }

        // CLIENT SIDE MESSAGING

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

        // SERVER SIDE MESSAGING

        // ADMIN MESSAGING

        public bool broadcaster(string message)  // NOT FINNISHED
        {
            // broadcast with TID of 0 into broadcast table
            return true;
        }

        // DASHBOARD FEATURES

        public static bool dashboard(SqlConnection conn)
        {
            do                // Our program once you've logged in successfully
            {
                continueR = false;
                //


                Console.Clear();
                Console.WriteLine("w Weather \nt New team \ns Show security \nq Quit");

                workingInput.Char(Console.ReadKey());

                switch (workingInput.Char())
                {
                    case 'w':
                        {
                            Console.WriteLine("current weather is : \n\n " + weather());
                            Console.ReadKey();
                            Console.Clear();
                            continue; ;
                        }
                    case 't':
                        {
                            teamregister();
                            continue;
                        }
                    case 's':
                        {
                            Console.Clear();

                            Console.WriteLine(RunSelectString("SELECT" + " * FROM [dbo].[security]", 4, conn));
                            Console.ReadKey();
                            continue;
                        }
                    case 'q':
                        {
                            switch (quitter())
                            {
                                case 1:
                                    return false;
                                case 2:
                                    return true;
                                case 3:
                                    continue;
                                default:
                                    continue;
                            }
                        }
                    default:
                        Console.WriteLine("oopse!");
                        break;
                }

                switch (quitter())
                {
                    case 1:
                        return false;
                    case 2:
                        return true;
                    case 3:
                        continue;
                    default:
                        continue;
                }


            }
            while (continueR != true);
            return true;
        }  // dashboard for main program after auth/valid

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

        // CLEANUP

        static int quitter()  // spash to logout or quit
        {
            Console.WriteLine("\n\ndo you want to log out? strike (y) quit? (q)");

            workingInput.Char(Console.ReadKey());
            if (workingInput.Char() == 'y') return 1;
            else if (workingInput.Char() == 'q') return 2;
            else return 3;
        }
        
        // GENERAL FUNCTIONS

        public static void connresetter()  // resets the SQL connection
        {
            SqlConn.conn.Close();
            SqlConn.conn.Open();

            Console.WriteLine("Conn reset!");
            Console.ReadKey();
        }

        static string weather()  // weather function to be implemented in full later
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

            //TEST SECTION
            reginflater(wwwroot);
            Console.WriteLine("asdf");
            Console.ReadKey();
            //END TEST SECTION

            do
            {
                continueR = false; // clear our escape flag for continues

                // Postsplash
                connresetter(); if (postsplash() == false) return;

                // authenticate user
                connresetter(); if (authenticator() == false) continue;

                // dashboard
                connresetter(); if (dashboard(SqlConn.conn) == false) continue;

                // quit breaks - continue continues
                if (continueR == true) continue;
                else break;
            }
            while (continueR != true);

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
