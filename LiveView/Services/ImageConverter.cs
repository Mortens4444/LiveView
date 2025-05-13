using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LiveView.Services
{
    public static class ImageConverter
    {
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }

            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public static byte[] ImageToByteArray(Image image, ImageFormat format = null)
        {
            if (image == null)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                using (var clonedImage = (Image)image.Clone())
                {
                    try
                    {
                        clonedImage.Save(ms, format ?? clonedImage.RawFormat);
                    }
                    catch
                    {
                        clonedImage.Save(ms, ImageFormat.Png);
                    }
                    return ms.ToArray();
                }
            }
        }
    }
}
