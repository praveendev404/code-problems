//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleDemo
//{
//    public class ReadExcelUsingOpenXML
//    {
//        public static DataSet GetExcelFileData(string filePath)
//        {
//            var stream = new FileStream(filePath, FileMode.Open);

//            //string ext = filePath.Substring(filePath.LastIndexOf('.')).ToLower();
//            string ext = Path.GetExtension(filePath);
//            IExcelDataReader excelReader;
//            if (ext.ToLower() == ".xlsx")
//            {
//                // Reading from a OpenXml Excel file (2007 format; *.xlsx)
//                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
//            }
//            else
//            {
//                // Reading from a OpenXml Excel file (*.xls)
//                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
//            }

//            excelReader.IsFirstRowAsColumnNames = true;
//            DataSet result = excelReader.AsDataSet();
//            return result;

//        }
//        static void Main(string[] args)
//        {
//            DataTable dt = new DataTable();

//            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(@"D:\cts1.xlsx", false))
//            {

//                Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

//                //Get the Worksheet instance.
//                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

//                //Fetch all the rows present in the Worksheet.
//                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

//                //Create a new DataTable.

//                //Loop through the Worksheet rows.
//                foreach (Row row in rows)
//                {
//                    //Use the first row to add columns to DataTable.
//                    if (row.RowIndex.Value == 1)
//                    {
//                        foreach (Cell cell in row.Descendants<Cell>())
//                        {
//                            dt.Columns.Add(GetValue(doc, cell));
//                        }
//                    }
//                    else
//                    {
//                        //Add rows to DataTable.
//                        dt.Rows.Add();
//                        int i = 0;
//                        foreach (Cell cell in row.Descendants<Cell>())
//                        {
//                            dt.Rows[dt.Rows.Count - 1][i] = GetValue(doc, cell);
//                            i++;
//                        }
//                    }
//                }

//            }
//            IEnumerable<DataRow> sequence = dt.AsEnumerable();
//            List<Contacts> cc = new List<Contacts>();
//            cc = (from DataRow row in dt.Rows

//                  select new Contacts
//                  {
//                      FirstName = row[0].ToString(),
//                      MiddleName = row[1].ToString(),
//                      LastName = row[2].ToString(),
                      
//                      MobilePhone = (row[3].ToString().Contains(":::") ? row[3].ToString().Split(':')[0] : row[3].ToString()).Replace("-","").Replace(" ","").Replace("+91","")

//                  }).ToList();
//            cc = cc.DistinctBy(x => x.MobilePhone).ToList();
//            DataTable dttt = cc.ToDataTable();

//        }
       

//        private static string GetValue(SpreadsheetDocument doc, Cell cell)
//        {
//            string value = cell.CellValue?.InnerText;
//            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
//            {
//                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
//            }
//            return value;
//        }
//    }
//    public class Contacts
//    {
//        public string FirstName { get; set; }
//        public string MiddleName { get; set; }
//        public string LastName { get; set; }
//        public string MobilePhone { get; set; }
//    }
//    public static class Helper
//    {
//        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
//        {
//            HashSet<TKey> seenKeys = new HashSet<TKey>();
//            foreach (TSource element in source)
//            {
//                if (seenKeys.Add(keySelector(element)))
//                {
//                    yield return element;
//                }
//            }
//        }
//        public static DataTable ToDataTable<T>(this List<T> items)
//        {
//            DataTable dataTable = new DataTable(typeof(T).Name);

//            //Get all the properties
//            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
//            foreach (PropertyInfo prop in Props)
//            {
//                //Defining type of data column gives proper data table 
//                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
//                //Setting column names as Property names
//                dataTable.Columns.Add(prop.Name, type);
//            }
//            foreach (T item in items)
//            {
//                var values = new object[Props.Length];
//                for (int i = 0; i < Props.Length; i++)
//                {
//                    //inserting property values to datatable rows
//                    values[i] = Props[i].GetValue(item, null);
//                }
//                dataTable.Rows.Add(values);
//            }
//            //put a breakpoint here and check datatable
//            return dataTable;
//        }
//    }
//}
