using GettingReal_Jacobsens_Bakery.Model;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class PRRepo
    {
        ProductionReport SelectedReport;
        List<ProductionReport> ReportRepo = new List<ProductionReport>();
        PRDatahandler PRDatahandler = new PRDatahandler();

        public void NewLine()
        {
            SelectedReport = new ProductionReport();
            ReportRepo.Add(SelectedReport);
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
