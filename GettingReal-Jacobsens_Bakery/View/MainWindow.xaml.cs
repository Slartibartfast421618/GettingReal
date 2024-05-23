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
        ReportWindow reportWindow;

        public MainWindow()
        {
            InitializeComponent();

            prr = new PRRepo();
            DataContext = prr;
        }

        private void livCurrentReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Reports of this team, this shift -- Currently 5 lines: Start, End, P.Order, WareNum, TotalBoxes
            reportWindow = new ReportWindow(prr.SelectedReport, prr);
            reportWindow.Show();
        }

        private void btnNewReport_Click(object sender, RoutedEventArgs e)
        {   // Create a new line. Because this causes the list to readjust selection, this automatically opens it
            prr.NewLine();
        }

        private void btnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {   // Make sure everything is saved to file before closing window
            prr.SaveReports();

            Close();
        }
    }
}
