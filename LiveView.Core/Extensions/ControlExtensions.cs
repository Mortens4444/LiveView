using Mtf.MessageBoxes;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Core.Extensions
{
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control == null || control.IsDisposed || !control.IsHandleCreated)
            {
                return;
            }

            try
            {
                if (control.InvokeRequired)
                {
                    control.InvokeAsync(action);
                }
                else
                {
                    action();
                }
            }
            catch (InvalidOperationException ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        public static void SafeDispose(this Control control)
        {
            if (control != null && !control.IsDisposed)
            {
                control.Parent?.Controls.Remove(control);
                control.BeginInvoke((Action)(() =>
                {
                    control.Dispose();
                }));
            }
        }

        public static Task InvokeAsync(this Control control, Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            if (control.IsDisposed)
            {
                tcs.SetCanceled();
                return tcs.Task;
            }

            control.BeginInvoke(new MethodInvoker(() =>
            {
                try
                {
                    if (!control.IsDisposed)
                    {
                        action();
                        tcs.SetResult(null);
                    }
                    else
                    {
                        tcs.SetCanceled();
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }));
            return tcs.Task;
        }

        public static void SetOsdText(this Control control, string familyName, float emSize, FontStyle fontStyle, Color foreColor, string text)
        {
            control.Font = new Font(familyName, emSize, fontStyle);
            control.ForeColor = foreColor;
            control.Text = text;
        }

        public static void SetImage(this Control control, Image image, bool useClone)
        {
            control.InvokeIfRequired(() =>
            {
                InternalSetImage(control, image, useClone);
            });
        }

        private static void InternalSetImage(Control control, Image image, bool useClone)
        {
            Image oldImage;
            var newImage = useClone ? (Image)image.Clone() : image;
            if (control is PictureBox pictureBox)
            {
                oldImage = pictureBox.Image;
                pictureBox.Image = newImage;
                SetTextOnImage(control, pictureBox.Image);
            }
            else
            {
                oldImage = control.BackgroundImage;
                control.BackgroundImage = newImage;
                SetTextOnImage(control, control.BackgroundImage);
            }
            control.Invalidate();
            control.Update();
            if (oldImage != null && !ReferenceEquals(oldImage, image))
            {
                oldImage.Dispose();
            }
        }

        private static void SetTextOnImage(Control control, Image image)
        {
            SetTextOnImage(control, image, Color.DarkGray, 2);
        }

        private static void SetTextOnImage(Control control, Image image, Color shadowColor, int shadowOffset)
        {
            if (String.IsNullOrEmpty(control.Text))
            {
                return;
            }

            using (var g = Graphics.FromImage(image))
            {
                var textLocation = new PointF(10, 10);
                using (var shadowBrush = new SolidBrush(shadowColor))
                {
                    var shadowLocation = new PointF(textLocation.X + shadowOffset, textLocation.Y + shadowOffset);
                    g.DrawString(control.Text, control.Font, shadowBrush, shadowLocation);
                }

                using (var brush = new SolidBrush(control.ForeColor))
                {
                    g.DrawString(control.Text, control.Font, brush, textLocation);
                }
                control.Refresh();
            }
        }
    }
}
