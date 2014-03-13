using System;
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

        private void Register_Button(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("wassup");
            // INPUT VALIDATION
            if (true) // if (globals.inputvalidation(register_email.Text, 0) == true) 
            { globals.player.EMail = register_email.Text; }
            else
            { MessageBox.Show("Your email was entered incorrectly!"); return; }

            if (globals.SqlExec.is1in2row3(globals.player.EMail, "security", "email") == true)
            { MessageBox.Show("This email already exists!"); return; }

            if (true) // if (inputvalidation(register_first_n.Text, 1) == true) 
            { globals.player.FName = register_first_n.Text; }
            else
            { MessageBox.Show("Your first name was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_last_n.Text, 1) == true) 
            { globals.player.LName = register_last_n.Text; }
            else
            { MessageBox.Show("Your last name was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_nickname.Text, 1) == true) 
            { globals.player.NName = register_nickname.Text; }
            else
            { MessageBox.Show("Your nick name was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_jersey_num, 2) == true) 
            { globals.player.RNumber = Convert.ToInt16(register_jersey_num.Text); }
            else
            { MessageBox.Show("Your roster number was entered incorrectly!"); return; }

            if (true) // if (inputvalidation(register_phone, 3) == true) 
            { globals.player.PhoneNumber = Convert.ToDouble(register_phone.Text); }
            else
            { MessageBox.Show("Your phone number was entered incorrectly!"); return; }

            if (register_pwd.Text == register_pwd_confirm.Text)  // && inputvalidation(register_pwd) == true)
            {
                if (true) // if (inputvalidation(register_pwd, 4) == true
                {
                    globals.player.PWord = register_pwd.Text;
                    if (globals.code.register() == true)
                    {
                        MessageBox.Show("Thanks for registering!\nYou'll recieve an email to confirm your account shortly!");
                        this.Close();
                    }
                    else
                    { MessageBox.Show("Error!"); }
                }
            }
            else
            {
                MessageBox.Show("Your passwords do not match!");
            }
            
        }
    }
}
