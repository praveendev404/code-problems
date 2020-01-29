using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ConsoleDemo
{
    class ImproveImagequality
    {
      public static  void GenerateThumbnails(double scaleFactor, Stream sourcePath)
        {
            using (var image = Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth*2, newHeight*2);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                string appPath = "/CSAOverallSummeryGraphs/IronVsBn/Publish/" + "IrAndMcr" + DateTime.Now.ToString();
                thumbnailImg.Save(@"E:\UoaData\AppData\WebData\CSAOverallSummeryGraphs\IronVsBn\View\89.png", image.RawFormat);
            }
        }

        static void Main(string[] args)
        {
            var image = Image.FromFile(@"E:\UoaData\AppData\WebData\CSAOverallSummeryGraphs\IronVsBn\View\a5101a21-a2da-4489-9d12-245ad6f25449.png");
            var stream = new System.IO.MemoryStream();
            image.Save(stream, ImageFormat.Png);
            stream.Position = 0;
            GenerateThumbnails(0.5, stream);
        }
    }
}
