using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class BarCodeGenerator
    {
        static void Main(string[] args)
        {
            string prodCode = "123456";
            //context.Response.ContentType = "image/gif";
            if (prodCode.Length > 0)
            {


                Barcode128 code128 = new Barcode128();
                code128.CodeType = Barcode.CODE128;
                code128.ChecksumText = true;
                code128.GenerateChecksum = true;
                code128.Code = prodCode;
                code128.AltText = prodCode;
                code128.GenerateChecksum = true;
        


                System.Drawing.Bitmap bm = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
                bm.Save(@"E:\Praveen\Barcodes\"+Guid.NewGuid()+".png");
            }


        }
    }
}
