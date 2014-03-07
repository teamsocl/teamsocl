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

        public string bit1 = "Server=";
        private string server = "";        // bit 2
        public string bit3 = ";Database=";
        private string database = "";      // bit 4
        public string bit5 = ";UID=";
        private string uid = "";           // bit 6
        public string bit7 = ";PWD=";
        private string password = "";      // bit 8

        static string ConnString()
        {
            //return bit1 + server + bit3 + database + bit3 + 5 + uid + bit7 + password;
            return "Server=localhost\\SQLEXPRESS;Database=teamsocl;UID=sa;PWD=testserver"; //LAB
            //return "Server=localhost;Database=teamsocl;User Id=sa;PWD=team12socl34"; //LEXIT
        }

        public void Server(string SERVER)
        { server = SERVER; }
        public void Database(string DATABASE)
        { database = DATABASE; }
        public void Uid(string UID)
        { uid = UID; }
        public void Password(string PASSWORD)
        { password = PASSWORD; }

        // LOGIN/AUTH METHODS

        public bool filluser(ref Persona User)
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
        }

        // USER REGISTRATION

        public bool regwriteuser(string fName, string lName, int rNumber, string nName, double phone, string eMail, int nextUID, string passWord)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[users] ([uid],"
                    + "[first_name],[last_name],[roster_num],[nickname],[admin]"
                    + ",[phone],[email],[tids1],[tids2],[tids3],[tids4]) VALUES"
                    + "(" + nextUID + ",'" + fName + "','" + lName + "'," + rNumber
                    + ",'" + nName + "',1," + phone + ",'" + eMail + "',0,0,0,0)", conn);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("INSERT INTO [dbo].[security] ([uid],[password],[admin],"
                    + "[email],[active]) VALUES"
                    + "(" + nextUID + ",'" + passWord + "',1,'" + eMail + "',0)", conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            { excepter(e); return false; }
            return true;
        }

        public bool regwritedaemond(int nextDID, int nextUID)
        {

            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[daemond] ([did],[uid],[tid]"
                    + "[action],[message],[resolved]) VALUES (" + nextDID
                    + "," + nextUID + ",0,'REGISTER','rando',0)", conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                excepter(e); return false;
            }
            return true;
        }

        // TEAM REGISTRATION

        public bool teamregwrite(int nextTID, string tName, string cFirst, string cLast, int cID)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[teams] ([tid],[team_name],[coachf],"
                    + "[coachl],[coach_uid]) VALUES"
                    + "(" + nextTID + ",'" + tName + "','" + cFirst + "','" + cLast
                    + "'," + cID + ")", conn);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("CREATE TABLE [dbo].[z" + tName.ToLower() +
                    "]([uid] [int] NULL,[first_name] [varchar](15) NULL," +
                    "[last_name] [varchar](15) NULL,[roster_num] [int] NULL," +
                    "[nickname] [varchar](15) NULL,[phone] [bigint] NULL,[email]" +
                    "[varchar](35) NULL,[privacy] [bit] NULL,[approved] [bit] NULL)", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { excepter(e); return false; }
            return true;
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

            cmd = new SqlCommand("SELECT CURRENT_TIMESTAMP", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    dtg = reader.GetString(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            dtg = dtg.Substring(0, 16);

            return dtg;
        }

        public int getcurbid() // gets current broadcast message ID
        {
            int nextBID = 0;
            cmd = new SqlCommand("SELECT MAX(did) FROM [dbo].[daemond]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    nextBID = Convert.ToInt16(reader.GetValue(0));
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            return nextBID;
        }

        public int getcurdid() // gets current daemon message ID
        {
            int nextDID = 0;
            cmd = new SqlCommand("SELECT MAX(did) FROM [dbo].[broadcast]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    nextDID = Convert.ToInt16(reader.GetValue(0));
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            return nextDID;
        }

        public int getcurtid() // gets max team ID in team table
        {
            int nextTID = 0;
            cmd = new SqlCommand("SELECT MAX(tid) FROM [dbo].[teams]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    nextTID = Convert.ToInt16(reader.GetValue(0));
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            return nextTID;
        }

        public int getcuruid() // gets max user ID in user table
        {
            int nextUID = 0;
            cmd = new SqlCommand("SELECT MAX(uid) FROM [dbo].[users]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    nextUID = Convert.ToInt16(reader.GetValue(0));
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            return nextUID;
        }

        public bool is1in2row3(string value, string table, string rowname)
        {
            bool exists = false;

            cmd = new SqlCommand("SELECT COUNT(1) FROM [dbo].["+table+"] WHERE "
                + "["+rowname+"] = '" + value + "'", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(0) >= 1) exists = true ;
                }

                reader.Close();
            }

            catch (Exception e)
            { excepter(e); return false; }
            return exists;
        }

        public bool pullentity(ref DBvals[] DBUser, int uid) // NOT USED YET!!!
        {
            DBUser = new DBvals[1];

            cmd = new SqlCommand("SELECT [first_name],[last_name],[nickname]" +
                    ",[email],[roster_num],[admin],[tids1],[tids2],[tids3],[tids4]" +
                    ",[phone] FROM [dbo].[users] WHERE [uid] = " + uid, conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    DBUser[0].FName = reader.GetString(0);
                    DBUser[0].LName = reader.GetString(1);
                    DBUser[0].NName = reader.GetString(2);
                    DBUser[0].EMail = reader.GetString(3);
                    DBUser[0].RNumber = reader.GetInt32(4);
                    DBUser[0].Admin = reader.GetBoolean(5);
                    DBUser[0].TID1 = reader.GetInt32(6);
                    DBUser[0].TID2 = reader.GetInt32(7);
                    DBUser[0].TID3 = reader.GetInt32(8);
                    DBUser[0].TID4 = reader.GetInt32(9);
                    DBUser[0].PhoneNumber = reader.GetInt64(10);
                }

                reader.Close();
            }

            catch (Exception e)
            { excepter(e); return false; }

            return true;
        }

        public int teammemcount(string teamname)
        {
            int tcount=0;

            cmd = new SqlCommand("SELECT COUNT([UID]) FROM [dbo].[z" + teamname + "]", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    tcount = reader.GetInt16(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }
            return tcount;
        }

        public bool teamusersdata(ref DBvals[] DBUser, int[] uids)
        {
            foreach (int uid in uids)
            {
                int dblooper = 0;

                cmd = new SqlCommand("SELECT [first_name],[last_name],[nickname]" +
                    ",[email],[roster_num],[admin],[tids1],[tids2],[tids3],[tids4]" +
                    ",[phone] FROM [dbo].[users] WHERE [UID] = " + uid, conn);

                reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        DBUser[dblooper].FName = reader.GetString(0);
                        DBUser[dblooper].LName = reader.GetString(1);
                        DBUser[dblooper].NName = reader.GetString(2);
                        DBUser[dblooper].EMail = reader.GetString(3);
                        DBUser[dblooper].RNumber = reader.GetInt32(4);
                        DBUser[dblooper].Admin = reader.GetBoolean(5);
                        DBUser[dblooper].TID1 = reader.GetInt32(6);
                        DBUser[dblooper].TID2 = reader.GetInt32(7);
                        DBUser[dblooper].TID3 = reader.GetInt32(8);
                        DBUser[dblooper].TID4 = reader.GetInt32(9);
                        DBUser[dblooper].PhoneNumber = reader.GetInt64(10);

                        dblooper++;
                    }
                    reader.Close();
                }

                catch (Exception e)
                { excepter(e); return false; }
            }
            return true;
        }

        public void teamuids(ref int[] uids, string teamname, int tcount)
        {

            cmd = new SqlCommand("SELECT [UID] FROM [dbo].[z"
                + teamname + "]", conn);

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    for (int i = 0; i < tcount; i++)
                        uids[i] = reader.GetInt16(i);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

        }

        public string tid2name(int tid)
        {
            string teamname = "";
            cmd = new SqlCommand("SELECT [team_name] FROM [dbo]"
                + ".[teams] WHERE [tid] = " + tid, conn);

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    teamname = reader.GetString(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }
            return teamname;
        }

        public int tid2cuid(int tid)
        {
            int cuid = 0;
            cmd = new SqlCommand("SELECT [coach_uid] FROM [dbo]"
                + ".[teams] WHERE [tid] = " + tid, conn);

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    cuid = reader.GetInt16(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }
            return cuid;
        }

        public string uid2email(int uid)
        {
            string email = "";
            cmd = new SqlCommand("SELECT [email] FROM [dbo]"
                + ".[users] WHERE [uid] = " + uid, conn);

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
            return email;
        }

        public void uid2name(int tid, ref string fname)
        {
            cmd = new SqlCommand("SELECT [fname] FROM [dbo]"
                + ".[users] WHERE [uid] = " + uid, conn);

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    fname = reader.GetString(0);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }
        }

        public void uid2name(int tid, ref string fname, ref string lname)
        {
            cmd = new SqlCommand("SELECT [fname],[lname] FROM [dbo]"
                + ".[users] WHERE [uid] = " + uid, conn);

            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    fname = reader.GetString(0);
                    lname = reader.GetString(1);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }
        }

        // METHOD TO POPULATE FROM CONFIG FILE GOES HERE

    }
}
