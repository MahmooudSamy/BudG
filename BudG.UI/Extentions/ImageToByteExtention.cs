using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace BudG.UI.Extentions
{
    public static class ImageToByteExtention
    {
        public static byte[] getJPGFromImageControl(this BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
           

            if (imageC == null)
            {
                imageC = new BitmapImage(new Uri("pack://application:,,,/BudG.UI;component/Images/SplashScreen1.jpg"));
            }


            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
    }
}
