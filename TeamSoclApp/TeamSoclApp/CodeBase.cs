using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class CodeBase
    {
        public bool login()
        {
            if (globals.SqlExec.login() == true)
            {
                if (globals.user.PWord == globals.player.PWord) return true;
            }

            return false;
        }

        public bool register()
        {
            return true;
        }

        public bool user_populate()
        {
            if (globals.SqlExec.login() == true) return true;
            return false;
        }
    }
}
