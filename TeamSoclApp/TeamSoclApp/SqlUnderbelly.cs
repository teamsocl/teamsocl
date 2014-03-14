using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class SqlUnderbelly
    {
        public void connreset()  // reset SQL connection
        {
            globals.SqlConn.conn.Close();
            globals.SqlConn.conn.Open();
        }

        // <MESSAGING>

        public bool fillmr1()
        {
            if (getcurmrid1() == false) return false;

            int nextMRID = globals.MRID1;
            
            nextMRID++;

            try
            {
                globals.SqlConn.cmd = new SqlCommand("INSERT INTO [dbo].[mr1] "
                    + "([mrid1],[uid],[tid],[cuid],[pdtg],[subject]" 
                    + ",[content]) VALUES(" + nextMRID + "," + globals.user.UID
                    + "," + globals.TID + "," + globals.CUID + ","
                    + globals.PDTG + ",'Team member join request "
                    + "on TeamSocl','Hello " + globals.player.FName
                    + ", the TeamSocl member "+ globals.user.FName
                    + " " + globals.user.LName + " would like to join " 
                    + "your team, the " + globals.TNAME + "s.  Please "
                    + "log into TeamSocl to accept this player.    " 
                    + " V/r TeamSocl')", globals.SqlConn.conn);
                globals.SqlConn.cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }
            return true;
        }

        // </MESSAGING>
        // <TOOLS>

        public bool getdtg()  // Gets the DTG from SQL Server
        {
            string dtg = "";

            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT CURRENT_TIMESTAMP", globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    dtg = globals.SqlConn.reader.GetString(0);
                }
                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            globals.dtg = dtg.Substring(0, 16);

            return true;
        }

        public bool getcuruid() // gets current maximum User ID
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT MAX(uid) FROM [dbo].[users]", globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.UID = Convert.ToInt16(globals.SqlConn.reader.GetValue(0));
                }
                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            return true;
        }

        public bool getcurtid() // gets current maximum Team ID
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT MAX(tid) FROM [dbo].[teams]", globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.TID = Convert.ToInt16(globals.SqlConn.reader.GetValue(0));
                }
                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            return true;
        }

        public bool getcurmrid1() // gets current maximum Register Message Table 1 ID
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT MAX(ejtid) FROM [dbo].[mr1]", globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.MRID1 = Convert.ToInt16(globals.SqlConn.reader.GetValue(0));
                }
                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            return true;
        }

        public bool getcurmrid2() // gets current maximum Register Message Table 2 ID
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT MAX(ejtid) FROM [dbo].[mr2]", globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.MRID2 = Convert.ToInt16(globals.SqlConn.reader.GetValue(0));
                }
                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            return true;
        }
        
        public bool getcurmrid3() // gets current maximum Register Message Table 3 ID
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT MAX(ejtid) FROM [dbo].[mr3]", globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.MRID3 = Convert.ToInt16(globals.SqlConn.reader.GetValue(0));
                }
                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            return true;
        }

        public bool is1in2row3(string value, string table, string rowname) // Is Var1 in Var2 Table, Row Var3
        {
            connreset();

            bool exists = false;

            globals.SqlConn.cmd = new SqlCommand("SELECT COUNT(1) FROM [dbo].["
                + table + "] WHERE [" + rowname + "] = '" + value
                + "'", globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    if (globals.SqlConn.reader.GetInt32(0) >= 1) exists = true;
                }

                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }
            return exists;
        }

        public bool jointeam() // place globals.user data into a team's table.
        {
            try
            {
                globals.SqlConn.cmd = new SqlCommand("INSERT INTO [dbo].[z" 
                    + globals.TNAME.ToLower() + "] ([uid],[first_name]," 
                    + "[last_name],[roster_num],[nickname],[phone],[email]" 
                    + ",[privacy],[approved]) VALUES(" + globals.user.UID
                    + ",'" + globals.user.FName + "','" + globals.user.LName
                    + "'," + globals.user.RNumber + ",'" + globals.user.NName
                    + "'," + globals.user.PhoneNumber + ",'" + globals.user.EMail 
                    + "'," + globals.user.Privacy + ",0)", globals.SqlConn.conn);
                globals.SqlConn.cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }
            return true;
        }

        public bool tidtocuid() // takes globals.TID and returns cuid to globals.CUID
        {

            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT [coach_uid] FROM [dbo].[teams] WHERE [tid] = " + globals.TID, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.CUID = globals.SqlConn.reader.GetInt16(0);
                }

                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }
            return true;
        }

        public int tidtocuid(int TID) // takes globals.TID and returns cuid to globals.CUID
        {
            connreset();

            int CUID = 0;

            globals.SqlConn.cmd = new SqlCommand("SELECT [coach_uid] FROM [dbo].[teams] WHERE [tid] = " + TID, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    CUID = globals.SqlConn.reader.GetInt32(0);
                }

                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" tidtocuid "+TID+" ERROR: " + e);
            }
            return CUID;
        }

        public bool tidtotname() // takes globals.TID and returns team name to globals.TNAME
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT [team_name] FROM [dbo].[teams] WHERE [tid] = " + globals.TID, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.TNAME = globals.SqlConn.reader.GetString(0);
                }

                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }
            return true;
        }

        public string tidtotname(int TID) // takes globals.TID and returns team name to globals.TNAME
        {
            string TIDNAME = "";
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT [team_name] FROM [dbo].[teams] WHERE [tid] = " + TID, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    TIDNAME = globals.SqlConn.reader.GetString(0);
                }

                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return "ERROR";
            }
            return TIDNAME;
        }

        // </TOOLS>
        // <METHODS>

        public bool login() // corresponds with code.login and MainWindo
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT [email],[password],[admin],[uid] FROM [dbo]."
                + "[security] WHERE [email] = '" + globals.user.EMail.ToLower() + "'", globals.SqlConn.conn);

            try
            {
                globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();
                while (globals.SqlConn.reader.Read())
                {
                    globals.player.EMail = globals.SqlConn.reader.GetString(0);
                    globals.player.PWord = globals.SqlConn.reader.GetString(1);
                    globals.player.Admin = globals.SqlConn.reader.GetBoolean(2);
                    globals.player.UID = globals.SqlConn.reader.GetInt32(3);
                }

                globals.SqlConn.reader.Close();
            }
            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            return true;
        }

        public bool register() // corresponds with code.register and Register
        {
            if (getcuruid() == false) return false;

            int nextUID = globals.UID;

            nextUID++;

            try
            {
                globals.SqlConn.cmd = new SqlCommand("INSERT INTO [dbo].[users] ([uid],"
                    + "[first_name],[last_name],[roster_num],[nickname],[admin]"
                    + ",[phone],[email],[tids1],[tids2],[tids3],[tids4]) VALUES"
                    + "(" + nextUID + ",'" + globals.player.FName + "','"
                    + globals.player.LName + "'," + globals.player.RNumber
                    + ",'" + globals.player.NName + "',0,"
                    + globals.player.PhoneNumber + ",'" + globals.player.EMail
                    + "',0,0,0,0)", globals.SqlConn.conn);
                globals.SqlConn.cmd.ExecuteNonQuery();


                globals.SqlConn.cmd = new SqlCommand("INSERT INTO [dbo].[security] ([uid],"
                    + "[password],[admin],[email],[active]) VALUES(" + nextUID
                    + ",'" + globals.player.PWord + "',0,'" + globals.player.EMail
                    + "',0)", globals.SqlConn.conn);
                globals.SqlConn.cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }
            return true;
        }

        public bool player_populate()  // Populates globals.player for the current globals.player.UID
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT [first_name],[last_name],[nickname]" +
                    ",[email],[roster_num],[admin],[tids1],[tids2],[tids3],[tids4]" +
                    ",[phone] FROM [dbo].[users] WHERE [uid] = " + globals.player.UID, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.player.FName = globals.SqlConn.reader.GetString(0);
                    globals.player.LName = globals.SqlConn.reader.GetString(1);
                    globals.player.NName = globals.SqlConn.reader.GetString(2);
                    globals.player.EMail = globals.SqlConn.reader.GetString(3);
                    globals.player.RNumber = globals.SqlConn.reader.GetInt32(4);
                    globals.player.Admin = globals.SqlConn.reader.GetBoolean(5);
                    for (int i = 0; i <= 3; i++)
                    { globals.player.TIDs[i] = globals.SqlConn.reader.GetInt32(i + 6); }
                    globals.player.PhoneNumber = globals.SqlConn.reader.GetInt64(10);
                }

                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }
            return true;
        } 

        public bool user_populate()  // Populates globals.user for the localuser's dataset
        {
            connreset();

            globals.SqlConn.cmd = new SqlCommand("SELECT [first_name],[last_name],[nickname]" +
                    ",[email],[roster_num],[admin],[tids1],[tids2],[tids3],[tids4]" +
                    ",[phone] FROM [dbo].[users] WHERE [uid] = " + globals.user.UID, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    globals.user.FName = globals.SqlConn.reader.GetString(0);
                    globals.user.LName = globals.SqlConn.reader.GetString(1);
                    globals.user.NName = globals.SqlConn.reader.GetString(2);
                    globals.user.EMail = globals.SqlConn.reader.GetString(3);
                    globals.user.RNumber = globals.SqlConn.reader.GetInt32(4);
                    globals.user.Admin = globals.SqlConn.reader.GetBoolean(5);
                    for (int i = 0; i <= 3; i++)
                    { globals.user.TIDs[i] = globals.SqlConn.reader.GetInt32(i + 6); }
                    globals.user.PhoneNumber = globals.SqlConn.reader.GetInt64(10);
                }

                globals.SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
                return false;
            }

            for (int i = 0; i <= 3; i++)
            {
                if (globals.user.TIDs[i] != 0)
                {
                    globals.user.teamnames[i] = globals.SqlExec.tidtotname(globals.user.TIDs[i]);
                    if (globals.SqlExec.tidtocuid(globals.user.TIDs[i]) == globals.user.UID)
                    {
                        pullteamcoach(i);
                    }
                    else
                    { pullteam(i); }

                }
            }
            return true;
        }


        public bool pullteam(int inum)
        {
            connreset();

            string cmdstrng = "SELECT [first_name],[last_name],[nickname],[roster_num] FROM [dbo].[z" + globals.user.teamnames[inum].ToString().ToLower() + "] WHERE [privacy] = 0";
            globals.SqlConn.dataadapter = new SqlDataAdapter(cmdstrng, globals.SqlConn.conn);

            try
            {
                switch(inum)
                {
                    case 0:
                    {
                        globals.SqlConn.dataadapter.Fill(globals.teamtable1);
                        break;
                    }
                    case 1:
                    {
                        globals.SqlConn.dataadapter.Fill(globals.teamtable2);
                        break;
                    }
                    case 2:
                    {
                        globals.SqlConn.dataadapter.Fill(globals.teamtable3);
                        break;
                    }
                    case 3:
                    {
                        globals.SqlConn.dataadapter.Fill(globals.teamtable4);
                        break;
                    }
                }   
            }
            catch (Exception e)
            {
                globals.error.Append(" D.A. ERROR: " + e);
                return false;
            }

            enumteamtable(inum);
            
            return true;
        }

        public void enumteamtable(int inum)
        {
            int rownum = 0;

            connreset();

            string cmdstrng = "SELECT COUNT([UID]) FROM [dbo].[z" + globals.user.teamnames[inum].ToString().ToLower() + "]";

            globals.SqlConn.cmd = new SqlCommand(cmdstrng, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    rownum = globals.SqlConn.reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
            }

            // 2nd half

            connreset();

            globals.tableUIDs[inum] = new int[rownum+1];

            cmdstrng = "SELECT [UID] FROM [dbo].[z" + globals.user.teamnames[inum].ToString().ToLower() + "]";

            globals.SqlConn.cmd = new SqlCommand(cmdstrng, globals.SqlConn.conn);
            globals.SqlConn.reader = globals.SqlConn.cmd.ExecuteReader();

            try
            {
                while (globals.SqlConn.reader.Read())
                {
                    for ( int i = 0 ; i<=rownum ; i++ )
                    {
                        globals.tableUIDs[inum][i] = globals.SqlConn.reader.GetInt32(0);
                    }
                }
            }

            catch (Exception e)
            {
                globals.error.Append(" ERROR: " + e);
            }
        }

        // pulls all on coachview

        public bool pullteamcoach(int inum)
        {
            string cmdstrng = "SELECT * FROM [dbo].[z" + globals.user.teamnames[inum].ToString().ToLower() + "]";
            globals.SqlConn.dataadapter = new SqlDataAdapter(cmdstrng, globals.SqlConn.conn);

            connreset();

            try
            {
                switch (inum)
                {
                    case 0:
                        {
                            globals.SqlConn.dataadapter.Fill(globals.teamtable1);
                            break;
                        }
                    case 1:
                        {
                            globals.SqlConn.dataadapter.Fill(globals.teamtable2);
                            break;
                        }
                    case 2:
                        {
                            globals.SqlConn.dataadapter.Fill(globals.teamtable3);
                            break;
                        }
                    case 3:
                        {
                            globals.SqlConn.dataadapter.Fill(globals.teamtable4);
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                globals.error.Append(" D.A. ERROR: " + e);
                return false;
            }
            return true;
        }

        // </METHODS>
    }
}
