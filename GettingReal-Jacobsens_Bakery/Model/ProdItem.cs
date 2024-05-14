using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class ProdItem
    {
        private int _itemId;

        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }
        private int _recipe;

        public int Recipe
        {
            get { return _recipe; }
            set { _recipe = value; }
        }

    }
}
