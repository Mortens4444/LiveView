using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Core.Extensions
{
    public static class ControlExtensions
    {
        public static void SetOsdText(this Control control, string familyName, float emSize, FontStyle fontStyle, Color foreColor, string text)
        {
            control.Font?.Dispose();
            control.Font = new Font(familyName, emSize, fontStyle);
            control.ForeColor = foreColor;
            control.Text = text;
        }

        public static void SetImage(this Control control, Image image, bool useClone)
        {
            control.Invoke((Action)(() =>
            {
                Image oldImage;
                if (control is PictureBox pictureBox)
                {
                    oldImage = pictureBox.Image;
                    pictureBox.Image = useClone ? (Image)image.Clone() : image;
                    SetTextOnImage(control, pictureBox.Image, Color.Gray, 2);
                }
                else
                {
                    oldImage = control.BackgroundImage;
                    control.BackgroundImage = useClone ? (Image)image.Clone() : image;
                    SetTextOnImage(control, control.BackgroundImage, Color.Gray, 2);
                }
                
                oldImage?.Dispose();
            }));
        }

        private static void SetTextOnImage(Control control, Image image, Color shadowColor, int shadowOffset)
        {
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
