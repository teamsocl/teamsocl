using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace teamsocl
{
    class Program
    {
        
        static void Main(string[] args)
        {
            teamsocl.EventHandler.Texty();
        }
    }
}


// NOTEZ!!!

/*    the meat and taters of a sql interaction
            cmd = new SqlCommand("SELECT [email],[password],[admin],[uid] FROM [dbo].[security] WHERE [email] = '"+email+"'", conn);
            reader = cmd.ExecuteReader();
                        
            while (reader.Read())
            {
                var = reader.GetString(0);
                
            }
            reader.Close();

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }
            
*/

/*
Console.WriteLine("do you want exit? strike (y) or (q)");

workingInput = Console.ReadLine();                                // excaper
if (workingInput.ToLower() == "y") return;
else if (workingInput.ToLower() == "q") return;
*/