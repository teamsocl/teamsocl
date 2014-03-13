using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class UserPersona : Persona
    {
        public string[] teamnames = new string[4];

        public UserPersona()
        {
            FName = "";
            LName = "";
            NName = "";
            EMail = "";
            PWord = "";
            RNumber = 0;
            UID = 0;
            PhoneNumber = 0000000000;
            Admin = false;
            for (int i = 0; i <= 3; i++)
            {
                teamnames[i] = "";
            }
        }
    }
}
