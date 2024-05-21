using System.Windows;
using System.Windows.Controls;

namespace GettingReal_Jacobsens_Bakery.View
{
    /// <summary>
    /// Interaction logic for NewReportWindow.xaml
    /// </summary>
    public partial class NewReportWindow : Window
    {
        readonly ProcessesWindow processesWindow;

        public NewReportWindow()
        {
            InitializeComponent();

            processesWindow = new ProcessesWindow();
            InitializeTeamsAndLines();
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {   // Access current production's processes
            processesWindow.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {   // Needs to check all information boxes for invalids/missing, then send signature window whether it needs 1 or 2 signees

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {   // Close window and (maybe) abandon information, should have a confirmation window if any data has been entered!
            Close();
        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Assign from Team enums

        }

        private void cbLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Assign from Line enums

        }

        private void tbPOrder_TextChanged(object sender, TextChangedEventArgs e)
        {   // Naïve, can't be checked without accessing ERP system. Potentially check string length?

        }

        private void tbWareNum_TextChanged(object sender, TextChangedEventArgs e)
        {   // Needs to set lblRecipeNum from information parsed through database

        }

        private void tbCrumbles_TextChanged(object sender, TextChangedEventArgs e)
        {   // "Rasp", should print be suffixed with kg?

        }

        private void tbSpillage_TextChanged(object sender, TextChangedEventArgs e)
        {   // "Opfej", should print be suffixed with kg?

        }

        private void tbTotalBoxes_TextChanged(object sender, TextChangedEventArgs e)
        {   // Check negative or zero, otherwise accept

        }

        private void tbDate_TextChanged(object sender, TextChangedEventArgs e)
        {   // DateTime setup dd/mm/yy - Consider accepting 6 length int (311299 -> 31/12/99)

        }

        private void tbTimeStart_TextChanged(object sender, TextChangedEventArgs e)
        {   // DateTime or TimeSpan? Setup hh:mm - Consider accepting 4 length int (2359 -> 23:59)

        }

        private void tbTimeEnd_TextChanged(object sender, TextChangedEventArgs e)
        {   // DateTime or TimeSpan? Setup hh:mm - Consider accepting 4 length int (2359 -> 23:59)

        }

        private void chkWeightCheck_Checked(object sender, RoutedEventArgs e)
        {   // Wasn't needed often, so for MVP we run this naïve and never require it, but do note it in our final information dump

        }



        private void InitializeTeamsAndLines()
        {   // Initialize from Team and Line enums! Temporary implementation for now, do foreach in proper implementation
            cbTeam.Items.Add("Blå");
            cbTeam.Items.Add("Rød");
            cbTeam.Items.Add("Hvid");
            cbLine.Items.Add("1");
            cbLine.Items.Add("2");
            cbLine.Items.Add("3");
            cbLine.Items.Add("4");
        }
    }
}
