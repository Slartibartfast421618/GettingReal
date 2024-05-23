using GettingReal_Jacobsens_Bakery.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Shapes;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ProductionReport : INotifyPropertyChanged
    {
        public ItemRepo itemRepo = new ItemRepo();
        private ProductionTeam _prodTeam = new ProductionTeam();

        public ProductionReport() 
        {
            //ProdTeam = new ProductionTeam();
        }

        // Get and set methods for the properties in the Production Team class.
        public ProductionTeam ProdTeam
        {
            get { return _prodTeam; }
            set
            {
                if (ProdTeam != null)
                {
                    _prodTeam = value;
                    OnPropertyChanged(nameof(ProdTeam));
                }
            }
        }
        public DateTime Date
        {
            get { return ProdTeam.Date; }
            set
            {
                if (value == null)
                    DateTime.TryParse("01/01/0001", out value);
                ProdTeam.Date = value;
            }
        }




        public string DateFormatted
        {
            get { return ProdTeam.DateFormatted; }
            set 
            { 
                ProdTeam.DateFormatted = value;
                OnPropertyChanged(nameof(DateFormatted));
            }
        }

        public EnumLine Line
        { 
        get { return ProdTeam.ProdLine; }
            set 
            { 
                ProdTeam.ProdLine = value;
                OnPropertyChanged(nameof(Line));
            }
        }
        public EnumTeam Team
        {
            get { return ProdTeam.ProdTeam; }
            set 
            {
                ProdTeam.ProdTeam = value;
                OnPropertyChanged(nameof(Team));
            }
        }

        //Properties and methods for reporting downtime durations, and a getter for the downtimeduration prop.
        private ProductionProcess _selectedProcess;
        public ProductionProcess SelectedProcess
        {
            get { return _selectedProcess; }
            set 
            { 
                _selectedProcess = value; 
                OnPropertyChanged(nameof(SelectedProcess));
            }
        }
        public void NewProcess(ProductionProcess process)
        {
            ProdTeam.AddProductionProcess(process);

            SelectedProcess = process;
        }
        public TimeSpan DowntimeDuration 
        { 
            get
            {
                return ProdTeam.DowntimeDuration;
            }
        }
        public void DeleteProcess(int id)
        {
            if (id < ProdTeam.PPRepo.Count && id >= 0)
            {
                ProdTeam.PPRepo.RemoveAt(id);
            }
        }
        public void AddDefaultProcess()
        {
            ProdTeam.AddProductionProcess();

        }

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
        public string ProdStartFormatted
        {
            get { return ProdTeam.Recipe.Production.ProdStartFormatted; }
            set 
            { 
                ProdTeam.Recipe.Production.ProdStartFormatted = value;
                OnPropertyChanged(nameof(ProdStartFormatted));
            }
        }
        public DateTime ProdEnd
        {
            get { return ProdTeam.Recipe.Production.ProdEnd; }
            set { ProdTeam.Recipe.Production.ProdEnd = value; }
        }
        public string ProdEndFormatted
        {
            get { return ProdTeam.Recipe.Production.ProdEndFormatted; }
            set 
            { 
                ProdTeam.Recipe.Production.ProdEndFormatted = value;
                OnPropertyChanged(nameof(ProdEndFormatted));
            }
        }
        public string ProdOrderId
        {
            get { return ProdTeam.Recipe.Production.ProdOrderId; }
            set 
            { 
                ProdTeam.Recipe.Production.ProdOrderId = value;
                OnPropertyChanged(nameof(ProdOrderId));
            }
        }
        public int BoxesProduced
        {
            get { return ProdTeam.Recipe.Production.BoxesProduced; }
            set 
            { 
                ProdTeam.Recipe.Production.BoxesProduced = value;
                OnPropertyChanged(nameof(BoxesProduced));
            }
        }

        // Get and set methods for the produced item, located in the Item class.
        public int ItemId
        {
            get { return ProdTeam.Recipe.Production.ProdItem.ItemId; }
            set 
            { 
                ProdTeam.Recipe.Production.ProdItem.ItemId = value;
                OnPropertyChanged(nameof(ItemId));
            }
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
            Item findItem = itemRepo.FindItem(itemId);

            if (findItem != null)
                ProdTeam.Recipe.Production.ProdItem = findItem;
            RecipeId = Recipe;
        }
        public void SetItem(Item item)
        {
            ProdTeam.Recipe.Production.ProdItem = item;
            RecipeId = item.RecipeId;
        }

        public ProductionReport(DateTime date, EnumTeam prodTeam, EnumLine line, string employeeOne, string employeeTwo, int recipeId, int crumbles, DateTime prodStart, DateTime prodEnd, string prodOrderId, int boxesProduced, int itemId)
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
            ItemId = itemId;
            SetItem(itemId);
        }

        public string ToString()
        {
            return ($"{Date};{Team};{Line};{SigOne};{SigTwo};{RecipeId};{Crumbles};{ProdStart};{ProdEnd};{ProdOrderId};{BoxesProduced};{ItemId}");
        }



        // INotifyPropertyChanged handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
