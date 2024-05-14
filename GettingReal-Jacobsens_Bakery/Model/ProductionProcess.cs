using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class ProductionProcess
    {
        private DateTime _procStart;
        private DateTime _procEnd;
        private string _reason;


        public DateTime ProcStart
        {
            get { return _procStart; }
            set { _procStart = value; }
        }

        public DateTime ProcEnd
        {
            get { return _procEnd; }
            set { _procEnd = value; }
        }

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }


        public override string ToString()
        {
            return $"ProcessStart: {_procStart}, ProcessEnd: {_procEnd}, Reason: {_reason}";
        }

        // DownTime er en TimeSpan
        public TimeSpan DowntimeDuration()
        {
            return ProcEnd - ProcStart;
        }
    }
}
