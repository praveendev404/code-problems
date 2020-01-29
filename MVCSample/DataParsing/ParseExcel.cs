using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParsing
{
    class ParseExcel
    {

        public T ReadExcelData<T>(FileInfo file, string excelSheetName)
        {
            string fileName = @"E:\ean-data.txt";
            DataTable excelData = new DataTable();
            string xlsxConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file.FullName + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
            string connectionString = string.Empty;
            connectionString = xlsxConnectionString;
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", excelSheetName), con))
                {
                    con.Open();
                    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                    {
                        adp.Fill(excelData);
                    }
                }
            }
            return (T)(object)excelData;
        }

     //   public static DataSet ReadExcelDataByOpenXml(string filePath)
        //{
        //    FileStream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);

        //    string ext = filePath.Substring(filePath.LastIndexOf('.'));

        //    IExcelDataReader excelReader;
        //    if (ext == ".xlsx")
        //    {
        //        // Reading from a OpenXml Excel file (2007 format; *.xlsx)
        //        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //    }
        //    else
        //    {
        //        // Reading from a OpenXml Excel file (*.xls)
        //        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //    }

        //    DataSet result = excelReader.AsDataSet();

        //    return result;
        //}
    }
}
