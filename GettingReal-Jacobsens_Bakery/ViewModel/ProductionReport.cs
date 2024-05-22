using GettingReal_Jacobsens_Bakery.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Shapes;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ProductionReport
    {
        public ProductionTeam ProdTeam = new ProductionTeam();

        // Get and set methods for the properties in the Production Team class.
        public DateTime Date
        {
            get { return ProdTeam.Date; }
            set { ProdTeam.Date = value; }
        }
        public EnumLine Line
        {
            get { return ProdTeam.ProdLine; }
            set { ProdTeam.ProdLine = value; }
        }
        public EnumTeam Team
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
            selectedProcess = process;
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
            set { ProdTeam.Recipe.RecipeId = value; }
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
        public void SetItem(int Item, int Recipe)
        {
            ProdTeam.Recipe.Production.ProdItem.SetItem(Item, Recipe);
        }
        public void SetItem(int itemId, string name, int l1, int l2, int l3, int l4, int weight, string dimensions, int recipe)
        {
            ProdTeam.Recipe.Production.ProdItem.SetItem(itemId, name, l1, l2, l3, l4, weight, dimensions, recipe);
        }

        public ProductionReport(DateTime date, EnumTeam prodTeam, EnumLine line, string employeeOne, string employeeTwo, int recipeId, int crumbles, DateTime prodStart, DateTime prodEnd, string prodOrderId, int boxesProduced, int itemId, int recipe)
        {
            Date = date;
            Team = prodTeam;
            Line = line;
            SigOne = employeeOne;
            SigTwo = employeeTwo;
            RecipeId = recipeId;
            Crumbles = crumbles;
            ProdStart = prodStart;
            ProdEnd = prodEnd;
            ProdOrderId = prodOrderId;
            BoxesProduced = boxesProduced;
            SetItem(itemId, recipe);
        }

        public ProductionReport()
        {
        }

        public string ToString()
        {
            return ($"{Date};{Team};{Line};{SigOne};{SigTwo};{RecipeId};{Crumbles};{ProdStart};{ProdEnd};{ProdOrderId};{BoxesProduced};{ItemId};{Recipe};");
        }
    }
}
