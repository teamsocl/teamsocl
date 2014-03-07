using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class SqlOverheadClient : SqlOverhead
    {

        // LOGIN/AUTH METHODS

        public bool authget()
        {
            cmd = new SqlCommand("SELECT [email],[password],[admin],[uid] FROM [dbo]."
                + "[security] WHERE [email] = '" + EventHandler.User.EMail.ToLower() + "'", conn);
            reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    EventHandler.DBload.EMail = reader.GetString(0);
                    EventHandler.DBload.PWord = reader.GetString(1);
                    EventHandler.DBload.Admin = reader.GetBoolean(2);
                    EventHandler.DBload.UID = reader.GetInt32(3);
                    EventHandler.User.UID = EventHandler.DBload.UID;
                }

                reader.Close();
            }
            catch (Exception e)
            { excepter(e); return false; }
            return true;
        }



        public bool broadcaster(int tid, string message, int uid, bool sticky, int locid, string etype) // NOT COMPLETE!!! add EVENT's DTG once DTG function is figured out.
        {
            string teamname = tid2name(tid);

            int nextBID = getcurbid();

            int stickybit = 0;

            if (sticky == true) stickybit = 1;

            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[broadcast] ([bid],[tid]"
                    + ",[team_name],[posteruid],[pdtg],[edtg],[content],[sticky],[locid]"
                    + ",[etype]) VALUES(" + nextBID + "," + tid + ",'" + teamname
                    + "'," + uid + "," + DateTime.Now + "," + DateTime.Now + ",'"
                    + message + "'," + stickybit + "," + locid + ",'" + etype
                    + "')", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { excepter(e); return false; }
            return true;
        }

        public bool fetchdaemonmessages()  //INCOMPLETE
        {
            // query message via sqloverhead's fetchdaemonmessage for 1 message that isn't "completed"/1, and still "active"/0 in daemond message queue...
            string messagetype = "";
            switch (messagetype)
            {
                case "":
                    {
                        break;
                    }
            }


            return true;
        }

        public bool jointeamack()  // NEEDS FIXIN!!!!!
        // on ACK from the coach, inflate the player on the team, then add the team ID to the player's creds.
        {
            DBvals DBUser = new DBvals();

            int DID = 0;
            int UID = 0;
            int TID = 0;
            string message = "";

            cmd = new SqlCommand("SELECT TOP 1 [did],[uid],[message]" +
                    ",[tid] FROM [dbo].[daemond] WHERE [action] = 'TREQUEST' AND [resolved] = 0", conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    DID = reader.GetInt16(0);
                    UID = reader.GetInt16(1);
                    message = reader.GetString(2);
                    TID = reader.GetInt16(3);
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); return false; }

            if (message == @"/APPROVED")
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[coachmessages] ([did],[uid],[tid],[action],"
                        + "[message],[resolved]) VALUES(" + UID
                        + "," + UID + "," + TID + ",'','" + DBUser.NName
                        + "'," + DBUser.PhoneNumber + ",'" + DBUser.EMail
                        + "',0,0,0,0)", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                { excepter(e); return false; }
                // mail coach 
            }
            else
            {
                cmd = new SqlCommand("SELECT [first_name],[last_name],[nickname]" +
                    ",[email],[roster_num],[admin],[tids1],[tids2],[tids3],[tids4]" +
                    ",[phone],[privacy] FROM [dbo].[users] WHERE [uid] = " + UID, conn);
                reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        DBUser.FName = reader.GetString(0);
                        DBUser.LName = reader.GetString(1);
                        DBUser.NName = reader.GetString(2);
                        DBUser.EMail = reader.GetString(3);
                        DBUser.RNumber = reader.GetInt32(4);
                        DBUser.Admin = reader.GetBoolean(5);
                        DBUser.TID1 = reader.GetInt32(6);
                        DBUser.TID2 = reader.GetInt32(7);
                        DBUser.TID3 = reader.GetInt32(8);
                        DBUser.TID4 = reader.GetInt32(9);
                        DBUser.PhoneNumber = reader.GetInt64(10);
                        DBUser.Privacy = reader.GetBoolean(11);
                    }

                    reader.Close();
                }

                catch (Exception e)
                { excepter(e); return false; }

                if (DBUser.TID1 == 0)
                { if (jointeamfilltids(1, TID, UID) == false) return false; }
                else if (DBUser.TID2 == 0)
                { if (jointeamfilltids(2, TID, UID) == false) return false; }
                else if (DBUser.TID3 == 0)
                { if (jointeamfilltids(3, TID, UID) == false) return false; }
                else if (DBUser.TID4 == 0)
                { if (jointeamfilltids(4, TID, UID) == false) return false; }
                else
                {
                    //send mail to coach saying player's aready in too many teams
                    //send mail to player letting him know he cant join cuz he's full
                    return false;
                }

                string tname = tid2name(TID);

                //WRITE DUDE!!!
                try
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[z" + tname + "] ([uid],"
                        + "[first_name],[last_name],[roster_num],[nickname],"
                        + "[phone],[email],[privacy]) VALUES(" + UID
                        + ",'" + DBUser.FName + "','" + DBUser.LName
                        + "'," + DBUser.RNumber + ",'" + DBUser.NName
                        + "'," + DBUser.PhoneNumber + ",'" + DBUser.EMail
                        + "',0,0,0,0)", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                { excepter(e); return false; }

                // resolve daemond message
                try
                {
                    cmd = new SqlCommand("UPDATE [dbo].[daemond] ([resolved]) "
                        + "VALUES(1) WHERE [did] = " + DID, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                { excepter(e); return false; }


            }
            return true;
        }

        public bool jointeamfilltids(int slot, int TID, int UID)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[users] ([tids" + slot + "]) VALUES(" + TID
                    + ") WHERE [uid]=" + UID, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            { excepter(e); return false; }
            return true;
        }

        public bool jointeamplayer(int tid)  // NOT FINISHED
        {

            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[daemond] (???????"
                    + "?????????????"
                    + "??????) VALUES"
                    + "("//????????
                    + ",???????)", conn);
                cmd.ExecuteNonQuery();


                //cmd = new SqlCommand("INSERT INTO [dbo].[security] ([uid],[password],[admin],"
                //    + "[email],[active]) VALUES"
                //    + "(" + nextUID + ",'" + passWord + "',1,'" + eMail + "',0)", conn);
                //cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            { excepter(e); return false; }
            return true;
        }

        public bool jointeamreq(int tid, int UID, ref int cuid, ref string cname, ref string tname, ref string cemail)
        // takes in the team ID, returns the coache's ID, his first name, and the team's name via REF, bool for SQL error.
        {

            cmd = new SqlCommand("SELECT [coach_uid],[team_name],[coachf],[ FROM [dbo]."
                + "[teams] WHERE [tid] = " + tid, conn);
            reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    cuid = reader.GetInt16(0);
                    tname = reader.GetString(1);
                    cname = reader.GetString(2);
                }
                reader.Close();
            }
            catch (Exception e)
            { excepter(e); return false; }

            cmd = new SqlCommand("SELECT [email] FROM [dbo]."
                + "[users] WHERE [uid] = " + cuid, conn);
            reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    cemail = reader.GetString(0);
                }
                reader.Close();
            }
            catch (Exception e)
            { excepter(e); return false; }

            int nextDID = 0;
            nextDID = getcurdid();
            nextDID++;

            try
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[daemond] ([did],[uid],"
                    + "[action],[message],[resolved]) VALUES (" + nextDID
                    + "," + UID + ",'TREQUEST','" + tid + "',0)", conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                excepter(e); return false;
            }

            return true;
        }

    }
}
