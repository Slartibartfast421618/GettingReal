using GettingReal_Jacobsens_Bakery;
using GettingReal_Jacobsens_Bakery.ViewModel;
using GettingReal_Jacobsens_Bakery.Model;
using System.Security.Cryptography.Pkcs;

namespace GettingReal_Jacobsens_Bakery_Test
{
    [TestClass]
    public class UnitTest1
    {
        ProductionReport Report;

        ProductionProcess p1;
        ProductionProcess p2;
        PRRepo repo;

        [TestInitialize]
        public void SetupForTest()
        {

            p1 = new ProductionProcess()
            {
                ProcStart = DateTime.Parse("14:30:00"),
                ProcEnd = DateTime.Parse("15:00:00"),
                Reason = "Omstilling."
            };
            p2 = new ProductionProcess()
            {
                ProcStart = DateTime.Parse("15:30:00"),
                ProcEnd = DateTime.Parse("16:30:00"),
                Reason = "Nedbrud på prægemaskine."
            };
            Report = new ProductionReport()
            {
                Date = DateTime.Parse("01/02/2003"),
                Line = Line.one,
                Team = Team.red,
                SigOne = "Lars Hansen",
                SigTwo = "Mette Boldt",
                RecipeId = 381121,
                Crumbles = 80,
                Spillage = 150,
                ProdStart = DateTime.Parse("14:00:00"),
                ProdEnd = DateTime.Parse("20:00:00"),
                ProdOrderId = "P101275",
                BoxesProduced = 300,
                //ItemId = 220275,
                //Recipe = 381121

            };

            Report.SetItem(220275, 381121);
            repo = new PRRepo();
            Report.NewProcess(p1);
            Report.NewProcess(p2);
        }
        [TestMethod]
        public void TestOfProdTeam()
        {
            Assert.AreEqual(DateTime.Parse("01/02/2003"), Report.Date);
            Assert.AreEqual(Line.one, Report.Line);
            Assert.AreEqual(Team.red, Report.Team);
            Assert.AreEqual("Lars Hansen", Report.SigOne);
        }
        [TestMethod]
        public void TestNewProcess()
        {
            // Act
            Report.ProdTeam.CalculateTotalProcessDowntime();

            // Assert
            Assert.AreEqual(TimeSpan.Parse("01:30:00"), Report.DowntimeDuration);

            // Act
            ProductionProcess p3 = new ProductionProcess()
            {
                ProcStart = DateTime.Parse("17:30:00"),
                ProcEnd = DateTime.Parse("20:30:00"),
                Reason = "Nedbrud på prægemaskine."
            };
            Report.NewProcess(p3);
            Report.ProdTeam.CalculateTotalProcessDowntime();

            // Assert
            Assert.AreEqual(TimeSpan.Parse("04:30:00"), Report.DowntimeDuration);
        }
        [TestMethod]
        public void TestActiveRecipe()
        {
            Assert.AreEqual(381121, Report.RecipeId);
            Assert.AreEqual(80, Report.Crumbles);
            Assert.AreEqual(150, Report.Spillage);
        }
        [TestMethod]
        public void TestProduction()
        {
            Assert.AreEqual(DateTime.Parse("14:00:00"), Report.ProdStart);
            Assert.AreEqual(DateTime.Parse("20:00:00"), Report.ProdEnd);
            Assert.AreEqual("P101275", Report.ProdOrderId);
            Assert.AreEqual(300, Report.BoxesProduced);
        }
        [TestMethod]
        public void TestProdItem()
        {
            Assert.AreEqual(220275, Report.ItemId);

            Assert.AreEqual(381121, Report.ProdTeam.Recipe.Production.ProdItem.RecipeId);

            Assert.AreEqual(381121, Report.Recipe);
        }
        [TestMethod]
        public void TestProdProc()
        {
            Assert.AreEqual(DateTime.Parse("15:00:00"), Report.ProdTeam.PPRepo[0].ProcEnd);
            Assert.AreEqual(p1.Reason, Report.ProdTeam.PPRepo[0].Reason);
            Assert.AreEqual(p2.DowntimeDuration(), Report.ProdTeam.PPRepo[1].DowntimeDuration());

        }
    }
}