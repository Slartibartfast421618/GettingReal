using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
                    OnPropertyChanged(nameof(ProcStart));
                }
            }
        }
        public string ProcStartFormatted
        {
            get { return _procStart.ToString("HH:mm", CultureInfo.InvariantCulture); }
            set
            {   // Used in multiple places, should be extracted to a calculator/validator class
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length >= 1 && value.Length <= 4 && (!value.Contains(":") || !value.Contains(".")))
                    {
                        switch (value.Length)
                        {
                            case 1:
                                value = $"0{value}00";
                                break;
                            case 2:
                                value = $"{value}00";
                                break;
                            case 3:
                                value = $"0{value}";
                                break;
                            default:
                                break;
                        }
                        string hours = value.Substring(0, 2), minutes = value.Substring(2, 2);
                        DateTime.TryParse(hours + ":" + minutes, out _procStart);
                    }
                    else
                        DateTime.TryParse(value, out _procStart);
                }
                else 
                    _procStart = DateTime.MinValue;
                OnPropertyChanged(nameof(ProcStartFormatted));
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
                    OnPropertyChanged(nameof(ProcEnd));
                }
            }
        }
        public string ProcEndFormatted
        {
            get { return _procEnd.ToString("HH:mm", CultureInfo.InvariantCulture); }
            set
            {   // Used in multiple places, should be extracted to a calculator/validator class
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length >= 1 && value.Length <= 4 && (!value.Contains(":") || !value.Contains(".")))
                    {
                        switch (value.Length)
                        {
                            case 1:
                                value = $"0{value}00";
                                break;
                            case 2:
                                value = $"{value}00";
                                break;
                            case 3:
                                value = $"0{value}";
                                break;
                            default:
                                break;
                        }
                        string hours = value.Substring(0, 2), minutes = value.Substring(2, 2);
                        DateTime.TryParse(hours + ":" + minutes, out _procEnd);
                    }
                    else
                        DateTime.TryParse(value, out _procEnd);
                }
                else
                    _procEnd = DateTime.MinValue;
                OnPropertyChanged(nameof(ProcEndFormatted));
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
                    OnPropertyChanged(nameof(Reason));
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
