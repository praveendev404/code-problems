//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.OleDb;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Configuration;
//using System.Web.Http;
//using Excel;
//using System.Globalization;
//using ExcelDataReader;

//namespace ConsoleDemo
//{
//    public class Excel
//    {
//        static void Main(string[] args)
//        {
//            //string s = null;
//            //int ik = Convert.ToInt32(s);
//            //int iwk = int.Parse(s);
//            DataTable excelData = new DataTable();
//            Excel ex = new Excel();
//            DataSet ds = new DataSet();
//            DataTable dtcsv = GetDataTableFromCsv("E:\\ExcelDemo\\output.csv", false);
//            ds = ReadExcelDataByOpenXml("E:\\ExcelDemo\\1296548_25Jan2017_1524.csv");
//            DataTable dt = new DataTable();
//            dt = ds.Tables[0];
//            excelData = ex.LoadExcel();
//        }

//        public DataTable LoadExcel()
//        {

//            DataTable excelData = new DataTable();

//            //string xlsxConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\ExcelDemo\\Advance.xlsx;Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
//            string xlsxConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\ExcelDemo\\1296548_25Jan2017_1524.xlsx;Mode=ReadWrite;Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
//            string connectionString = string.Empty;
//            connectionString = xlsxConnectionString;
//            using (OleDbConnection con = new OleDbConnection(connectionString))
//            {
//                using (OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", "1296548"), con))
//                {
//                    con.Open();
//                    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
//                    {
//                        adp.Fill(excelData);
//                    }
//                }
//            }


//            DataTable dt = new DataTable();
//            string path = @"E:\ExcelDemo\listXLS.xls";
//            string connStr = string.Empty;// @"Provider=Microsoft.ACE.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";
//            if (Path.GetExtension(path).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
//                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
//            else
//                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

//            using (OleDbConnection con = new OleDbConnection(connStr))
//            {
//                string sheet = @"SELECT * FROM [Sheet1$]";
//                using (OleDbCommand cmd = new OleDbCommand(sheet, con))
//                {

//                    con.Open();
//                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
//                    {
//                        da.Fill(dt);
//                    }
//                }
//            }
//            return excelData;
//        }

//        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
//        {
//            string header = isFirstRowHeader ? "Yes" : "No";

//            string pathOnly = Path.GetDirectoryName(path);
//            string fileName = Path.GetFileName(path);

//            string sql = @"SELECT * FROM [" + fileName + "]";

//            using (OleDbConnection connection = new OleDbConnection(
//                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
//                      ";Extended Properties=\"Text;HDR=" + header + "\""))
//            using (OleDbCommand command = new OleDbCommand(sql, connection))
//            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
//            {
//                DataTable dataTable = new DataTable();
//                dataTable.Locale = CultureInfo.CurrentCulture;
//                adapter.Fill(dataTable);
//                return dataTable;
//            }
//        }

//        public static DataSet ReadExcelDataByOpenXml(string filePath)
//        {
//            FileStream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);

//            string ext = filePath.Substring(filePath.LastIndexOf('.'));

//            IExcelDataReader excelReader;
//            if (ext == ".xlsx")
//            {
//                // Reading from a OpenXml Excel file (2007 format; *.xlsx)
//                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
//            }
//            else
//            {
//                // Reading from a OpenXml Excel file (*.xls)
//                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
//            }

//            DataSet result = excelReader.AsDataSet();

//            return result;
//        }
//    }
//}
