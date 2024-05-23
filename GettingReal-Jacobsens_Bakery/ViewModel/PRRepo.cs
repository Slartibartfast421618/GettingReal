using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class PRRepo
    {

        public ProductionReport SelectedReport { get; set; }
        public List<ProductionReport> ReportRepo = new List<ProductionReport>();
        public Efficiency calculator = new Efficiency();        
        public PRDatahandler PRDatahandler = new PRDatahandler();


        public void NewLine()
        {
            SelectedReport = new ProductionReport();
            ReportRepo.Add(SelectedReport);
        }

        public Item GetItem(int itemId)
        {
            Item item = calculator.ItemRepo.FindItem(itemId);
            if (item != null)
                return item;
            else return null;

        }
        public PRRepo()
        {            
            ReportRepo = PRDatahandler.LoadProductionReports();
        }

        public void SaveReports()
        {
            PRDatahandler.SaveProductionReports(ReportRepo);

        }
    }
}

