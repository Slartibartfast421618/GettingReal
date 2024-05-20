using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class Production : INotifyPropertyChanged
    {
        public Item ProdItem = new Item();
        private DateTime _prodStart;
        private DateTime _prodEnd;
        private string _prodOrderId;
        private int _boxesProduced;

        public DateTime ProdStart
        {
            get { return _prodStart; }
            set { _prodStart = value; }
        }
        public string ProdStartFormatted
        {
            get { return _prodStart.ToString("HH:mm", CultureInfo.InvariantCulture); }
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
                        DateTime.TryParse(hours + ":" + minutes, out _prodStart);
                    }
                    else
                        DateTime.TryParse(value, out _prodStart);
                }
                else
                    _prodStart = DateTime.MinValue;
                OnPropertyChanged(nameof(ProdStartFormatted));
            }
        }

        public DateTime ProdEnd
        {
            get { return _prodEnd; }
            set { _prodEnd = value; }
        }
        public string ProdEndFormatted
        {
            get { return _prodEnd.ToString("HH:mm", CultureInfo.InvariantCulture); }
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
                        DateTime.TryParse(hours + ":" + minutes, out _prodEnd);
                    }
                    else
                        DateTime.TryParse(value, out _prodEnd);
                }
                else
                    _prodEnd = DateTime.MinValue;
                OnPropertyChanged(nameof(ProdEndFormatted));
            }
        }

        public string ProdOrderId
        {
            get { return _prodOrderId; }
            set { _prodOrderId = value; }
        }

        public int BoxesProduced
        {
            get { return _boxesProduced; }
            set { _boxesProduced = value; }
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
