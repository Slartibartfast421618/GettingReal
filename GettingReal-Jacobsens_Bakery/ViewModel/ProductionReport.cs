using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    internal class ProductionReport
    {
        public ProductionTeam ProdTeam = new ProductionTeam();
        public Line prodLine = new Line();
        public Team team = new Team();

        public DateTime Date
        {
            get { return ProdTeam.Date; }
            set { ProdTeam.Date = value; }
        }
        public Line Line 
        { 
            get { return ProdTeam.ProdLine; } 
            set { ProdTeam.ProdLine = value;}
        } 
        public Team Team
        {
            get { return ProdTeam.ProdTeam; }
            set { ProdTeam.ProdTeam = value;}
        }
        public ProductionProcess selectedProcess
        {
            get { return selectedProcess; }
            set { selectedProcess = value; }
        }
        public TimeSpan DowntimeDuration { get { return ProdTeam.DowntimeDuration; } }
        public string SelectedSignature
        {
            get { return ProdTeam.Employee.Signature; }
            set { ProdTeam.Employee.Signature = value; }
        }
        public int RecipeId
        {
            get { return ProdTeam.Recipe.RecipeId; }
            set { ProdTeam.Recipe.RecipeId = value; }
        }
        public int Crumbles
        {
            get { return ProdTeam.Recipe.Crumbles; }
            set { ProdTeam.Recipe.RecipeId = value; }
        }
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
        public int ItemId 
        { 
            get { return ProdTeam.Recipe.Production.Item.ItemId; }
            set { ProdTeam.Recipe.Production.Item.ItemId = value; }
        }
        public int Recipe 
        {
            get { return ProdTeam.Recipe.Production.Item.Recipe; }
            set { ProdTeam.Recipe.Production.Item.Recipe = value; }
        }
    }
}
