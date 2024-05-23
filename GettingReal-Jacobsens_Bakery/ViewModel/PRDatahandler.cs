using GettingReal_Jacobsens_Bakery.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_Jacobsens_Bakery.ViewModel
{
    public class PRDatahandler
    {
        string DocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private string _dataFileName;
        public string DataFileName
        {
            get { return _dataFileName; }
        }

        public PRDatahandler()
        {
            _dataFileName = "PRRepo.txt";
        }



        public ProductionReport LoadProductionReport()
        {

            using (StreamReader sr = new StreamReader(Path.Combine(DocPath, DataFileName)))
            {

                string line = sr.ReadLine();

                string[] parts = line.Split(';');

                if (parts.Length != 12)
                {
                    throw new InvalidDataException("Dataformat in file not correct");
                }

                DateTime.TryParse(parts[0], out DateTime Date);
                EnumTeam.TryParse(parts[1], out EnumTeam ProdTeam);
                EnumLine.TryParse(parts[2], out EnumLine ProdLine);
                string EmployeeOne = parts[3];
                string EmployeeTwo = parts[4];
                int.TryParse(parts[5], out int RecipeId);
                int.TryParse(parts[6], out int Crumbles);
                DateTime.TryParse(parts[7], out DateTime ProdStart);
                DateTime.TryParse(parts[8], out DateTime ProdEnd);
                string ProdOrderId = parts[9];
                int.TryParse(parts[10], out int BoxesProduced);
                int.TryParse(parts[11], out int ItemId);
                //int.TryParse(parts[12], out int recipe);

                ProductionReport productionReport = new ProductionReport
                    (Date, ProdTeam, ProdLine, EmployeeOne, EmployeeTwo, 
                    RecipeId, Crumbles, ProdStart, ProdEnd, ProdOrderId, 
                    BoxesProduced, ItemId);
                return productionReport;
            }

        }

        

        public List<ProductionReport> LoadProductionReports()
        {
            List<ProductionReport> ReportRepo = new List<ProductionReport>();
            if (File.Exists(Path.Combine(DocPath, DataFileName)))
            {
                using (StreamReader sr = new StreamReader(Path.Combine(DocPath, DataFileName)))
                {
                    foreach (string line in sr.ReadToEnd().Trim().Split('\n'))
                    {
                        if (line != null)
                        {
                            string[] parts = line.Trim().Split(';');

                            if (parts.Length != 12)
                            {
                                throw new InvalidDataException("Dataformat in file not correct");
                            }

                            DateTime.TryParse(parts[0], out DateTime Date);
                            EnumTeam.TryParse(parts[1], out EnumTeam ProdTeam);
                            EnumLine.TryParse(parts[2], out EnumLine ProdLine);
                            string EmployeeOne = parts[3];
                            string EmployeeTwo = parts[4];
                            int.TryParse(parts[5], out int RecipeId);
                            int.TryParse(parts[6], out int Crumbles);
                            DateTime.TryParse(parts[7], out DateTime ProdStart);
                            DateTime.TryParse(parts[8], out DateTime ProdEnd);
                            string ProdOrderId = parts[9];
                            int.TryParse(parts[10], out int BoxesProduced);
                            int.TryParse(parts[11], out int ItemId);
                            //int.TryParse(parts[12], out int recipe);

                            ProductionReport productionReport = new ProductionReport
                                (Date, ProdTeam, ProdLine, EmployeeOne, EmployeeTwo,
                                RecipeId, Crumbles, ProdStart, ProdEnd, ProdOrderId,
                                BoxesProduced, ItemId);
                            ReportRepo.Add(productionReport);
                        }
                    }
                }
            }
            //else
            //    MakeFileExist();

            return ReportRepo;
        }

        public void SaveProductionReport(List<ProductionReport> ReportRepo)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(DocPath, DataFileName)))
            {
                sw.WriteLine(ReportRepo.ToString());
            }
        }

        public void SaveProductionReports(List<ProductionReport> ReportRepo)
        {

            using (StreamWriter sw = new StreamWriter(Path.Combine(DocPath, DataFileName)))
            {
                for (int i = 0; i < ReportRepo.Count; i++)
                {
                    sw.WriteLine(ReportRepo[i].ToString());
                }
            }
        }
    }
}
