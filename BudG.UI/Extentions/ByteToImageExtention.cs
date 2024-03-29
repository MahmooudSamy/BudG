using System.IO;
using System.Windows.Media.Imaging;

namespace BudG.UI.Extentions
{
    public static class ByteToImageExtention
    {
        public static BitmapImage ToImage(this byte[] array)
        {
            var image = new BitmapImage();

            using (var ms = new MemoryStream(array))
            {

                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;

            }


        }
    }
}
