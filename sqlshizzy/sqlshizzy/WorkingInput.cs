using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamsocl
{
    public class WorkingInput
    {
        public string String = "";
        public char CharVal;

        public char Char()
        {
            string temp = CharVal.ToString().ToLower();
            CharVal = Convert.ToChar(temp);
            return CharVal;
        }

        public char Char(ConsoleKeyInfo pressed)
        {
            CharVal = pressed.KeyChar;
            return pressed.KeyChar;
        }
    }
}




