using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GettingReal_Jacobsens_Bakery.ViewModel;


namespace GettingReal_Jacobsens_Bakery.View
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        ProductionReport activeProductionReport;
        PRRepo prr;

        ProcessesWindow processesWindow;

        public ReportWindow(ProductionReport selectedProductionReport, PRRepo pRRepo)
        {
            InitializeComponent();
            InitializeTeamsAndLines();

            this.activeProductionReport = selectedProductionReport;
            this.prr = pRRepo;
            DataContext = this.activeProductionReport;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {   // Access current production's processes
            processesWindow = new ProcessesWindow(activeProductionReport);
            processesWindow.Show();
            //activeProductionReport.ProdTeam.CalculateTotalProcessDowntime();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {   // Needs to check all information boxes for invalids/missing,
            // then send signature window whether it needs 1 or 2 signees

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {   // Close window and (maybe) abandon information,
            // should have a confirmation window if any data has been entered!
            Close();
            // CHECK NOTES ABOVE!!
        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Assign from Team enums

        }

        private void cbLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Assign from Line enums

        }


        private void chkWeightCheck_Checked(object sender, RoutedEventArgs e)
        {   // Wasn't needed often, so for MVP we run this naïve and never require it,
            // but do note it in our final information dump

        }



        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {   // For quickly being able to overwrite current content
            TextBox textBox = sender as TextBox;
            if (textBox != null)
                textBox.SelectAll();
        }   // Doesn't work with mouse selecting



        private void InitializeTeamsAndLines()
        {   // Initialize from Team and Line enums 
            ProductionReport baseReport = new ProductionReport();
            foreach (string team in baseReport.ProdTeam.AvailableProdTeams())
                cbTeam.Items.Add(team);

            foreach (string line in baseReport.ProdTeam.AvailableProdLines())
                cbLine.Items.Add(line);
        }

        private void tbWareNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            prr.MatchItem(activeProductionReport);
        }
    }
}
