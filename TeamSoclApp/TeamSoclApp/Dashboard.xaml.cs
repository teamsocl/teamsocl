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
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ( Convert.ToString(globals.error).Length>=5)
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

            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            // get data here
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Team1_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1).ToString();
            //Team2_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);
            //Team3_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);
            //Team4_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);
        }

        private void MessagesButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Team1Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void PannelClear(int activepannel)
        {
            if (activepannel != 1) MessagePannel.Visibility == System.Windows.Visibility.Visible;
            if (activepannel != 2)  Visibility == System.Windows.Visibility.Visible;
            if (activepannel != 3) MessagePannel.Visibility == System.Windows.Visibility.Visible;
            if (activepannel != 4) MessagePannel.Visibility == System.Windows.Visibility.Visible;
            if (activepannel != 5) MessagePannel.Visibility == System.Windows.Visibility.Visible;
            if (activepannel != 6) MessagePannel.Visibility == System.Windows.Visibility.Visible;
        }
    }
}
