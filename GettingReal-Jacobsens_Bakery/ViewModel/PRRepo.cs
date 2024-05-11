using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    internal class PRRepo
    {
        ProductionReport SelectedReport;
        List<ProductionReport> CurrentReport = new List<ProductionReport>();
        List<ProductionReport> ReportRepo = new List<ProductionReport>();

        public void NewLine()
        {
            SelectedReport = new ProductionReport();
            CurrentReport.Add(SelectedReport);
        }

    }
}
