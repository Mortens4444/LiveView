using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Extensions
{
    public static class FormExtensions
    {
        public static void SetFormSizeAndPosition(this Form form, Rectangle rectangle)
        {
            form.Location = new Point(rectangle.X, rectangle.Y);
            if (Boolean.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.UseMiniSizeForFullscreenWindows], out var useMiniWindowattach) && useMiniWindowattach)
            {
                int miniFullscreenWindowWidth;
                if (!Int32.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.MiniFullscreenWindowWidth], out miniFullscreenWindowWidth))
                {
                    miniFullscreenWindowWidth = 100;
                }
                int miniFullscreenWindowHeight;
                if (!Int32.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.MiniFullscreenWindowHeight], out miniFullscreenWindowHeight))
                {
                    miniFullscreenWindowHeight = 100;
                }
                form.Size = new Size(miniFullscreenWindowWidth, miniFullscreenWindowHeight);
            }
            else
            {
                form.Size = new Size(rectangle.Width, rectangle.Height);
            }
        }
    }
}
