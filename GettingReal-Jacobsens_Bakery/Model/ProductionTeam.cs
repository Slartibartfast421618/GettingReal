using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public enum Team
    {
        red,
        white,
        blue
    }
    public enum Line
    {
        one,
        two,
        three,
        four
    }
    public class ProductionTeam
    {

        private DateTime _date;
        private Line _prodLine;
        private Team _prodTeam;
        private TimeSpan _downtimeDuration;
        public List<ProductionProcess> PPRepo;
        public Employee Employee = new Employee();
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

        public void AddProductionProcess(ProductionProcess productionProcess)
        {
           PPRepo.Add(productionProcess);
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

        // Skal dette være ToString? 
      
        

    }
}
