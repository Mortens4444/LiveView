using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZXing;
using ZXing.Common;

namespace LiveView.Services
{
    public static class CodeCrafter
    {
        public static Image CreateQuickResponseCode(string text)
        {
            var options = new EncodingOptions
            {
                Height = 250,
                Width = 250,
                Margin = 1
            };
            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };

            var pixelData = writer.Write(text);
            var bmp = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppArgb);
            var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            try
            {
                Marshal.Copy(pixelData.Pixels, 0, bmpData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                bmp.UnlockBits(bmpData);
            }

            return bmp;
        }
    }
}
