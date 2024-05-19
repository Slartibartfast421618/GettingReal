using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ItemRepo
    {
        public ObservableCollection<Item> Items = new ObservableCollection<Item>();
        public ItemDatahandler datahandler = new ItemDatahandler();
        public Item SelectedItem { get; set; }
        public Item FindItem(int id)
        {
            Item SelectedItem = null;
            foreach (var item in Items)
            {
                if (item.ItemId == id)
                {
                    SelectedItem = item;
                    break;
                }
            }
            return SelectedItem;
        }
        public ObservableCollection<Item> GetItems()
        {
            return Items;
        }
        public void AddItem(int id, string name, int l0, int l1, int l2, int l3, int weight, string dimension, int recipe)
        {
            Item item = new Item(id, name, l0, l1, l2, l3, weight, dimension, recipe );
            Items.Add(item);
        }
        public void NewItem()
        {
            Items.Add(new Item());
        }
        public void DeleteItem(Item item)
        {
            Items.Remove(item);
        }
        public int Count()
        {
            int count = 0;
            foreach (var item in Items)
                count++;
            return count;
        }
        public ItemRepo() { }
        public void SaveRepo()
        {
            datahandler.SaveItems(Items);
        }
        public void SaveRepo(string fileName)
        {
            datahandler.SaveItems(Items, fileName);
        }
        public void LoadRepo()
        {
            Items = datahandler.LoadItems();
        }
        public void LoadRepo(string fileName)
        {
            Items = datahandler.LoadItems(fileName);
        }
    }
}
