using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public static class globals
    {
        public static Persona user = new Persona();
        public static Persona player = new Persona();
        
        public static SqlOverhead SqlConn = new SqlOverhead();
        public static SqlUnderbelly SqlExec = new SqlUnderbelly();

        public static CodeBase code = new CodeBase();

        public static weather forecast = new weather();

        public static string dtg;

        public static int UID, TID;
        public static int MRID1, MRID2, MRID3, MEID;

        public static System.Text.StringBuilder error = new System.Text.StringBuilder();
    }
}
