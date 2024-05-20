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
using GettingReal_Jacobsens_Bakery.Model;
using GettingReal_Jacobsens_Bakery.ViewModel;

namespace GettingReal_Jacobsens_Bakery.View
{
    /// <summary>
    /// Interaction logic for ProcessesWindow.xaml
    /// </summary>
    public partial class ProcessesWindow : Window
    {
        ProductionReport pr = new ProductionReport();
        ProductionProcess pp;

        public ProcessesWindow()
        {
            InitializeComponent();

            DataContext = pr;
            InitializeCommonProcesses();
        }

        private void livCurrentProcesses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Currently 3 lines - Start, End, Comment

        }

        private void btnAddProcess_Click(object sender, RoutedEventArgs e)
        {   // Add a blank process, and set it as the active selected item
            //pr.NewProcess(pp);
            pr.AddDefaultProcess();
        }

        private void btnDeleteProcess_Click(object sender, RoutedEventArgs e)
        {   // Remove selected process
            pr.DeleteProcess(livCurrentProcesses.SelectedIndex);
        }

        private void btnNavigateUp_Click(object sender, RoutedEventArgs e)
        {   // Navigate up in a physical sense, actually lowers the index of selected item

        }

        private void btnNavigateDown_Click(object sender, RoutedEventArgs e)
        {   // Navigate down in a physical sense, actually raises the index of selected item

        }

        private void tbProcessStart_TextChanged(object sender, TextChangedEventArgs e)
        {   // DateTime or TimeSpan? Setup hh:mm - Consider accepting 4 length int (2359 -> 23:59)

        }

        private void tbProcessEnd_TextChanged(object sender, TextChangedEventArgs e)
        {   // DateTime or TimeSpan? Setup hh:mm - Consider accepting 4 length int (2359 -> 23:59)

        }

        private void tbReason_TextChanged(object sender, TextChangedEventArgs e)
        {   // Gets written over by cbReason, but allows custom messages
            cbReason.SelectedItem = null;
        }

        private void cbReason_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   // Dropdown hidden behind tbReason, used to select between common processes

        }

        private void btnSaveAndBack_Click(object sender, RoutedEventArgs e)
        {   // Make sure everything isvalidated and saved to file before closing window


            Close();
        }


        private void InitializeCommonProcesses()
        {   // These could be from an enum class or imported from a document, but we're simply setting them here for now
            cbReason.Items.Add("Omstilling");
            cbReason.Items.Add("Reparation prægemaskine");
            cbReason.Items.Add("Sprædebånd gået i stå");
            cbReason.Items.Add("Dåsepakker problematik");
            cbReason.Items.Add("Renset tyller");
        }

    }
}