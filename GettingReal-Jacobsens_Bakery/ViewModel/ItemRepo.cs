﻿using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ItemRepo
    {

        public ObservableCollection<Item> Items = new ObservableCollection<Item>();
        public ItemDatahandler datahandler = new ItemDatahandler();
        public Item FindItem(int id)
        {
            Item SelectedItem = null;
            foreach (var item in Items)
            {
                if (item.ItemId == id)
                {
                    SelectedItem = item;
                    return SelectedItem;
                }
            }
            SelectedItem = new Item();
            SelectedItem.SetItem(0, 0);
            return SelectedItem;
        }
        public ObservableCollection<Item> GetItems()
        {
            return Items;
        }
        public void AddItem(int id, string name, int line0, int line1, int line2, int line3, int weight, string dimension, int recipe)
        {
            Item item = new Item(id, name, line0, line1, line2, line3, weight, dimension, recipe );
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
