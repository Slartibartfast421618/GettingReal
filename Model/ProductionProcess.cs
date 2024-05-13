using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealJacobsensBakery.Model
{
    public class ProductionProcess
    {
        private DateTime _prodStart;
        private DateTime _prodEnd;
        private string _reason;


        public DateTime ProdStart
        {
            get { return _prodStart; }
            set { _prodStart = value; }
        }

        public DateTime ProdEnd
        {
            get { return _prodEnd; }
            set { _prodEnd = value; }
        }

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }


        public override string ToString()
        {
            return $"ProductionStart: {_prodStart}, ProductionEnd: {_prodEnd}, Reason: {_reason}";
        }

        // DownTime er en TimeSpan
        public TimeSpan DowntimeDuration()
        {
            return ProdEnd - ProdStart;
        }
    }
}
