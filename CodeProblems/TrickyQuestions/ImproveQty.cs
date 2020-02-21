using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
   public class ImproveQty
    {
       //public static void Main1(string[] args)
       //{
       //    string input = "OneTwoThree";

       //    // Get first three characters
       //    string sub = input.Substring(0, 3);
       //    Console.WriteLine("Substring: {0}", sub);
       //    var image = Image.FromFile(@"E:\UoaData\AppData\WebData\CSAOverallSummeryGraphs\IronVsBn\View\a5101a21-a2da-4489-9d12-245ad6f25449.png");
       //    var scaled = ScaleDownToKb(image, 700, 20);
       //    SaveJpeg(scaled, @"E:\UoaData\AppData\WebData\CSAOverallSummeryGraphs\IronVsBn\View\81.png", 250);
       //}

        //Scale down the image till it fits the given file size.
        //public static Image ScaleDownToKb(Image img, long targetKilobytes, long quality)
        //{
        //    //DateTime start = DateTime.Now;
        //    //DateTime end;

        //    float h, w;
        //    float halfFactor = 100; // halves itself each iteration
        //    float testPerc = 100;
        //    var direction = -1;
        //    long lastSize = 0;
        //    var iteration = 0;
        //    var origH = img.Height;
        //    var origW = img.Width;

        //    // if already below target, just return the image
        //    var size = GetImageFileSizeBytes(img, 7500000, quality);
        //    if (size < targetKilobytes * 1024)
        //    {
        //        //end = DateTime.Now;
        //        //Console.WriteLine("================ DONE.  ITERATIONS: " + iteration + " " + end.Subtract(start));
        //        return img;
        //    }

        //    while (true)
        //    {
        //        iteration++; 

        //        halfFactor /= 2;
        //        testPerc += halfFactor * direction;

        //        h = origH * testPerc / 100;
        //        w = origW * testPerc / 100;

        //        var test = ScaleImage(img, (int)w, (int)h);
        //        size = GetImageFileSizeBytes(test, 50000, quality);

        //        var byteTarg = targetKilobytes * 1024;
        //        //Console.WriteLine(iteration + ": " + halfFactor + "% (" + testPerc + ") " + size + " " + byteTarg);

        //        if ((Math.Abs(byteTarg - size) / (double)byteTarg) < .1 || size == lastSize || iteration > 15 /* safety measure */)
        //        {
        //            //end = DateTime.Now;
        //            //Console.WriteLine("================ DONE.  ITERATIONS: " + iteration + " " + end.Subtract(start));
        //            return test;
        //        }

        //        if (size > targetKilobytes * 1024)
        //        {
        //            direction = -1;
        //        }
        //        else
        //        {
        //            direction = 1;
        //        }

        //        lastSize = size;
        //    }
        //}

        //public static long GetImageFileSizeBytes(Image image, int estimatedSize, long quality)
        //{
        //    long jpegByteSize;
        //    using (var ms = new MemoryStream(estimatedSize))
        //    {
        //        SaveJpeg(image, ms, quality);
        //        jpegByteSize = ms.Length;
        //    }
        //    return jpegByteSize;
        //}

        //public static void SaveJpeg(Image image, MemoryStream ms, long quality)
        //{
        //    ((Bitmap)image).Save(ms, FindEncoder(ImageFormat.Png), GetEncoderParams(quality));
        //}

        //public static void SaveJpeg(Image image, string filename, long quality)
        //{
        //    ((Bitmap)image).Save(filename, FindEncoder(ImageFormat.Png), GetEncoderParams(quality));
        //}

        //public static ImageCodecInfo FindEncoder(ImageFormat format)
        //{

        //    if (format == null)
        //        throw new ArgumentNullException("format");

        //    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
        //    {
        //        if (codec.FormatID.Equals(format.Guid))
        //        {
        //            return codec;
        //        }
        //    }

        //    return null;
        //}

        //public static EncoderParameters GetEncoderParams(long quality)
        //{
        //    System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
        //    //Encoder encoder = new Encoder(ImageFormat.Jpeg.Guid);
        //    EncoderParameters eparams = new EncoderParameters(1);
        //    EncoderParameter eparam = new EncoderParameter(encoder, quality);
        //    eparams.Param[0] = eparam;
        //    return eparams;
        //}

        ////Scale an image to a given width and height.
        //public static Image ScaleImage(Image img, int outW, int outH)
        //{
        //    Bitmap outImg = new Bitmap(outW, outH, img.PixelFormat);
        //    outImg.SetResolution(img.HorizontalResolution, img.VerticalResolution);
        //    Graphics graphics = Graphics.FromImage(outImg);
        //    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    graphics.DrawImage(img, new Rectangle(0, 0, outW, outH), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
        //    graphics.Dispose();

        //    return outImg;
        //}
    }


}
