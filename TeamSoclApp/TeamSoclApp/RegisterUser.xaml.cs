﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeamSoclApp
{
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // INPUT VALIDATION
            if (true) // if (inputvalidation(register_email.Text, 0) == true) 
            { globals.player.EMail = register_email.Text; }
            else
            { MessageBox.Show("Your email was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_first_n.Text, 1) == true) 
            { globals.player.FName = register_first_n.Text; }
            else
            { MessageBox.Show("Your first name was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_last_n.Text, 1) == true) 
            { globals.player.LName = register_last_n.Text; }
            else
            { MessageBox.Show("Your last name was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_jersey_num, 2) == true) 
            { globals.player.RNumber = Convert.ToInt16(register_jersey_num); }
            else 
            { MessageBox.Show("Your roster number was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_phone, 3) == true) 
            { globals.player.PhoneNumber = Convert.ToDouble(register_phone); }
            else
            { MessageBox.Show("Your phone number was entered incorrectly!"); return; }

            if(true)

            if (register_pwd == register_pwd_confirm )  // && inputvalidation(register_pwd) == true)
            {
                if (true) // if (inputvalidation(register_pwd, 4) == true
                {
                    globals.player.PWord = register_pwd.Text;
                    globals.code.register();
                }
            }
            else
            {
                MessageBox.Show("Your passwords do not match!");
            }
            
        }
    }
}
