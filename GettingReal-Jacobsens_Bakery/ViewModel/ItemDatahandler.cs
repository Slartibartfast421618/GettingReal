using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ItemDatahandler
    {
        public string FileName = "ItemRepo.txt";
        public string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        ItemRepo ItemRepo;
        

        public void SaveItems(ObservableCollection<Item> repo, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(path,fileName), false))
            {
                try
                {
                    foreach (Item item in repo)
                    {
                        sw.WriteLine(item.GetItem());
                    }
                }
                catch (Exception e)
                { 
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public void SaveItems(ObservableCollection<Item> repo)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, FileName), false))
            {
                try
                {
                    foreach (Item item in repo)
                    {
                        sw.WriteLine(item.GetItem());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
        public ObservableCollection<Item> LoadItems(string fileName)
        {
            if (File.Exists(fileName))
            {
                ObservableCollection<Item> items = new ObservableCollection<Item>();
                using (StreamReader sr = new StreamReader(Path.Combine(path, fileName)))
                {
                    while (sr.EndOfStream == false)
                    {
                        string[] l;
                        int id, weight, recipe;
                        int[] prodLine = new int[4];
                        string name, dimensions;
                        string[] line = sr.ReadLine().Split(",");
                        Int32.TryParse(line[0], out id);
                        name = line[1];
                        l = line[2].Split(":");
                        for (int i = 0; i < 4; i++)
                            Int32.TryParse(l[i], out prodLine[i]);
                        Int32.TryParse(line[3], out weight);
                        dimensions = line[4];
                        Int32.TryParse(line[5], out recipe);
                        items.Add(new Item(id, name, prodLine, weight, dimensions, recipe));
                    }
                }
                return items;
            }
            else
                return null;
        }
        public ObservableCollection<Item> LoadItems()
        {
            if (File.Exists(FileName))
            {
                ObservableCollection<Item> items = new ObservableCollection<Item>();
                using (StreamReader sr = new StreamReader(Path.Combine(path, FileName)))
                {
                    while (sr.EndOfStream == false)
                    {
                        string[] l;
                        int id, weight, recipe;
                        int[] prodLine = new int[4];
                        string name, dimensions;
                        string[] line = sr.ReadLine().Split(",");
                        Int32.TryParse(line[0], out id);
                        name = line[1];
                        l = line[2].Split(":");
                        for (int i = 0; i < 4; i++)
                            Int32.TryParse(l[i], out prodLine[i]);
                        Int32.TryParse(line[3], out weight);
                        dimensions = line[4];
                        Int32.TryParse(line[5], out recipe);
                        items.Add(new Item(id, name, prodLine, weight, dimensions, recipe));
                    }
                }
                return items;
            }
            else
                return null ;
        }
    }
}
