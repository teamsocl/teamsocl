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

            lst.Add(new ItemsInfo("Messages", "Messages go here", "Red"));
            lst.Add(new ItemsInfo("Teams", "Teams listed here", "Red"));

            MessageBox.Show(globals.SqlExec.tidtotname(globals.user.TID1));

            if (globals.user.TID1 != 0)
            { lst.Add(new ItemsInfo(globals.SqlExec.tidtotname(globals.user.TID1), "Team Data here", "Brown")); }

            if (globals.user.TID2 != 0)
            { lst.Add(new ItemsInfo(globals.SqlExec.tidtotname(globals.user.TID2), "Team Data Here", "Brown")); }
            
            if (globals.user.TID3 != 0)
            { lst.Add(new ItemsInfo(globals.SqlExec.tidtotname(globals.user.TID3), "Team Data Here", "Brown")); }
            
            if (globals.user.TID4 != 0)
            { lst.Add(new ItemsInfo(globals.SqlExec.tidtotname(globals.user.TID4), "Team Data Here", "Brown")); }
            
            tabControl.ItemsSource = lst;
            tabControl.SelectedIndex = 0;

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
    }
}
