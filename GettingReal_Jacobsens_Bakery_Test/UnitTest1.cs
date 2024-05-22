using GettingReal_Jacobsens_Bakery;
using GettingReal_Jacobsens_Bakery.ViewModel;
using GettingReal_Jacobsens_Bakery.Model;
using System.Security.Cryptography.Pkcs;
using GettingReal_Jacobsens_Bakery_Test;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace GettingReal_Jacobsens_Bakery_Test
{
    [TestClass]
    public class UnitTest1
    {
        ProductionReport Report;

        ProductionProcess p1;
        ProductionProcess p2;
        public PRRepo repo;
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
                Line = Line.one,
                Team = Team.red,
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
            
            
        }
        [TestMethod]
        public void TestOfProdTeam()
        {
            Assert.AreEqual(DateTime.Today, repo.SelectedReport.Date);
            Assert.AreEqual(Line.one, repo.SelectedReport.Line);
            Assert.AreEqual(Team.red, repo.SelectedReport.Team);
            Assert.AreEqual("Lars Hansen", repo.SelectedReport.SigOne);
        }
        [TestMethod]
        public void TestNewProcess()
        {
            // Assert
            Assert.AreEqual(TimeSpan.Parse("01:30:00"), repo.SelectedReport.DowntimeDuration);

            // Act
            ProductionProcess p3 = new ProductionProcess()
            {
                ProdStart = DateTime.Parse("17:30:00"),
                ProdEnd = DateTime.Parse("20:30:00"),
                Reason = "Nedbrud på prægemaskine."
            };
            repo.SelectedReport.NewProcess(p3);

            // Assert
            Assert.AreEqual(TimeSpan.Parse("04:30:00"), repo.SelectedReport.DowntimeDuration);
        }
        [TestMethod]
        public void TestActiveRecipe()
        {
            Assert.AreEqual(381121, repo.SelectedReport.RecipeId);
            Assert.AreEqual(80, repo.SelectedReport.Crumbles);
            Assert.AreEqual(150, repo.SelectedReport.Spillage);
        }
        [TestMethod]
        public void TestProduction()
        {
            Assert.AreEqual(DateTime.Parse("14:00:00"), repo.SelectedReport.ProdStart);
            Assert.AreEqual(DateTime.Parse("20:00:00"), repo.SelectedReport.ProdEnd);
            Assert.AreEqual("P101275", repo.SelectedReport.ProdOrderId);
            Assert.AreEqual(300, repo.SelectedReport.BoxesProduced);
        }
        [TestMethod]
        public void TestProdItem()
        {
            Assert.AreEqual(220275, repo.SelectedReport.ItemId);

            Assert.AreEqual(381121, repo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.RecipeId);

            Assert.AreEqual(381121, repo.SelectedReport.Recipe);
            Assert.AreEqual(100, repo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.Line[1]);
            Assert.AreEqual("94X26", repo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.BoxDimensions);
            Assert.AreEqual("Carousel", repo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.Name);
            Assert.AreEqual(125, repo.SelectedReport.ProdTeam.Recipe.Production.ProdItem.UnitWeight);
        }
        [TestMethod]
        public void TestProdProc()
        {
            Assert.AreEqual(DateTime.Parse("15:00:00"), repo.SelectedReport.ProdTeam.PPRepo[0].ProdEnd);
            Assert.AreEqual(p1.Reason, repo.SelectedReport.ProdTeam.PPRepo[0].Reason);
            Assert.AreEqual(p2.DowntimeDuration(), repo.SelectedReport.ProdTeam.PPRepo[1].DowntimeDuration());

        }
    }
}