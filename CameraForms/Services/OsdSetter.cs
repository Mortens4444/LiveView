using CameraForms.Dto;
using Database.Models;
using LiveView.Core.Services;
using Mtf.Controls.Interfaces;
using System;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public static class OsdSetter
    {
        public static void SetInfo(Form form, IVideoWindow videoWindow, GridCamera gridCamera, OsdSettings osdSettings, string text)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (videoWindow == null)
            {
                throw new ArgumentNullException(nameof(videoWindow));
            }

            if (gridCamera == null)
            {
                return;
            }

            if (osdSettings != null)
            {
                videoWindow.OverlayFont = osdSettings.OverlayFont;
                videoWindow.OverlayBrush = osdSettings.FontBrush;
            }

            if (gridCamera.Frame)
            {
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.Text = text;
            }
            else
            {
                videoWindow.OverlayText = gridCamera.Osd ? text : String.Empty;
            }
            if (gridCamera.ShowDateTime)
            {
                videoWindow.OverlayText += DateUtils.GetNowFriendlyString();
            }
        }
    }
}
