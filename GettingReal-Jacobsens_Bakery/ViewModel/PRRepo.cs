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
        private ProductionReport _selectedReport;
        ObservableCollection<ProductionReport> ReportRepo { get; set; } = new ObservableCollection<ProductionReport>();

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
            SelectedReport = new ProductionReport();
            ReportRepo.Add(SelectedReport);
            OnPropertyChanged(nameof(ReportRepo));
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
