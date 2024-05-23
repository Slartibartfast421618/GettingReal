using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class Efficiency
    {

        public ItemRepo ItemRepo = new ItemRepo();

        private double _productionEfficiencyInProcentage;
        private int _calcKg;
        private int _calcBoxes;
               

        public double ProductionEffeciency
        {
            get { return _productionEfficiencyInProcentage; }
            
        }
        
        public int CalcKg
        {
            get { return _calcKg; }
            
        }
        
        public int CalcBoxes
        {
            get { return _calcBoxes; }
            
        }


        public Efficiency()
        {
            
            // Effiktivitet = (Input/Output) * 100
            //Kg = UnitWeight * ItemCount


        }

    }
}
