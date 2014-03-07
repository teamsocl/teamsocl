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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeamSoclApp
{

    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Persona user = new Persona();
        //public Persona player = new Persona();
        //public Persona[] playerarray;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            globals.user.EMail = Convert.ToString(login_email_input.Text);
            globals.user.PWord = Convert.ToString(login_password_input.Text);

            if (globals.user.PWord == "" || globals.user.EMail == "")
            {
                MessageBox.Show("You haven't entered an Email or Password");
                return;
            }

            globals.user.UID = globals.player.UID;

            if (globals.code.login())
            {
                if (globals.code.user_populate() == false)
                {
                    MessageBox.Show("You've entered an invalid Email or Password\nor you're not connected to the internet");
                }

                Dashboard dash = new Dashboard();
                dash.Owner = this;
                dash.Show();
                this.Hide();

                MessageBox.Show(globals.forecast.wx("98597"));
            }
            else
            { MessageBox.Show("You've entered an invalid Email or Password\nor you're not connected to the internet"); }
        }

        private void Register_Click(object sender, MouseButtonEventArgs e)
        {
            RegisterUser URegister = new RegisterUser();
            URegister.Owner = this;
            URegister.Show();
        }
    }
}
