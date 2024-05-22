using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ProductionReport
    {
        public ProductionTeam ProdTeam = new ProductionTeam();
        public PRRepo repo = new PRRepo();

        // Get and set methods for the properties in the Production Team class.
        public DateTime Date
        {
            get { return ProdTeam.Date; }
            set { ProdTeam.Date = value; }
        }
        public Line Line
        {
            get { return ProdTeam.ProdLine; }
            set { ProdTeam.ProdLine = value; }
        }
        public Team Team
        {
            get { return ProdTeam.ProdTeam; }
            set { ProdTeam.ProdTeam = value; }
        }

        //Properties and methods for reporting downtime durations, and a getter for the downtimeduration prop.
        public ProductionProcess selectedProcess
        {
            get { return selectedProcess; }
            set { selectedProcess = value; }
        }
        public void NewProcess(ProductionProcess process)
        {
            ProdTeam.AddProductionProcess(process);
            //selectedProcess = process;
        }
        public TimeSpan DowntimeDuration { get { return ProdTeam.DowntimeDuration; } }

        // Get and set methods for employee signature, from the Employee class, both with a default value of "signature".
        public string SigOne
        {
            get { return ProdTeam.EmployeeOne.Signature; }
            set { ProdTeam.EmployeeOne.Signature = value; }
        }
        public string SigTwo
        {
            get { return ProdTeam.EmployeeTwo.Signature; }
            set { ProdTeam.EmployeeTwo.Signature = value; }
        }

        // Get and set methods for the properties in the ActiveRecipe class.
        public int RecipeId
        {
            get { return ProdTeam.Recipe.RecipeId; }
            set {  ProdTeam.Recipe.RecipeId = value;  }
        }
        public int Crumbles
        {
            get { return ProdTeam.Recipe.Crumbles; }
            set { ProdTeam.Recipe.Crumbles = value; }
        }
        private int _spillage;
        public int Spillage
        {
            get { return ProdTeam.Recipe.Spillage; }
            set { ProdTeam.Recipe.Spillage = value; }
        }

        // Get and set methods for the actual production, in the Production class.
        public DateTime ProdStart
        {
            get { return ProdTeam.Recipe.Production.ProdStart; }
            set { ProdTeam.Recipe.Production.ProdStart = value; }
        }
        public DateTime ProdEnd
        {
            get { return ProdTeam.Recipe.Production.ProdEnd; }
            set { ProdTeam.Recipe.Production.ProdEnd = value; }
        }
        public string ProdOrderId
        {
            get { return ProdTeam.Recipe.Production.ProdOrderId; }
            set { ProdTeam.Recipe.Production.ProdOrderId = value; }
        }
        public int BoxesProduced
        {
            get { return ProdTeam.Recipe.Production.BoxesProduced; }
            set { ProdTeam.Recipe.Production.BoxesProduced = value; }
        }

        // Get and set methods for the produced item, located in the Item class.
        public int ItemId
        {
            get { return ProdTeam.Recipe.Production.ProdItem.ItemId; }
        }
        public int Recipe
        {
            get { return ProdTeam.Recipe.Production.ProdItem.RecipeId; }
        }
        public Item ProdItem
        {
            get { return ProdTeam.Recipe.Production.ProdItem; }
        }
        public void SetItem(int itemId)
        {
            ProdTeam.Recipe.Production.ProdItem = repo.GetItem(itemId);
            RecipeId = Recipe;
        }
        public void SetItem(Item item)
        {
            ProdTeam.Recipe.Production.ProdItem = item;
            RecipeId = item.RecipeId;
        }
    }
}
