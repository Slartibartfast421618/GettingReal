﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class PRRepo
    {
        ProductionReport SelectedReport;
        List<ProductionReport> ReportRepo = new List<ProductionReport>();

        public void NewLine()
        {
            SelectedReport = new ProductionReport();
            ReportRepo.Add(SelectedReport);
        }
    }
}
