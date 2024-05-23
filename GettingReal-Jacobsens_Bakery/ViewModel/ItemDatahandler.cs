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
using System.Windows.Media.Media3D;
using System.Xml.Linq;


namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ItemDatahandler

    {
        private string FileName = "ItemRepo.txt";
        //private string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private string DocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        public void SaveItems(ObservableCollection<Item> repo, string fileName)
        {
            // (StreamWriter sw = new StreamWriter(Path.Combine(path, fileName), false))
            using (StreamWriter sw = new StreamWriter(Path.Combine(DocPath, fileName), false))
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
            //using (StreamWriter sw = new StreamWriter(Path.Combine(path, FileName), false))
            using (StreamWriter sw = new StreamWriter(Path.Combine(DocPath, FileName), false))
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
            if (File.Exists(Path.Combine(DocPath, fileName)))
            {
                ObservableCollection<Item> items = new ObservableCollection<Item>();
                //using (StreamReader sr = new StreamReader(Path.Combine(path, fileName)))
                using (StreamReader sr = new StreamReader(Path.Combine(DocPath, fileName)))
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
            //if (File.Exists(Path.Combine(path, FileName)))
            if (File.Exists(Path.Combine(DocPath, FileName)))
            {
                ObservableCollection<Item> items = new ObservableCollection<Item>();
                //using (StreamReader sr = new StreamReader(Path.Combine(path, FileName)))
                using (StreamReader sr = new StreamReader(Path.Combine(DocPath, FileName)))
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
    }
}
