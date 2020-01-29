using EvoPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvoPdfConverterEx
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
            htmlToPdfConverter.HtmlViewerWidth = 100;

            // Set HTML viewer height in pixels to convert the top part of a HTML page 
            // Leave it not set to convert the entire HTML

            htmlToPdfConverter.HtmlViewerHeight = 100;

            // Set PDF page size which can be a predefined size like A4 or a custom size in points 
            // Leave it not set to have a default A4 PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;

            // Set PDF page orientation to Portrait or Landscape
            // Leave it not set to have a default Portrait orientation for PDF page
            htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;

            // Set the maximum time in seconds to wait for HTML page to be loaded 
            // Leave it not set for a default 60 seconds maximum wait time
            htmlToPdfConverter.NavigationTimeout = 30;

            // Set an adddional delay in seconds to wait for JavaScript or AJAX calls after page load completed
            // Set this property to 0 if you don't need to wait for such asynchcronous operations to finish

            htmlToPdfConverter.ConversionDelay = 30;

            // The buffer to receive the generated PDF document
            byte[] outPdfBuffer = null;
            string htmlContent = File.ReadAllText(@"D:\Full_report_html.txt");
            //if (convertUrlRadioButton.Checked)
            //{
            //    string url = urlTextBox.Text;

            //    // Convert the HTML page given by an URL to a PDF document in a memory buffer
            //    outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);
            //}
            //else
            //{


            string htmlString = htmlContent;
            string baseUrl = "";// baseUrlTextBox.Text;

            // Convert a HTML string with a base URL to a PDF document in a memory buffer
            var watch = System.Diagnostics.Stopwatch.StartNew();
            outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlString, baseUrl);
            watch.Stop();
            var timeTakenToConvert = watch.ElapsedMilliseconds;
            //  }

            // Send the PDF as response to browser

            // Set response content type
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "application/pdf");
            response.AddHeader("Content-Disposition", "attachment; filename=" + timeTakenToConvert + ".pdf; size=" + outPdfBuffer.Length.ToString());
            response.Flush();
            response.BinaryWrite(outPdfBuffer);
            response.Flush();
            response.End();
        }
    }
}