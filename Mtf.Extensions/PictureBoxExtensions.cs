using Mtf.MessageBoxes;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.Extensions
{
    public static class PictureBoxExtensions
    {
        public static void InvokeAction(this PictureBox pictureBox, Action action)
        {
            try
            {
                if (pictureBox != null && pictureBox.IsHandleCreated)
                {
                    pictureBox.Invoke(action);
                }
            }
            catch (ObjectDisposedException) { }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        public static void ThreadSafeSetImageWithCloning(this PictureBox pictureBox, Bitmap bitmap, object sync)
        {
            try
            {
                var image = (Image)bitmap?.Clone();
                pictureBox.ThreadSafeSetImage(image, sync);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        public static void ThreadSafeSetImage(this PictureBox pictureBox, Image image, object sync)
        {
            lock (sync)
            {
                try
                {
                    pictureBox.SetImage(image);
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
        }

        public static void ThreadSafeClearImage(this PictureBox pictureBox, object sync)
        {
            lock (sync)
            {
                try
                {
                    pictureBox.SetImage(null);
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
        }

        public static void SetImage(this PictureBox pictureBox, Image image)
        {
            if (pictureBox != null)
            {
                pictureBox.Image?.Dispose();
                pictureBox.Image = image;
            }
        }

        public static void ClearImage(this PictureBox pictureBox)
        {
            pictureBox.SetImage(null);
        }
    }
}
