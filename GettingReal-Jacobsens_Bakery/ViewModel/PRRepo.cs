﻿using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class PRRepo : INotifyPropertyChanged
    {
        public Efficiency calculator = new Efficiency();        
        public PRDatahandler PRDatahandler = new PRDatahandler();
        private ProductionReport _selectedReport;
        public ObservableCollection<ProductionReport> ReportRepo { get; set; } = new ObservableCollection<ProductionReport>();

        public ProductionReport SelectedReport
        {
            get { return _selectedReport; }
            set 
            { 
                _selectedReport = value; 
                OnPropertyChanged(nameof(SelectedReport));
            }
        }





        public void NewLine()
        {
            ProductionReport newReport = new ProductionReport();
            ReportRepo.Add(newReport);
            SelectedReport = newReport;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Item GetItem(int itemId)
        {
            Item item = calculator.ItemRepo.FindItem(itemId);
            if (item != null)
                return item;
            else return null;

        }
        public PRRepo()
        {            
            ReportRepo = PRDatahandler.LoadProductionReports();
        }

        public void SaveReports()
        {
            PRDatahandler.SaveProductionReports(ReportRepo);

        }
    }
}

