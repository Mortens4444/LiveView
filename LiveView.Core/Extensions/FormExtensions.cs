using Database;
using Database.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Core.Extensions
{
    public static class FormExtensions
    {
        public static void SetFormRegion(this Form form, Rectangle rectangle)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            form.Location = new Point(rectangle.X, rectangle.Y);
            if (AppConfig.GetBoolean(Constants.UseMiniSizeForFullscreenWindows))
            {
                var miniFullscreenWindowWidth = AppConfig.GetInt32(Constants.MiniFullscreenWindowWidth, 100);
                var miniFullscreenWindowHeight = AppConfig.GetInt32(Constants.MiniFullscreenWindowHeight, 100);
                form.Size = new Size(miniFullscreenWindowWidth, miniFullscreenWindowHeight);
            }
            else
            {
                form.Size = new Size(rectangle.Width, rectangle.Height);
            }
        }
    }
}
