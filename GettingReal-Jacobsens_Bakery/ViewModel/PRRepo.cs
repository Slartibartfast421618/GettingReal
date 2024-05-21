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
