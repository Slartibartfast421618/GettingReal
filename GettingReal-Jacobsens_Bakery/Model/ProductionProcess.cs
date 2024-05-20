using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class ProductionProcess : INotifyPropertyChanged
    {
        private DateTime _procStart;
        private DateTime _procEnd;
        private string _reason;


        public DateTime ProcStart
        {
            get { return _procStart; }
            set
            {
                if (_procStart != value)
                {
                    _procStart = value;
                    OnPropertyChanged("ProcStart");
                }
            }
        }

        public DateTime ProcEnd
        {
            get { return _procEnd; }
            set
            {
                if (_procEnd != value)
                {
                    _procEnd = value;
                    OnPropertyChanged("ProcStart");
                }
            }
        }

        public string Reason
        {
            get { return _reason; }
            set
            {
                if (_reason != value)
                {
                    _reason = value;
                    OnPropertyChanged("ProcStart");
                }
            }
        }

        public ProductionProcess() { }
        public ProductionProcess(string processStart, string processEnd, string comment)
        {
            DateTime.TryParse(processStart, out _procStart);
            DateTime.TryParse(processEnd, out _procEnd);
            _reason = comment;
        }



        public override string ToString()
        {
            return $"ProcessStart: {_procStart}, ProcessEnd: {_procEnd}, Reason: {_reason}";
        }

        public TimeSpan DowntimeDuration()
        {
            // Making sure it works correctly for times passing midnight
            if (ProcEnd > ProcStart)
                return ProcEnd - ProcStart;
            else
                return ProcEnd.AddHours(24) - ProcStart;
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
