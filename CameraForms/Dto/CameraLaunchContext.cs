using CameraForms.Enums;
using CameraForms.Services;
using Database.Enums;
using LiveView.Core.Dto;
using Mtf.LanguageService;
using System;
using System.Drawing;

namespace CameraForms.Dto
{
    public class CameraLaunchContext
    {
        public long? AgentId { get; set; }

        public long UserId { get; set; }

        public long CameraId { get; set; }

        public string ServerIp { get; set; }

        public string VideoCaptureSource { get; set; }

        public long? DisplayId { get; set; }

        public Rectangle Rectangle { get; set; } = Rectangle.Empty;

        public CameraMode CameraMode { get; set; }

        public StartType StartType { get; set; }

        public DisplayDto GetDisplay()
        {
            if (Rectangle != Rectangle.Empty)
            {
                return null;
            }

            var result = DisplayProvider.Get(DisplayId);
            if (!result.CanShowFullscreen)
            {
                throw new InvalidOperationException(Lng.FormattedElem("This display '{0}' is forbidden to show full screen camera windows.", args: result.Id));
            }
            return result;
        }
    }
}
