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
                error.Append(e + " ERROR: ");
            }

            return false;
        }
    }
}
