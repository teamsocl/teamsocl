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

        public void getmr1message(int mrid)
        {
            conn.Open();

            cmd = new SqlCommand("SELECT [subject] FROM [dbo].[mr1] WHERE [mrid1] = " + mrid, conn);
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    Console.ReadKey();
                }
                reader.Close();
            }

            catch (Exception e)
            { excepter(e); }

            conn.Close();

        }

    }
}
