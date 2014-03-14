using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ComponentModel;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public BackgroundWorker worker = new BackgroundWorker();

        public Dashboard()
        {
            worker_init();
            InitializeComponent();   
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("SELECT * FROM [dbo].[z" + globals.user.teamnames[1].ToString().ToLower() + "]");
            Loading_Teams.Visibility = System.Windows.Visibility.Visible;

            if (globals.user.TIDs[0] != 0)
            { Team1Button.Visibility = System.Windows.Visibility.Visible;
                Team1Button.Content = globals.user.teamnames[0]; }

            if (globals.user.TIDs[1] != 0)
            { Team2Button.Visibility = System.Windows.Visibility.Visible; 
                Team2Button.Content = globals.user.teamnames[1]; }
            
            if (globals.user.TIDs[2] != 0)
            { Team3Button.Visibility = System.Windows.Visibility.Visible; 
                Team3Button.Content = globals.user.teamnames[2]; }
            
            if (globals.user.TIDs[3] != 0)
            { Team4Button.Visibility = System.Windows.Visibility.Visible; 
                Team4Button.Content = globals.user.teamnames[3]; }


            

            //T1ListView.ItemsSource = globals.teamtable1.DefaultView;
            T2ListView.ItemsSource = globals.teamtable2.DefaultView;
            T3ListView.ItemsSource = globals.teamtable3.DefaultView;
            T4ListView.ItemsSource = globals.teamtable4.DefaultView;

        }

        private void worker_init()
        {

            worker.RunWorkerCompleted 
                += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //theaded tasks here.
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Loading_Teams.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(globals.error).Length >= 5)
            {
                globals.mailer.emailer("teamsocl@outlook.com",
                    "teamsocl@outlook.com", "ERROR LOG FOR "
                    + globals.user.UID, "ERROR LOG FOR UID "
                    + globals.user.UID + " CONTAINS THE FOLLOWING: "
                    + Convert.ToString(globals.error));
            }
            // ERROR HANDLING!!!
            MessageBox.Show(globals.error.ToString());
            // ERROR HANDLING END!!!
            Owner.Show();
            globals.flush();
            this.Close();
        }

        private void MessagesButton_Click(object sender, RoutedEventArgs e)
        { PannelClear(1); }

        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        { PannelClear(2); }

        private void Team1Button_Click(object sender, RoutedEventArgs e)
        { PannelClear(3); }

        private void Team2Button_Click(object sender, RoutedEventArgs e)
        { PannelClear(4); }

        private void Team3Button_Click(object sender, RoutedEventArgs e)
        { PannelClear(5); }

        private void Team4Button_Click(object sender, RoutedEventArgs e)
        { PannelClear(6); }

        public void PannelClear(int activepannel)
        {

            if (activepannel == 1) MessagePannel.Visibility = System.Windows.Visibility.Visible;
            else { MessagePannel.Visibility = System.Windows.Visibility.Hidden; }
            if (activepannel == 2) TeamsPannel.Visibility = System.Windows.Visibility.Visible;
            else { TeamsPannel.Visibility = System.Windows.Visibility.Hidden; }
            if (activepannel == 3) Team1Pannel.Visibility = System.Windows.Visibility.Visible;
            else { Team1Pannel.Visibility = System.Windows.Visibility.Hidden; }
            if (activepannel == 4) Team2Pannel.Visibility = System.Windows.Visibility.Visible;
            else { Team2Pannel.Visibility = System.Windows.Visibility.Hidden; }
            if (activepannel == 5) Team3Pannel.Visibility = System.Windows.Visibility.Visible;
            else { Team3Pannel.Visibility = System.Windows.Visibility.Hidden; }
            if (activepannel == 6) Team4Pannel.Visibility = System.Windows.Visibility.Visible;
            else { Team4Pannel.Visibility = System.Windows.Visibility.Hidden; }
        }

        private void T1DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int rowsuid = (int) T1DG.SelectedItem;
        }
    }
}
