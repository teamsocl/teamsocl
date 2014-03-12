using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSoclApp
{
    public class ItemsInfo
    {
        public ItemsInfo(String title, String description, String color)
        {
            Title = title;
            Description = description;
            Color = color;
        }

        public String Title
        { get; set; }
        public String Description
        { get; set; }
        public String Color
        { get; set; }
    }
}
