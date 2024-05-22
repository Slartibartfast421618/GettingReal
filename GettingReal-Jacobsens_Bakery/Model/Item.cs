using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class Item
    {
        private int _itemId;

        public int ItemId
        {
            get { return _itemId; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
        }

        private int[] _line = new int[4];

        public int[] Line
        {
            get { return _line; }
        }

        private int _unitWeight;

        public int UnitWeight
        {
            get { return _unitWeight; }
        }

        private string _boxDimensions;

        public string BoxDimensions
        {
            get { return _boxDimensions; }
        }

        private int _recipeId;

        public int RecipeId
        {
            get { return _recipeId; }
        }
        public Item(int itemId, string name, int[] line, int unitWeight, string boxDimensions, int recipeId)
        {
            _itemId = itemId;
            _name = name;
            _line = line;
            _unitWeight = unitWeight;
            _boxDimensions = boxDimensions;
            _recipeId = recipeId;
        }
        public Item(int itemId, string name, int l0, int l1, int l2, int l3, int weight, string dimensions, int recipe)
        {
            _itemId= itemId;
            _name = name;
            _line[0] = l0;
            _line[1] = l1;
            _line[2] = l2;
            _line[3] = l3;
            _unitWeight = weight;
            _boxDimensions = dimensions;
            _recipeId = recipe;
        }
        public Item() 
        {
        }

        // Set method for the UnitTest
        public void SetItem(int itemId, int recipe)
        {
            _itemId = itemId;
            _recipeId = recipe;
        }

        // Set method for when we get a ItemRepo, for setting the item from the ItemId
        public void SetItem(int itemId, string name, int l1, int l2, int l3, int l4, int weight, string dimensions, int recipe) 
        {
            _itemId = itemId;
            _name = name;
            _line[0] = l1;
            _line[1] = l2;
            _line[2] = l3;
            _line[3] = l4;
            _unitWeight = weight;
            _boxDimensions = dimensions;
            _recipeId = recipe;
        }
        public string GetItem()
        {
            return $"{ItemId},{Name},{Line[0]}:{Line[1]}:{Line[2]}:{Line[3]},{UnitWeight},{BoxDimensions},{RecipeId}";
        }
    }
}
