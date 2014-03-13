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
            //worker_init();
            InitializeComponent();   
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (globals.user.TIDs[0] != 0)
            { Team1Button.Visibility = System.Windows.Visibility.Visible; Team1Button.Content = globals.user.teamnames[0]; }

            if (globals.user.TIDs[1] != 0)
            { Team2Button.Visibility = System.Windows.Visibility.Visible; Team2Button.Content = globals.user.teamnames[1]; }
            
            if (globals.user.TIDs[2] != 0)
            { Team3Button.Visibility = System.Windows.Visibility.Visible; Team3Button.Content = globals.user.teamnames[2]; }
            
            if (globals.user.TIDs[3] != 0)
            { Team4Button.Visibility = System.Windows.Visibility.Visible; Team4Button.Content = globals.user.teamnames[3]; }

            T1ListView.ItemsSource = globals.teamtable1.DefaultView;
        }

        //private void worker_init()
        //{
            
        //    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        //    worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        //    worker.RunWorkerAsync();
        //}

        //private void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
           

        //}

        //private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{



        //    //for (int i = 0; i < globals.teamtable[0].Rows.Count; i++)
        //    //{
        //    //    DataRow dr = teamtable[0].Rows[i];
        //    //    ListViewItem listitem = new ListViewItem(dr["pk_Location_ID"].ToString());
        //    //    listitem.SubItems.Add(dr["var_Location_Name"].ToString());
        //    //    listitem.SubItems.Add(dr["fk_int_District_ID"].ToString());
        //    //    listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
        //    //    listView1.Items.Add(listitem);
        //    //} 

        //    //foreach (DataRow row in globals.teamtable[0].Rows)
        //    //{
        //    //    ListViewItem item = new ListViewItem(row[0].ToString());
        //    //    for (int i = 1; i < globals.teamtable[0].Columns.Count; i++)
        //    //    {
        //    //        item.SubItems.Add(row[i].ToString());
        //    //    }
        //    //    T1ListView.Items.Add(item);
        //    //}

        //    //Team2_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);
        //    //Team3_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);
        //    //Team4_GroupBox.Header = globals.SqlExec.tidtotname(globals.user.TID1);

        //    //hide cover pannels...
        //}

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
    }
}
