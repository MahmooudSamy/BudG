using BudG.UI.Extentions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BudG.UI.Converters
{
    public class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageByteArray = value as byte[];
            BitmapImage imageC = null ;
            if (imageByteArray == null)
            {
                 imageC = new BitmapImage(new Uri(parameter.ToString(), UriKind.Relative));

                return imageC;

            }
            return imageC = imageByteArray.ToImage();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageByteArray = value as BitmapImage;
            return imageByteArray.getJPGFromImageControl();
        }
       

       
    }
}
