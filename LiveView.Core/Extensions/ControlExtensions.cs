using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Core.Extensions
{
    public static class ControlExtensions
    {
        public static void SetImage(this Control control, Image image, bool useClone)
        {
            control.Invoke((Action)(() =>
            {
                Image oldImage;
                if (control is PictureBox pictureBox)
                {
                    oldImage = pictureBox.Image;
                    pictureBox.Image = useClone ? (Image)image.Clone() : image;
                }
                else
                {
                    oldImage = control.BackgroundImage;
                    control.BackgroundImage = useClone ? (Image)image.Clone() : image;
                }
                
                oldImage?.Dispose();
            }));
        }
    }
}
