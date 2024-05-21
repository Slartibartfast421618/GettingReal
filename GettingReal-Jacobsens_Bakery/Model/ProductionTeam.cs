namespace GettingReal_Jacobsens_Bakery.Model
{

    public class ProductionTeam
    {

        private DateTime _date;
        private Line _prodLine;
        private Team _prodTeam;
        private TimeSpan _downtimeDuration;
        public List<ProductionProcess> PPRepo = new List<ProductionProcess>();
        public Employee EmployeeOne = new Employee();
        public Employee EmployeeTwo = new Employee();
        public ActiveRecipe Recipe = new ActiveRecipe();



        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Line ProdLine
        {
            get { return _prodLine; }
            set { _prodLine = value; }
        }

        public Team ProdTeam
        {
            get { return _prodTeam; }
            set { _prodTeam = value; }
        }

        public TimeSpan DowntimeDuration
        {
            get { return _downtimeDuration; }
        }

        // methods for administering the Production Process Repo
        public void AddProductionProcess(ProductionProcess productionProcess)
        {
            PPRepo.Add(productionProcess);
            _downtimeDuration = TimeSpan.Parse("00:00:00");
            foreach (var process in PPRepo)
            {
                _downtimeDuration = _downtimeDuration + process.DowntimeDuration();
            }
        }

        public ProductionProcess GetProductionProcess()
        {
            foreach (ProductionProcess productionProcessPeriod in PPRepo)
            {
                return productionProcessPeriod;
            }
            return null;
        }
    }
}
