using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    
    public class ProductionTeam : INotifyPropertyChanged
    {

        private DateTime _date;
        private Line _prodLine;
        private Team _prodTeam;
        private TimeSpan _downtimeDuration;
        public ObservableCollection<ProductionProcess> PPRepo = new ObservableCollection<ProductionProcess>();
        public Employee EmployeeOne = new Employee();
        public Employee EmployeeTwo = new Employee();
        public ActiveRecipe Recipe = new ActiveRecipe();



        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Line ProdLine
        {
            get { return _prodLine; }
            set { _prodLine = value; }
        }

        public Team ProdTeam
        {
            get { return _prodTeam; }
            set { _prodTeam = value; }
        }

        public TimeSpan DowntimeDuration
        {
            get { return _downtimeDuration; }
        }

        // methods for administering the Production Process Repo
        public void AddProductionProcess(ProductionProcess productionProcess)
        {
            PPRepo.Add(productionProcess);
        }
        public void AddProductionProcess()
        {
            ProductionProcess pr = new ProductionProcess("00:00", "00:00", "abc");
            PPRepo.Add(pr);
            OnPropertyChanged(nameof(PPRepo));
        }
        public void CalculateTotalProcessDowntime()
        {
            _downtimeDuration = TimeSpan.Parse("00:00:00");
            foreach (ProductionProcess process in PPRepo)
            {
                _downtimeDuration = _downtimeDuration + process.DowntimeDuration();
            }
        }

        public ProductionProcess GetProductionProcess()
        {
            foreach (ProductionProcess productionProcessPeriod in PPRepo)
            {
                return productionProcessPeriod;
            }
            return null;
        }



        // INotifyPropertyChanged handler
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
