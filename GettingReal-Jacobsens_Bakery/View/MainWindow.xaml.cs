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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PRRepo prr;


        NewReportWindow newReportWindow;

        public MainWindow()
        {
            InitializeComponent();

            prr = new PRRepo();
            DataContext = prr;
        }

        private void livCurrentReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Reports of this team, this shift -- Currently 5 lines: Start, End, P.Order, WareNum, TotalBoxes

        }

        private void btnNewReport_Click(object sender, RoutedEventArgs e)
        {   // Change window to NewReport
            prr.NewLine();
            newReportWindow = new NewReportWindow(prr.SelectedReport);
            newReportWindow.Show();

        }

        private void btnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {   // Make sure everything is saved to file before closing window


            Close();
        }

        private void btnCheckCurrentReport_Click(object sender, RoutedEventArgs e)
        {
            //if (prr.SelectedReport != null)
            //    btnCheckCurrentReportDate.Content = prr.SelectedReport.DateFormatted;
            if (livCurrentReports.SelectedIndex > -1)
            {
                newReportWindow = new NewReportWindow(prr.SelectedReport);
                newReportWindow.Show();
            }

        }

        private void btnCheckCurrentReportDowntime_Click(object sender, RoutedEventArgs e)
        {
            if (livCurrentReports.SelectedIndex > -1)
            {
                btnCheckCurrentReportDowntime.Content = prr.SelectedReport.DowntimeDuration;
            }
        }

        private void btnCheckReportOneDowntime_Click(object sender, RoutedEventArgs e)
        {
            btnCheckReportOneDowntime.Content = prr.ReportRepo[0].DowntimeDuration;
        }
    }
}
