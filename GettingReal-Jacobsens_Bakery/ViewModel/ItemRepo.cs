using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ItemRepo
    {
       List<Item> itemList = new List<Item>();

        public Item GetItems(int itemid)
        {

            foreach(Item item in itemList) 
            {
                if (item.ItemId == itemid)
                {
                    return item;
                }
                
            }
            return null;

        }



        public void AddItem(int itemid, string name, int[] line, int weight, string dimension, int recipe)
        {
            if (line.Length != 4)
            {
                throw new ArgumentException("Den skal bestå af 4 elementer");
            }
            else 
            { 
            Item item = new Item();

            item.SetItem(itemid, name, line[0], line[1], line[2], line[3], weight, dimension, recipe);

            itemList.Add(item);
            }
        }
    }
}
