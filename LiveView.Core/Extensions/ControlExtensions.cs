using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Core.Extensions
{
    public static class ControlExtensions
    {
        public static void SetOsdText(this Control control, string familyName, float emSize, FontStyle fontStyle, Color foreColor, string text)
        {
            control.Font = new Font(familyName, emSize, fontStyle);
            control.ForeColor = foreColor;
            control.Text = text;
        }

        public static void SetImage(this Control control, Image image, bool useClone)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((Action)(() =>
                {
                    InternalSetImage(control, image, useClone);
                }));
            }
            else
            {
                InternalSetImage(control, image, useClone);
            }
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
