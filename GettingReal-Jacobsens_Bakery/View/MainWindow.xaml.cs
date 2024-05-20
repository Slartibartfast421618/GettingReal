﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewReportWindow newReportWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void livCurrentReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Reports of this team, this shift -- Currently 5 lines: Start, End, P.Order, WareNum, TotalBoxes

        }

        private void btnNewReport_Click(object sender, RoutedEventArgs e)
        {   // Change window to NewReport
            newReportWindow = new NewReportWindow();
            newReportWindow.Show();
        }

        private void btnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {   // Make sure everything is saved to file before closing window
            

            Close();
        }
    }
}
