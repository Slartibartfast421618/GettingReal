using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class Employee
    {
        private string _signature = "Signatur";

        public string Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

    }
}
