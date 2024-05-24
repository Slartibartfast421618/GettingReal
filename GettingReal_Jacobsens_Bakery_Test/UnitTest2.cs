using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingReal_Jacobsens_Bakery;
using GettingReal_Jacobsens_Bakery.ViewModel;

namespace GettingReal_Jacobsens_Bakery_Test
{
    [TestClass]
    public class UnitTest2
    {
        public ItemRepo repo;
        public ItemRepo LoadedRepo;

        [TestInitialize]
        public void SetupForTest()
        {
            repo = new ItemRepo();

            repo.AddItem(102450, "Tivoli Chocolate Chip Cookies", 100, 100, 100, 100, 125, "160x160x350", 380050);
            repo.AddItem(101225, "Royal Tin butter cookies", 125, 125, 125, 125, 350, "160x160x500", 380525);
            repo.AddItem(202405, "Carousel", 150, 150, 150, 150, 1816, "265X124", 350034);

            if (File.Exists("ItemRepo.txt"))
                File.Delete("ItemRepo.txt");
            if (File.Exists("Test1.txt"))
                File.Delete("Test1.txt");

        }

        [TestMethod]
        public void TestSaveLoad()
        {
            repo.SaveRepo();
            LoadedRepo = new ItemRepo();
            LoadedRepo.LoadRepo();
            int noOfElements = repo.Count();
            Assert.AreEqual(noOfElements, LoadedRepo.Count());
            Assert.AreEqual(repo.FindItem(102450).ToString(), LoadedRepo.FindItem(102450).ToString());
            Assert.AreEqual(repo.FindItem(101225).ToString(), LoadedRepo.FindItem(101225).ToString());
            Assert.AreEqual(repo.FindItem(202405).ToString(), LoadedRepo.FindItem(202405).ToString());
        }

        [TestMethod]
        public void TestNamedSaveLoad()
        {
            repo.SaveRepo("Test1.txt");
            LoadedRepo = new ItemRepo();
            LoadedRepo.LoadRepo("Test1.txt");
            int noOfElements = repo.Count();
            Assert.AreEqual(noOfElements, LoadedRepo.Count());
            Assert.AreEqual(repo.FindItem(102450).ToString(), LoadedRepo.FindItem(102450).ToString());
            Assert.AreEqual(repo.FindItem(101225).ToString(), LoadedRepo.FindItem(101225).ToString());
            Assert.AreEqual(repo.FindItem(202405).ToString(), LoadedRepo.FindItem(202405).ToString());
        }
    }
}
