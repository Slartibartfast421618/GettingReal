using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.Model
{
    public class ActiveRecipe
    {
		public Production Production = new Production();
		private int _recipeId;
		private int _crumbles;
		private int _spillage;

		public int RecipeId
		{
			get { return _recipeId; }
			set { _recipeId = value; }
		}

		public int Crumbles
		{
			get { return _crumbles; }
			set { _crumbles = value; }
		}

		public int Spillage
		{
			get { return _spillage; }
			set { _spillage = value; }
		}

	}
}
