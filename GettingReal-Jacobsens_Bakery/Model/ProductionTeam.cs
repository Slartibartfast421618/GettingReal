﻿using System;
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
        private EnumLine _prodLine;
        private EnumTeam _prodTeam;
        private TimeSpan _downtimeDuration;
        public ObservableCollection<ProductionProcess> PPRepo { get; set; } = new ObservableCollection<ProductionProcess>();
        public Employee EmployeeOne = new Employee();
        public Employee EmployeeTwo = new Employee();
        public ActiveRecipe Recipe = new ActiveRecipe();

        public ProductionTeam()
        {
            PPRepo.CollectionChanged += PPRepo_CollectionChanged;
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string DateFormatted
        {
            get { return _date.ToString("dd/MM/yy"); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length >= 2 && value.Length <= 6 && (!value.Contains("/") || !value.Contains("-")))
                    {
                        switch (value.Length)
                        {
                            case 2:
                                value = $"0{value.Substring(0, 1)}0{value.Substring(1, 1)}{DateTime.Now.ToString("yy")}";
                                break;
                            case 3:
                                value = $"0{value.Substring(0, 1)}{value.Substring(1, 2)}{DateTime.Now.ToString("yy")}";
                                break;
                            case 4:
                                if (value.Substring(2, 2) != DateTime.Now.Year.ToString("yy"))
                                    value = $"{value.Substring(0, 2)}{value.Substring(2, 2)}{DateTime.Now.ToString("yy")}";
                                else
                                    value = $"0{value.Substring(0, 1)}0{value.Substring(1, 1)}{value.Substring(2, 2)}";
                                break;
                            case 5:
                                value = $"0{value.Substring(0, 1)}{value.Substring(1, 2)}{value.Substring(3, 2)}";
                                break;
                        }
                        string days = value.Substring(0, 2),
                               months = value.Substring(2, 2),
                               years = value.Substring(4, 2);
                        DateTime.TryParse($"{days}/{months}/20{years}", out _date);
                    }
                    else
                        DateTime.TryParse(value, out _date);
                }
                else
                    _date = DateTime.Now;
                OnPropertyChanged(nameof(DateFormatted));
            }
        }

        public List<string> AvailableProdLines()
        {
            List<string> aProdLines = new List<string>();
            foreach (EnumLine line in Enum.GetValues(typeof(EnumLine)))
                aProdLines.Add(line.ToString());
            return aProdLines;
        }
        public List<string> AvailableProdTeams()
        {
            List<string> aProdTeams = new List<string>();
            foreach (EnumTeam team in Enum.GetValues(typeof(EnumTeam)))
                aProdTeams.Add(team.ToString());
            return aProdTeams;
        }

        public EnumLine ProdLine
        {
            get { return _prodLine; }
            set { _prodLine = value; }
        }

        public EnumTeam ProdTeam
        {
            get { return _prodTeam; }
            set { _prodTeam = value; }
        }

        public TimeSpan DowntimeDuration
        {
            get 
            {
                return CalculateTotalProcessDowntime();
            }
        }

        // methods for administering the Production Process Repo
        public void AddProductionProcess(ProductionProcess productionProcess)
        {
            PPRepo.Add(productionProcess);
        }
        public void AddProductionProcess()
        {
            ProductionProcess pr = new ProductionProcess("00:00", "00:00", "");
            PPRepo.Add(pr);
            OnPropertyChanged(nameof(PPRepo));
        }
        private TimeSpan CalculateTotalProcessDowntime()
        {
            TimeSpan totalDowntime = TimeSpan.Zero;
            foreach (var process in PPRepo)
            {
                totalDowntime += process.ProcDowntime;
            }
            return totalDowntime;
        }

        public ProductionProcess GetProductionProcess()
        {
            foreach (ProductionProcess productionProcessPeriod in PPRepo)
            {
                return productionProcessPeriod;
            }
            return null;
        }



        // PPRepo CollectionChanged handler
        private void PPRepo_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProductionProcess pp in e.NewItems)
                {
                    pp.PropertyChanged += ProductionProcess_PropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (ProductionProcess pp in e.OldItems)
                {
                    pp.PropertyChanged -= ProductionProcess_PropertyChanged;
                }
            }

            OnPropertyChanged(nameof(DowntimeDuration));
        }

        private void ProductionProcess_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProductionProcess.ProcDowntime))
            {
                OnPropertyChanged(nameof(DowntimeDuration));
            }
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
