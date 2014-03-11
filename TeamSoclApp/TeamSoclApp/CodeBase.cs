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

        public bool jointeam() // joins a team based on applying global.user to team ID'd by global.TID
        {
            if (globals.SqlExec.tidtocuid() == false) return false; //gets CUID
            globals.player.UID = globals.CUID;
            if (globals.SqlExec.tidtotname() == false) return false; //gets team's name
            if (globals.SqlExec.player_populate() == false) return false; //pulls coach data
            if (globals.SqlExec.jointeam() == false) return false; //joins globals.user to team's table provisionally
            if (globals.messager.fillmr1() == false) return false; //writes the mr1 table message

            return true;
        }

        public bool register(int teamid)
        {
            if (globals.SqlExec.register() == true)
            {
                // INPUT VALIDATION
                globals.user.EMail = 
                globals.user.FName =
                globals.user.LName = 
                globals.user.RNumber =
                globals.user.PhoneNumber = 
                globals.user.Privacy = 
                globals.user.PWord =
                // INPUT VALIDATION

                //registry message
                return true;
            }
            return false;
        }

        public bool user_populate()
        {
            if (globals.SqlExec.user_populate() == false) return false;
            return true;
        }
    }
}
