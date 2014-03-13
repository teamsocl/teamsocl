using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class ItemsInfo
    {
        public ItemsInfo(String tabheader, String color1, String color2)
        {
            TabHeader = tabheader;
            Color1 = color1;
            Color2 = color2;
        }

        public String TabHeader
        { get; set; }
        public String Color1
        { get; set; }
        public String Color2
        { get; set; }
    }
}
