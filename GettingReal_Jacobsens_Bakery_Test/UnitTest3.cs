using GettingReal_Jacobsens_Bakery.Model;
using GettingReal_Jacobsens_Bakery.ViewModel;
using System.Windows.Shapes;

namespace GettingReal_Jacobsens_Bakery_Test
{
//    [TestClass]
//    public class UnitTest3
//    {
//        ProductionReport Report;
//        ProductionProcess p1;
//        ProductionProcess p2;
//        PRRepo prrepo;
//        PRRepo loadedRepo;
//        Item item;

//        [TestInitialize]
//        public void SetupForTest()
//        {
//            item = new Item(220275, "Carousel", 100, 100, 100, 100, 125, "94X26", 381121);
//            p1 = new ProductionProcess()
//            {
//                ProcStart = DateTime.Parse("14:30:00"),
//                ProcEnd = DateTime.Parse("15:00:00"),
//                Reason = "Omstilling."
//            };
//            p2 = new ProductionProcess()
//            {
//                ProcStart = DateTime.Parse("15:30:00"),
//                ProcEnd = DateTime.Parse("16:30:00"),
//                Reason = "Nedbrud på prægemaskine."
//            };
//            Report = new ProductionReport()
//            {
//                Date = DateTime.Today,
//                Line = EnumLine.Et,
//                Team = EnumTeam.Rød,
//                SigOne = "Lars Hansen",
//                SigTwo = "Mette Boldt",
//                Crumbles = 80,
//                Spillage = 150,
//                ProdStart = DateTime.Parse("14:00:00"),
//                ProdEnd = DateTime.Parse("20:00:00"),
//                ProdOrderId = "P101275",
//                BoxesProduced = 300,
//            };

//            prrepo = new PRRepo();
//            prrepo.SelectedReport = Report;
//            prrepo.ItemRepo.AddItem(220275, "Carousel", 100, 100, 100, 100, 125, "94X26", 381121);
//            prrepo.SelectedReport.SetItem(prrepo.GetItem(220275));
//            //repo.SelectedReport.SetItem(220275);
//            prrepo.SelectedReport.NewProcess(p1);
//            prrepo.SelectedReport.NewProcess(p2);

//            if (File.Exists("ReportRepo.txt"))
//                File.Delete("ReportRepo.txt");
//            if (File.Exists("Test1.txt"))
//                File.Delete("Test1.txt");
//        }

//        [TestMethod]
//        public void TestSave()
//        {
//            prrepo.SaveReports();
//            Assert.AreEqual(true, File.Exists("ReportRepo.txt"));
//        }

//        [TestMethod]
//        public void TestNamedSave()
//        {
//            prrepo.PRDatahandler.SaveProductionReports("Test1.txt");
//            Assert.AreEqual(true, File.Exists("Test1.txt"));
//        }

//        [TestMethod]
//        public void TestLoad()
//        {
//            prrepo.SaveRepo();
//            LoadedRepo = new ItemRepo();
//            LoadedRepo.LoadReports();
//            int noOfElements = prrepo.Count();
//            Assert.AreEqual(noOfElements, LoadedRepo.Count());
//            Assert.AreEqual(EnumTeam.Rød, prrepo.SelectedReport.Team);
//            Assert.AreEqual(TimeSpan.Parse("04:30:00"), prrepo.SelectedReport.DowntimeDuration);
//            Assert.AreEqual(80, prrepo.SelectedReport.Crumbles);
//            Assert.AreEqual(300, prrepo.SelectedReport.BoxesProduced);
//            Assert.AreEqual("Carousel", prrepo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.Name);
//        }

//        [TestMethod]
//        public void TestNamedLoad()
//        {
//            prrepo.SaveRepo("Test1.txt");
//            LoadedRepo = new ItemRepo();
//            LoadedRepo.LoadReports("Test1.txt");
//            int noOfElements = prrepo.Count();
//            Assert.AreEqual(noOfElements, LoadedRepo.Count());
//            Assert.AreEqual(EnumTeam.Rød, prrepo.SelectedReport.Team);
//            Assert.AreEqual(TimeSpan.Parse("04:30:00"), prrepo.SelectedReport.DowntimeDuration);
//            Assert.AreEqual(80, prrepo.SelectedReport.Crumbles);
//            Assert.AreEqual(300, prrepo.SelectedReport.BoxesProduced);
//            Assert.AreEqual("Carousel", prrepo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.Name);
//        }
//    }
}