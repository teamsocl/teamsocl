using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamSoclApp
{
    class Program
    {
        public static SqlOverhead SqlConn = new SqlOverhead();
        
        static void Main(string[] args)
        {
            do
            {
                if (SqlConn.checkmr1message() == true)
                {
                    SqlConn.sendMr1Message();
                }
                else
                    Console.WriteLine("MR1, Nothing Found");
                if (SqlConn.checkmr2message() == true)
                {
                    SqlConn.sendMr2Message();
                }
                else
                    Console.WriteLine("MR2, Nothing Found");
                if (SqlConn.checkmwelcmessage() == true)
                {
                    SqlConn.sendmwelcMessage();
                }
                else
                    Console.WriteLine("Mwelc, Nothing Found");


                System.Threading.Thread.Sleep(5000);
                //Wait 5 seconds
            }
            while (true);           
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