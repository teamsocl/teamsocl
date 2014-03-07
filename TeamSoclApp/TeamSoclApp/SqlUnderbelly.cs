using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class SqlUnderbelly : MainWindow
    {
        public bool login()
        {
            SqlConn.cmd = new SqlCommand("SELECT [email],[password],[admin],[uid] FROM [dbo]."
                + "[security] WHERE [email] = '" + user.EMail.ToLower() + "'", SqlConn.conn);
            SqlConn.reader = SqlConn.cmd.ExecuteReader();
            try
            {
                while (SqlConn.reader.Read())
                {
                    player.EMail = SqlConn.reader.GetString(0);
                    player.PWord = SqlConn.reader.GetString(1);
                    player.Admin = SqlConn.reader.GetBoolean(2);
                    player.UID = SqlConn.reader.GetInt32(3);
                }

                SqlConn.reader.Close();
            }
            catch (Exception e)
            {
                error.Append(" ERROR: " + e);
                return false;
            }

            return true;
        }

        public bool user_populate()
        {
            SqlConn.cmd = new SqlCommand("SELECT [first_name],[last_name],[nickname]" +
                    ",[email],[roster_num],[admin],[tids1],[tids2],[tids3],[tids4]" +
                    ",[phone] FROM [dbo].[users] WHERE [uid] = " + user.UID, SqlConn.conn);
            SqlConn.reader = SqlConn.cmd.ExecuteReader();

            try
            {
                while (SqlConn.reader.Read())
                {
                    user.FName = SqlConn.reader.GetString(0);
                    user.LName = SqlConn.reader.GetString(1);
                    user.NName = SqlConn.reader.GetString(2);
                    user.EMail = SqlConn.reader.GetString(3);
                    user.RNumber = SqlConn.reader.GetInt32(4);
                    user.Admin = SqlConn.reader.GetBoolean(5);
                    user.TID1 = SqlConn.reader.GetInt32(6);
                    user.TID2 = SqlConn.reader.GetInt32(7);
                    user.TID3 = SqlConn.reader.GetInt32(8);
                    user.TID4 = SqlConn.reader.GetInt32(9);
                    user.PhoneNumber = SqlConn.reader.GetInt64(10);
                }

                SqlConn.reader.Close();
            }

            catch (Exception e)
            {
                error.Append(" ERROR: " + e);
                return false;
            }
            return true;
        }

    }
}
