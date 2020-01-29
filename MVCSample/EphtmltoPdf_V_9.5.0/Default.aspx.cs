using ExpertPdf.HtmlToPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EphtmltoPdf_V_9._5._0
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PdfConverter pdfConverter = new PdfConverter();
            // pdfConverter.LicenseKey = "ORIIGQEZCAkJChkBFwkZCggXCAsXAAAAAA=="; 
            string htmlContent = File.ReadAllText(@"D:\Full_report_html.txt");
            var watch = System.Diagnostics.Stopwatch.StartNew();
          //  var html = RemoveWhitespaceFromHtmlPage(htmlContent);
            byte[] downloadBytes = pdfConverter.GetPdfBytesFromHtmlString(htmlContent);
            watch.Stop();
            var timeTakenToConvert = watch.ElapsedMilliseconds;
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "application/pdf");
            response.AddHeader("Content-Disposition", "attachment; filename=" + timeTakenToConvert + ".pdf; size=" + downloadBytes.Length.ToString());
            response.Flush();
            response.BinaryWrite(downloadBytes);
            response.Flush();
            response.End();

        }

        private static readonly Regex RegexBetweenTags = new Regex(@">(?! )\s+", RegexOptions.Compiled);
        private static readonly Regex RegexLineBreaks = new Regex(@"([\n\s])+?(?<= {2,})<", RegexOptions.Compiled);

        protected override void Render(HtmlTextWriter writer)
        {
            using (HtmlTextWriter htmlwriter = new HtmlTextWriter(new System.IO.StringWriter()))
            {
                base.Render(htmlwriter);
                string html = htmlwriter.InnerWriter.ToString();
                html = RemoveWhitespaceFromHtmlPage(html);
                writer.Write(html);
            }
        }

        public string RemoveWhitespaceFromHtmlPage(string html)
        {
            html = RegexBetweenTags.Replace(html, ">");
            html = RegexLineBreaks.Replace(html, "<");
            return html.Trim();
        }

    }
}