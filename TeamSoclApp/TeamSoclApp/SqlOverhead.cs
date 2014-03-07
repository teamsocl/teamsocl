using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class SqlOverhead : MainWindow
    {
        public SqlConnection conn = new SqlConnection(ConnString());
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

        public void BuildStringFromConfig() // 0% - populate connection string via included config file
        {
            //server = 
            //database =
            //uid =
            //password =
        }
    }
}
