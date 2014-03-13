using System;
using System.Collections.Generic;
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
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ItemsInfo> lst = new List<ItemsInfo>();

            //visibility of stackpannels set to nothing!

            if (globals.user.TID1 != 0)
            { Team1Button.Visibility = System.Windows.Visibility.Visible; Team1Button.Content = globals.SqlExec.tidtotname(globals.user.TID1); }

            if (globals.user.TID2 != 0)
            { Team2Button.Visibility = System.Windows.Visibility.Visible; Team2Button.Content = globals.SqlExec.tidtotname(globals.user.TID2); }
            
            if (globals.user.TID3 != 0)
            { Team3Button.Visibility = System.Windows.Visibility.Visible; Team3Button.Content = globals.SqlExec.tidtotname(globals.user.TID3); }
            
            if (globals.user.TID4 != 0)
            { Team4Button.Visibility = System.Windows.Visibility.Visible; Team4Button.Content = globals.SqlExec.tidtotname(globals.user.TID4); }
            
            //tabControl.ItemsSource = lst;
            //tabControl.SelectedIndex = 0;

            worker_init();
        }

        private void worker_init()
        {
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Get team1 data
            //Get team2 data
            //Get team3 data
            //Get team4 data
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Team1_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1).ToString();
            //Team2_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);
            //Team3_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);
            //Team4_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);

            //hide cover pannels...
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
    }
}
