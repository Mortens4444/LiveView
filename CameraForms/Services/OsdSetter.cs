using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Services;
using Mtf.Controls.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public static class OsdSetter
    {
        public static void SetInfo(Form form, IVideoWindow videoWindow, GridCamera gridCamera, IPersonalOptionsRepository personalOptionsRepository, string text, long userId)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (videoWindow == null)
            {
                throw new ArgumentNullException(nameof(videoWindow));
            }

            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            var fontName = personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial");
            videoWindow.OverlayFont = new Font(fontName, largeFontSize, FontStyle.Bold);
            var fontColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()));
            //var shadowColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));
            videoWindow.OverlayBrush = new SolidBrush(fontColor);

            if (gridCamera == null)
            {
                return;
            }

            if (gridCamera.Frame)
            {
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.Text = text;
            }
            else
            {
                if (gridCamera.Osd)
                {
                    videoWindow.OverlayText = text;
                }
            }
            if (gridCamera.ShowDateTime)
            {
                videoWindow.OverlayText += DateUtils.GetNowFriendlyString();
            }
        }
    }
}
