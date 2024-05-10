using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class ProductionTeam
    {

        private DateTime _date;
        private Line _prodLine;
        private Team _prodTeam;
        private DateTime _duration;
        public List<ProductionProcess> PPRepo;


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



        public DateTime Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public void AddProductionProcess(ProductionProcess productionProcess)
        {
           PPRepo.Add(productionProcess); 
        }

        public ProductionProcess GetProductionProcess(ProductionProcess productionProcess)
        {
            foreach (ProductionProcess productionProcessPeriod in PPRepo)
            {
                if (productionProcessPeriod == productionProcess) { }
            }
            return null;
        }

        // Skal dette være ToString? 
        public void Team()
        {

        }

    }
}
