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
        public Persona user = new Persona();
        public Persona player = new Persona();
        public Persona[] playerarray;

        public SqlOverhead SqlConn = new SqlOverhead();
        public SqlUnderbelly SqlExec = new SqlUnderbelly();

        public CodeBase code = new CodeBase();

        public System.Text.StringBuilder error = new System.Text.StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.EMail = Convert.ToString(login_email_input.Text);
            user.PWord = Convert.ToString(login_password_input.Text);

            if (user.PWord == "" || user.EMail == "")
            {
                MessageBox.Show("You haven't entered an Email or Password");
                return;
            }

            if (code.login() == true)
            {
                user.UID = player.UID;

                //code.user_populate

                Dashboard dash = new Dashboard();
                dash.Owner = this;
                dash.Show();
                this.Hide();
            }
            else
            { MessageBox.Show("You've entered an invalid Email or Password\nor you're not connected to the internet"); }



        }
    }
}
