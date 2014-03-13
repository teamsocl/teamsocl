using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public static class globals
    {
        // class block

        public static UserPersona user = new UserPersona();
        public static Persona player = new Persona();
        public static DataTable[] teamtable = new DataTable[4];
        
        public static SqlOverhead SqlConn = new SqlOverhead();
        public static SqlUnderbelly SqlExec = new SqlUnderbelly();

        public static Emailer mailer = new Emailer();
        public static Messages messager = new Messages();
        //public static InputValidation validator = new InputValidation();

        public static CodeBase code = new CodeBase();

        // weather block

        public static weather forecast = new weather();

        // date time block

        public static string dtg;

        // messaging block

        public static int UID, TID, CUID;
        public static int MRID1, MRID2, MRID3, MEID;
        public static string MESSAGE, TITLE, PDTG, CFNAME, TNAME;

        // error block

        public static System.Text.StringBuilder error = new System.Text.StringBuilder();

        // cleanup

        public static void flush()
        {
            user = new UserPersona();
            player = new Persona();
        }

        public static void flushmessage()
        {
            UID = 0;
            TID = 0;
            CUID = 0;
            MRID1 = 0;
            MRID2 = 0;
            MRID3 = 0;
            MESSAGE = "";
            TNAME = "";
            TITLE = "";
            PDTG = "";
        }
    }
}
