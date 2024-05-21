using System;
using System.CodeDom;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using GettingReal_Jacobsens_Bakery.ViewModel;

namespace GettingReal_Jacobsens_Bakery.View
{
    /// <summary>
    /// Interaction logic for NewReportWindow.xaml
    /// </summary>
    public partial class NewReportWindow : Window
    {
        ProductionReport activeProductionReport;

        ProcessesWindow processesWindow;

        public NewReportWindow(ProductionReport selectedProductionReport)
        {
            InitializeComponent();
            InitializeTeamsAndLines();

            this.activeProductionReport = selectedProductionReport;
            DataContext = this.activeProductionReport;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {   // Access current production's processes
            if (processesWindow == null || processesWindow.IsVisible == false)
            {
                processesWindow = new ProcessesWindow(activeProductionReport);
                processesWindow.Show();
            }
            else
                processesWindow.Focus();
            // MISSING PROCESS INFORMATION!! how do?
            // Currently forgets processes,
            // but surely we can grab the list off of somewhere
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
        {   // Initialize from Team and Line enums! Temporary implementation for now,
            // do foreach in proper implementation
            cbTeam.Items.Add("Blå");
            cbTeam.Items.Add("Rød");
            cbTeam.Items.Add("Hvid");

            cbLine.Items.Add("1");
            cbLine.Items.Add("2");
            cbLine.Items.Add("3");
            cbLine.Items.Add("4");
            // REMINDER!! This layer is not allowed to look directly at the enums class
        }

        private void btnCheckProcessCount_Click(object sender, RoutedEventArgs e)
        {
            btnCheckProcessCount.Content = activeProductionReport.ProdTeam.PPRepo.Count();
        }
    }
}
