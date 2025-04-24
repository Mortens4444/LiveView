using CameraForms.Enums;
using Database.Enums;
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
    }
}
