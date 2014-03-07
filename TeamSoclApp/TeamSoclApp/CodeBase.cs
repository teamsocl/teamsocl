using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    class CodeBase : MainWindow
    {
        public bool login()
        {
            if (SqlExec.login() == false) return false;

            if (user.PWord == player.PWord) return true;

            return false;
        }



        public bool register()
        {

            return true;
        }

        public bool user_populate()
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
            { }
        }
    }
}
