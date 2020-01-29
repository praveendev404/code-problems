using Antlr3.ST;
using Bytescout.PDFExtractor;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PdfConvert.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string html = "hello world";
            using (StreamReader reader = new StreamReader(Server.MapPath("~") + "/pages/TestPdf.html"))
            {
                String line = reader.ReadToEnd();
                Text2PDF(line);
            }

            //pdfText(@"C:\Users\pbanda\Desktop\Read\IG_2_Auxilary_Engine_No_2.pdf");
            //string file = @"C:\Users\pbanda\Desktop\Read\IG_2_Auxilary_Engine_No_2.pdf";
            //this.ExportPDFToExcel(file);

            //// Create Bytescout.PDFExtractor.CSVExtractor instance
            //CSVExtractor extractor = new CSVExtractor();
            //extractor.RegistrationName = "demo";
            //extractor.RegistrationKey = "demo";

            //// Load sample PDF document
            //extractor.LoadDocumentFromFile(file);

            ////extractor.CSVSeparatorSymbol = ","; // you can change CSV separator symbol (if needed) from "," symbol to another if needed for non-US locales

            //extractor.SaveCSVToFile("output.csv");

            //Process.Start("output.csv");
            return View();
        }

        private void ExportPDFToExcel(string fileName)
        {
            StringBuilder text = new StringBuilder();
            PdfReader pdfReader = new PdfReader(fileName);
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.UTF8.GetBytes(currentText)));
                text.Append(currentText);
                pdfReader.Close();
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReceiptExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(text);
            Response.Flush();
            Response.End();
        }

        public static string pdfText(string path)
        {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text = PdfTextExtractor.GetTextFromPage(reader, page);//\n
                iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy itp = new SimpleTextExtractionStrategy();
                //char[] delimiters = new char[] { '\n', '|', '\r' };
                string[] strArray = text.Split('\n');
                foreach (var item in strArray)
                {
                    if (item.Contains("Sample No"))
                    {
                        string strItem = item.Replace("Sample No", "");
                        string[] sampleItems = strItem.Split('\t');
                        string[] sampleItems1 = strItem.Split(' ');
                    }
                    if (item.Contains("Oil on Label"))
                    {
                        string strOilItem = item.Replace("Oil on Label", "");
                        string[] oilItems = strOilItem.Split('\t');
                        string[] oilItems1 = strOilItem.Split(' ');
                    }
                }

            }
            reader.Close();
            return text;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        protected void Text2PDF(string PDFText)
        {
            //HttpContext context = HttpContext.Current;
            StringReader reader = new StringReader(PDFText);

            //Create PDF document 
            Document document = new Document(PageSize.A4);
            HTMLWorker parser = new HTMLWorker(document);

            string PDF_FileName = Server.MapPath("~") + "/App_Data/PDF_File.pdf";
            PdfWriter.GetInstance(document, new FileStream(PDF_FileName, FileMode.Create));
            document.Open();

            try
            {
                parser.Parse(reader);
            }
            catch (Exception ex)
            {
                //Display parser errors in PDF. 
                Paragraph paragraph = new Paragraph("Error!" + ex.Message);
                Chunk text = paragraph.Chunks[0] as Chunk;

                document.Add(paragraph);
            }
            finally
            {
                document.Close();
                DownLoadPdf(PDF_FileName);
            }
        }


        private void DownLoadPdf(string PDF_FileName)
        {
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(PDF_FileName);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.Flush();
            Response.BinaryWrite(buffer);
            Response.End();
        }

        public void printpdf(string html)
        {

            String htmlText = html.ToString();
            Document document = new Document();
            string filePath = HostingEnvironment.MapPath("~/Content/Pdf/");
            PdfWriter.GetInstance(document, new FileStream(filePath + "\\pdf-" + "Test" + ".pdf", FileMode.Create));

            document.Open();
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
            hw.Parse(new StringReader(htmlText));
            document.Close();
        }







        public FileResult PdfConverter()
        {
            string htmlText = string.Empty;
            string filename = string.Empty;
            filename = "Test";
            htmlText += "<div></div>";
            string filePath = Request.PhysicalApplicationPath + "/Upload/Test/" + filename.Replace(" ", "") + ".pdf";

            using (FileStream docFile = new FileStream(filePath, FileMode.Create))
            {



                string url = "http://" + Request.Url.Authority + "/account/Login";


                Dictionary<string, object> attr = new Dictionary<string, object>();
                attr.Add("logo", new TemplateHelper().getlogo());
                attr.Add("Insuredname", "Praveen Kumar");
                attr.Add("EmailId", "praveenkumar.b@techraq.com");
                attr.Add("InsuredDoB", "11-05-2016");
                attr.Add("InsuredAge", "40");
                attr.Add("MobileNo", "9866078078");
                attr.Add("SpouseDoB", "11-05-2016");
                attr.Add("SpouseAge", "15");
                attr.Add("DoughterDoB", "11-05-2016");
                attr.Add("DoughterAge", "10");
                attr.Add("SonDoB", "11-05-2016");
                attr.Add("SonAge", "8");
                attr.Add("NoofAdults", "2");
                attr.Add("NoofChildren", "2");
                attr.Add("Smoker", "Yes");
                attr.Add("Preexistingdiseases", "No");
                attr.Add("MaternityCover", "Yes");
                attr.Add("RestorationBenefits", "Yes");


                htmlText = new TemplateHelper().GetTemplateBody(attr, "~/App_Data/test.html");

                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30, 30, 10, 30);
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, docFile);
                document.Open();

                iTextSharp.text.html.simpleparser.StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
                iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);

                hw.Parse(new StringReader(htmlText));
                document.Close();
                writer.Close();
            }


            return File(filePath, "application/pdf", filename.Replace(" ", "") + ".pdf");

        }
    }

    public class TemplateHelper
    {
        public string GetTemplateBody(Dictionary<string, object> tmpltItemDict, string url)
        {
            StringTemplate strTmplt = new StringTemplate();
            string filePath = string.Empty;
            filePath = HttpContext.Current.Server.MapPath(url);
            if (System.IO.File.Exists(filePath))
            {
                strTmplt.Template = File.ReadAllText(filePath);
                strTmplt.Attributes = tmpltItemDict;
            }
            return strTmplt.ToString();
        }
        public string getlogo()
        {
            string strlogoPath = HttpContext.Current.Server.MapPath("~/App_Data/zenmoney_logo.png");
            return strlogoPath;
        }

    }

}
