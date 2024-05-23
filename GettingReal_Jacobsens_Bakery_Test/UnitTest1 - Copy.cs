using GettingReal_Jacobsens_Bakery.Model;
using GettingReal_Jacobsens_Bakery.ViewModel;
using System.Windows.Shapes;

namespace GettingReal_Jacobsens_Bakery_Test
{
    [TestClass]
    public class UnitTest3
    {
        ProductionReport Report;
        ProductionProcess p1;
        ProductionProcess p2;
        PRRepo repo;
        PRRepo loadedRepo;
        Item item;

        [TestInitialize]
        public void SetupForTest()
        {
            item = new Item(220275, "Carousel", 100, 100, 100, 100, 125, "94X26", 381121);
            p1 = new ProductionProcess()
            {
                ProdStart = DateTime.Parse("14:30:00"),
                ProdEnd = DateTime.Parse("15:00:00"),
                Reason = "Omstilling."
            };
            p2 = new ProductionProcess()
            {
                ProdStart = DateTime.Parse("15:30:00"),
                ProdEnd = DateTime.Parse("16:30:00"),
                Reason = "Nedbrud på prægemaskine."
            };
            Report = new ProductionReport()
            {
                Date = DateTime.Today,
                Line = EnumLine.one,
                Team = EnumTeam.red,
                SigOne = "Lars Hansen",
                SigTwo = "Mette Boldt",
                Crumbles = 80,
                Spillage = 150,
                ProdStart = DateTime.Parse("14:00:00"),
                ProdEnd = DateTime.Parse("20:00:00"),
                ProdOrderId = "P101275",
                BoxesProduced = 300,
            };

            repo = new PRRepo();
            repo.SelectedReport = Report;
            repo.calculator.ItemRepo.AddItem(220275, "Carousel", 100, 100, 100, 100, 125, "94X26", 381121);
            repo.SelectedReport.SetItem(repo.GetItem(220275));
            //repo.SelectedReport.SetItem(220275);
            repo.SelectedReport.NewProcess(p1);
            repo.SelectedReport.NewProcess(p2);

            if (File.Exists("ReportRepo.txt"))
                File.Delete("ReportRepo.txt");
            if (File.Exists("Test1.txt"))
                File.Delete("Test1.txt");
        }

        [TestMethod]
        public void TestSave()
        {
            repo.SaveReports();
            Assert.AreEqual(true, File.Exists("ReportRepo.txt"));
        }

        [TestMethod]
        public void TestNamedSave()
        {
            repo.SaveRepo("Test1.txt");
            Assert.AreEqual(true, File.Exists("Test1.txt"));
        }

        [TestMethod]
        public void TestLoad()
        {
            repo.SaveRepo();
            LoadedRepo = new ItemRepo();
            LoadedRepo.LoadReports();
            int noOfElements = repo.Count();
            Assert.AreEqual(noOfElements, LoadedRepo.Count());
            Assert.AreEqual(Team.red, repo.SelectedReport.Team);
            Assert.AreEqual(TimeSpan.Parse("04:30:00"), repo.SelectedReport.DowntimeDuration);
            Assert.AreEqual(80, repo.SelectedReport.Crumbles);
            Assert.AreEqual(300, repo.SelectedReport.BoxesProduced);
            Assert.AreEqual("Carousel", repo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.Name);
        }

        [TestMethod]
        public void TestNamedLoad()
        {
            repo.SaveRepo("Test1.txt");
            LoadedRepo = new ItemRepo();
            LoadedRepo.LoadReports("Test1.txt");
            int noOfElements = repo.Count();
            Assert.AreEqual(noOfElements, LoadedRepo.Count());
            Assert.AreEqual(Team.red, repo.SelectedReport.Team);
            Assert.AreEqual(TimeSpan.Parse("04:30:00"), repo.SelectedReport.DowntimeDuration);
            Assert.AreEqual(80, repo.SelectedReport.Crumbles);
            Assert.AreEqual(300, repo.SelectedReport.BoxesProduced);
            Assert.AreEqual("Carousel", repo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.Name);
        }
    }
}