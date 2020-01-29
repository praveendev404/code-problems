//using Excel;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleDemo
//{
//    class ConvertPdftoExcel
//    {

//        static void Main(string[] args)
//        {
//            //string pathToPdf = @"C:\Users\pbanda\Desktop\Competitor reports\BP - Castrol\A9484730140622";
//            string pathToPdf = @"C:\Users\pbanda\Desktop\Competitor reports\Gulf Reports\IG 2 Auxilary Engine No 1";
//            ConvertPdfToExcel(pathToPdf + ".pdf");
//            DataSet ds = new DataSet();
//            ds = ReadExcelDataByOpenXml(pathToPdf + ".xls");
//            DataTable dt = new DataTable();
//            dt = ds.Tables[0];
//        }
//        private static void ConvertPdfToExcel(string pathToPdf)
//        {

//            string pathToExcel = Path.ChangeExtension(pathToPdf, ".xls");

//            // Convert only tables from PDF to XLS spreadsheet and skip all textual data.
//            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

//            // This property is necessary only for registered version
//            //f.Serial = "XXXXXXXXXXX";

//            // 'true' = Convert all data to spreadsheet (tabular and even textual).
//            // 'false' = Skip textual data and convert only tabular (tables) data.
//            f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = false;

//            // 'true'  = Preserve original page layout.
//            // 'false' = Place tables before text.
//            f.ExcelOptions.PreservePageLayout = true;

//            f.OpenPdf(pathToPdf);

//            if (f.PageCount > 0)
//            {
//                int result = f.ToExcel(pathToExcel);

//                // Open the resulted Excel workbook.
//                if (result == 0)
//                {
//                    //System.Diagnostics.Process.Start(pathToExcel);
//                }
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
