using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class Messages
    {
        public bool fillmr1()
        {
            globals.mailer.emailer(globals.user.EMail,globals.player.EMail,globals.TITLE,globals.MESSAGE);
            //sqlunderbelly fillmr1();
            return true;
        }
    }
}
