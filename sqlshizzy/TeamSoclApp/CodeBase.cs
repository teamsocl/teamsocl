﻿using System;
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
//test

namespace TeamSoclApp
{
    public class CodeBase : MainWindow
    {
        public static Persona User = new Persona();
        public static DBvals[] DBUser;
        public static DBvals DBload = new DBvals();
        public Message message;

        public static SqlOverheadClient SqlConn = new SqlOverheadClient();


        public static bool continueR;

        // event/message handling - POOR

        // LOG-AUTH SECTION - WORKING - 90%

        public bool authenticator()  // authentication process - DONE
        {
            login();

            if (SqlConn.authget() == false) return false;

            if (validator(DBload.PWord, User.PWord) == true)
            {


                if (SqlConn.filluser(ref User) == false)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public void login()  // login widget - DONE
        {

            User.EMail = Convert.ToString(EmailText);
            
            User.PWord = Convert.ToString(PasswordText);
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

        //static bool register()  // user register widget - 90%
        //{

        //    int rNumber, nextUID = 0, nextDID = 0;
        //    string fName, lName, nName, eMail, passWord;        // input area
        //    double phone;

        //    Console.Clear();
        //    Console.WriteLine("#######################################################");
        //    Console.WriteLine("#                                                     #");
        //    Console.WriteLine("#          Thank you for joining Team Socl!           #");
        //    Console.WriteLine("#                                                     #");
        //    Console.WriteLine("#######################################################\n");

        //    do
        //    {
        //        Console.WriteLine("\n\nPlease fill out the following registry");

        //        Console.Write("\n\nEmail: ");
        //        eMail = Console.ReadLine();

        //        if (SqlConn.is1in2row3(eMail, "security", "email") == true)
        //        {
        //            Console.WriteLine("This E-Mail address has already been registered!\n");
        //            continue;
        //        }

        //        Console.Write("\n\nFirst name: ");
        //        fName = Console.ReadLine();

        //        Console.Write("\n\nLast name: ");
        //        lName = Console.ReadLine();

        //        Console.Write("\n\nNickname: ");
        //        nName = Console.ReadLine();

        //        Console.Write("\n\nJersey number: ");
        //        rNumber = Convert.ToInt16(Console.ReadLine());

        //        // we're taking numbers as double ints here, we're going to put in a cute WPF based block deal that takes 3 for area, 3 for prefix, and 4 for suffix to correct variable input due to player data entry differentiallity.

        //        Console.Write("\n\nPhone number: ");
        //        phone = Convert.ToInt64(Console.ReadLine());

        //        Console.Clear();
        //        Console.WriteLine("You have entered the following data: \n {0} {1} {2} {3} "
        //            + "{4} {5}, you are user # {6}!\n\n Is this data correct?", fName, lName,
        //            nName, rNumber, phone, eMail, nextUID);
        //        workingInput.String = Console.ReadLine();
        //        if (workingInput.String.ToLower() != "y") continue;

        //        do
        //        {
        //            Console.WriteLine("Please re-enter your email:");
        //            workingInput.String = Console.ReadLine();

        //            if (workingInput.String == eMail) break;
        //            else Console.WriteLine("You did not re-enter it correctly\n"); continue;
        //        }
        //        while (true);

        //        do
        //        {
        //            Console.WriteLine("Please enter the password that you would like to create:");
        //            workingInput.String = Console.ReadLine();
        //            passWord = workingInput.String;

        //            Console.WriteLine("Please re-enter the password that you would like to create:");
        //            workingInput.String = Console.ReadLine();

        //            if (workingInput.String == passWord) break;
        //            else Console.WriteLine("You did not re-enter it correctly\n"); continue;
        //        }
        //        while (true);

        //        // Repull to block collissions if someone else registers at the same time...

        //        nextUID = SqlConn.getcuruid();
        //        nextUID++;

        //        if (SqlConn.regwriteuser(fName, lName, rNumber, nName, phone,
        //            eMail, nextUID, passWord) == false) return false;

        //        nextDID = SqlConn.getcurdid();
        //        nextDID++;

        //        if (SqlConn.regwritedaemond(nextDID, nextUID)) return false;

        //        Console.WriteLine("{0}, Thank you for registering!", fName.ToString());
        //        Console.ReadKey();

        //        return true;

        //    }
        //    while (true);

        //}

        // TEAM REGISTRATION - WORKING 90%

        //static bool teamregister() // Register a new team - 90%
        //{
        //    string tName, ceMail;
        //    int nextTID = 0;
        //    double cPhone;

        //    Console.Clear();
        //    Console.WriteLine("#######################################################");
        //    Console.WriteLine("#                                                     #");
        //    Console.WriteLine("#        Thank you for coaching on Team Socl!         #");
        //    Console.WriteLine("#                                                     #");
        //    Console.WriteLine("#######################################################\n");

        //    do
        //    {
        //        Console.WriteLine("\n\nPlease fill out the following team registry");

        //        Console.Write("\n\nTeam name: ");
        //        tName = Console.ReadLine();

        //        cPhone = User.PhoneNumber;
        //        ceMail = User.EMail;

        //        Console.Write("\n\nTeam Color 1: (experimental, not implemented yet");

        //        Console.Write("\n\nTeam Color 1: (experimental, not implemented yet");

        //        Console.Clear();

        //        workingInput.String = Console.ReadLine();

        //        Console.WriteLine("You have entered the following data:" 
        //            + "\n {0}, {1}, {2}\n\n Is this data correct (y)?" 
        //            + "", tName, ceMail,cPhone);

        //        if (workingInput.String.ToLower() != "y") continue;

        //        // PULL the next TID available

        //        nextTID = SqlConn.getcurtid();

        //        nextTID++;

        //        //Console.WriteLine("You recieved UID {0}!\n", nextUID);

        //        //if (
        //        SqlConn.teamregwrite(nextTID, tName, User.FName, User.LName, User.UID); //== true)
        //        //{ return true; }
        //        break;

        //    }
        //    while (true);

        //    return false;
        //}

        // JOIN TEAM BLOCK

        public bool jointeamuser(int tid)
        {
            Message jointeam = new Message();

            jointeam.uid = User.UID;
            jointeam.tid = tid;



            jointeam.cuid = SqlConn.tid2cuid(tid);


            return true;
        }

        // CLIENT SIDE MESSAGING - POOR



        public bool teamcaster(string message) // NOT FINISHED
        {

            return true;
        }

        // ADMIN MESSAGING - POOR

        public bool broadcaster(string message)  // NOT FINNISHED
        {
            // broadcast with TID of 0 into broadcast table
            return true;
        }

        // DASHBOARD FEATURES - POOR

        //public static bool dashboard(SqlConnection conn)
        //{
        //    do                // Our program once you've logged in successfully
        //    {
        //        continueR = false;
        //        //


        //        Console.Clear();
        //        Console.WriteLine("w Weather \nt New team \ns Show security \nq Quit");

        //        workingInput.Char(Console.ReadKey());

        //        switch (workingInput.Char())
        //        {
        //            case 'w':
        //                {
        //                    Console.WriteLine("current weather is : \n\n " + weather());
        //                    Console.ReadKey();
        //                    Console.Clear();
        //                    continue; ;
        //                }
        //            case 't':
        //                {
        //                    teamregister();
        //                    continue;
        //                }
        //            case 's':
        //                {
        //                    Console.Clear();

        //                    Console.WriteLine(RunSelectString("SELECT" + " * FROM [dbo].[security]", 4, conn));
        //                    Console.ReadKey();
        //                    continue;
        //                }
        //            case 'q':
        //                {
        //                    switch (quitter())
        //                    {
        //                        case 1:
        //                            return false;
        //                        case 2:
        //                            return true;
        //                        case 3:
        //                            continue;
        //                        default:
        //                            continue;
        //                    }
        //                }
        //            default:
        //                Console.WriteLine("oopse!");
        //                break;
        //        }

        //        switch (quitter())
        //        {
        //            case 1:
        //                return false;
        //            case 2:
        //                return true;
        //            case 3:
        //                continue;
        //            default:
        //                continue;
        //        }


        //    }
        //    while (continueR != true);
        //    return true;
        //}  // dashboard for main program after auth/valid

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
        }

        //static string weather()  // weather function to be implemented in full later - 90%
        //{
        //    string answer = "";

        //    Console.Write("enter a zipcode: ");
        //    string zip1 = Console.ReadLine();

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("http://xml.weather.yahoo.com/forecastrss?p=" + zip1);

        //    // Set up namespace manager for XPath  
        //    XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
        //    ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

        //    // Get forecast with XPath  
        //    XmlNodeList nodes = doc.SelectNodes("/rss/channel/item/yweather:forecast", ns);

        //    try
        //    {
        //        Console.Write("Todays weather for " + zip1 + ": ");
        //        answer = nodes[0].Attributes["day"].InnerText + ": " +
        //            nodes[0].Attributes["text"].InnerText + ", " +
        //            nodes[0].Attributes["low"].InnerText + "F - " +
        //            nodes[0].Attributes["high"].InnerText + "F\n";
        //    }
        //    catch (Exception)
        //    {
        //        answer = "Weather service not currently available!";
        //    }
        //    return answer;
        //}

        // Console Version

        // test functions!!!

        //static string RunSelectString(string input, int returns, SqlConnection conn)
        //{
        //    string output = "";
        //    SqlCommand cmd;
        //    SqlDataReader reader;

        //    cmd = new SqlCommand(input, conn);
        //    reader = cmd.ExecuteReader();

        //    Console.Clear();

        //    while (reader.Read())
        //    {

        //        for (int i = 0; i < returns; i++)
        //        {
        //            Console.Write(reader.GetName(i) + " \t ");
        //        }
        //        Console.WriteLine("\n");

        //        do
        //        {
        //            for (int i = 0; i < returns; i++)
        //            {
        //                Console.Write(reader.GetValue(i) + " \t ");
        //            }
        //            Console.WriteLine("\n");
        //        }
        //        while (reader.Read());
        //        Console.ReadKey();
        //        reader.Close();
        //        return output;

        //    }
        //    return output;
        //}  // test only

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
