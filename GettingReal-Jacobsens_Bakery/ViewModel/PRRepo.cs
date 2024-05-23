using GettingReal_Jacobsens_Bakery.Model;
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
        public ObservableCollection<ProductionReport> ReportRepo { get; set; } = new ObservableCollection<ProductionReport>();

        private ProductionReport _selectedReport;
        public ProductionReport SelectedReport
        {
            get { return _selectedReport; }
            set 
            { 
                _selectedReport = value; 
                OnPropertyChanged(nameof(SelectedReport));
            }
        }
        public PRRepo()
        {
            LoadReports();
        }

        public void LoadReports()
        {
            List<ProductionReport> loadReports = PRDatahandler.LoadProductionReports();
            ReportRepo.Clear();
            foreach (ProductionReport report in loadReports)
            {
                ReportRepo.Add(report);
            }
        }

        public void NewLine()
        {
            ProductionReport newReport = new ProductionReport();
            ReportRepo.Add(newReport);
            SelectedReport = newReport;
        }

        //public Item GetItem(int itemId)
        //{
        //    Item item = calculator.ItemRepo.FindItem(itemId);
        //    if (item != null)
        //        return item;
        //    else
        //        return null;
        //}

        public void SaveReports()
        {
            List<ProductionReport> saveReports = new List<ProductionReport>();
            foreach (ProductionReport report in ReportRepo)
            {
                saveReports.Add(report);
            }
            PRDatahandler.SaveProductionReports(saveReports);
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
    }
}

