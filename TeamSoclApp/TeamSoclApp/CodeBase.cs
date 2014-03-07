using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class CodeBase : MainWindow
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
            if (SqlExec.login() == true) return true;
            return false;
        }
    }
}
