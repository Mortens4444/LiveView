using LiveView.Core.Services;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Extensions
{
    public static class FormExtensions
    {
        public static void SetFormSizeAndPosition(this Form form, Rectangle rectangle)
        {
            form.Location = new Point(rectangle.X, rectangle.Y);
            if (AppConfig.GetBoolean(LiveView.Core.Constants.UseMiniSizeForFullscreenWindows))
            {
                var miniFullscreenWindowWidth = AppConfig.GetInt32(LiveView.Core.Constants.MiniFullscreenWindowWidth, 100);
                var miniFullscreenWindowHeight = AppConfig.GetInt32(LiveView.Core.Constants.MiniFullscreenWindowHeight, 100);
                form.Size = new Size(miniFullscreenWindowWidth, miniFullscreenWindowHeight);
            }
            else
            {
                form.Size = new Size(rectangle.Width, rectangle.Height);
            }
        }
    }
}
