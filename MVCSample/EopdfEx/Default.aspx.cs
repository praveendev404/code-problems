using EO.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace EopdfEx
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlToPdf.Options.PageSize = PdfPageSizes.A4;// new SizeF(PdfPageSizes.A4.Height, PdfPageSizes.A4.Width);
            HtmlToPdf.Options.OutputArea = new RectangleF(0.05f, 0.07f, 8.17f, 12f);



            MemoryStream ms = new MemoryStream();
            string fileName = "ANGLO-EASTERN SHIP MANAGEMENT";
            var watch = System.Diagnostics.Stopwatch.StartNew();
            HtmlToPdf.ConvertUrl("D:\\" + fileName + ".html", ms);
            watch.Stop();
            //HtmlToPdf.ConvertUrl("D:\\HtmlContentForPdf.html", "D:\\result.pdf");        
            byte[] bPDFBytes = ms.ToArray();
            var timeTakenToConvert = watch.ElapsedMilliseconds;
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "application/pdf");
            response.AddHeader("Content-Disposition", "attachment; filename=Eo_" + fileName + "_" + timeTakenToConvert + ".pdf; size=" + bPDFBytes.Length.ToString());
            response.Flush();
            response.BinaryWrite(bPDFBytes);
            response.Flush();
            response.End();
        }
    }
}