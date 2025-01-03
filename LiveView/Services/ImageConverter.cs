using System.Collections;
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

        public static byte[] ImageToByteArray(Image image, ImageFormat format)
        {
            if (image == null)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}
