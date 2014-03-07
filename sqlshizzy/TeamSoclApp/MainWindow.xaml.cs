using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml;

namespace TeamSoclApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static bool loggedin = false;

        public static CodeBase code = new CodeBase();

        public MainWindow()
        {
            //code.Owner = this;
            InitializeComponent();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (code.authenticator() == true)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Owner = this;
                dashboard.Show();
            }
            else { }
        }
    }

}
