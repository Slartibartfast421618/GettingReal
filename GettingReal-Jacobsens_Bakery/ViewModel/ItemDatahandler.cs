using GettingReal_Jacobsens_Bakery.Model;
using System.IO;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class ItemDatahandler
    {               
        string DocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private string _dataFileName;
        public string DataFileName
        {
            get { return _dataFileName; }
        }

        public ItemDatahandler()
        {
            _dataFileName = "ItemRepo.txt";
        }



        //public Item LoadItem()
        //{

        //    using (StreamReader sr = new StreamReader(Path.Combine(DocPath, DataFileName)))
        //    {

        //        string line = sr.ReadLine();

        //        string[] parts = line.Split(';');



        //        if (parts.Length != 9)
        //        {
        //            throw new InvalidDataException("Dataformat in file not correct");
        //        }

        //        int.TryParse(parts[0], out int itemId);
        //        string name = parts[1];
        //        int.TryParse(parts[2], out int l1);
        //        int.TryParse(parts[3], out int l2);
        //        int.TryParse(parts[4], out int l3);
        //        int.TryParse(parts[5], out int l4);
        //        int.TryParse(parts[6], out int weight);
        //        string dimensions = parts[7];
        //        int.TryParse(parts[8], out int recipe);

        //        Item item = new Item();

        //        item.SetItem(itemId, name, l1, l2, l3, l4, weight, dimensions, recipe);
        //        return item;
        //    }
            
        //}

        public List<Item> LoadPersons()
        {
            List<Item> items = new List<Item>();

            using (StreamReader sr = new StreamReader(Path.Combine(DocPath, DataFileName)))
            {
                foreach (string line in sr.ReadToEnd().Trim().Split('\n'))
                {
                    string[] parts = line.Trim().Split(';');

                    if (parts.Length != 9)
                    {
                        throw new InvalidDataException("Dataformat in file not correct");
                    }

                    int.TryParse(parts[0], out int itemId);
                    string name = parts[1];
                    int.TryParse(parts[2], out int l1);
                    int.TryParse(parts[3], out int l2);
                    int.TryParse(parts[4], out int l3);
                    int.TryParse(parts[5], out int l4);
                    int.TryParse(parts[6], out int weight);
                    string dimensions = parts[7];
                    int.TryParse(parts[8], out int recipe);

                    Item item = new Item();

                    item.SetItem(itemId, name, l1, l2, l3, l4, weight, dimensions, recipe);
                    items.Add(item);                                    
                    
                }

            }
            return items;
        }

        //public void SaveItem(Item person)
        //{
        //    using (StreamWriter sw = new StreamWriter(Path.Combine(DocPath, DataFileName)))
        //    {
        //        sw.WriteLine(person.MakeTitle());
        //    }

        //}

        public void SaveItems(List<Item> item)
        {

            using (StreamWriter sw = new StreamWriter(Path.Combine(DocPath, DataFileName)))
            {
                for (int i = 0; i < item.Count; i++)
                {
                    sw.WriteLine(item[i].ToString());
                }

            }
        }



    }

}

