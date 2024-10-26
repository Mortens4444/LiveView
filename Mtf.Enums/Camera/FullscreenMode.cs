using System.ComponentModel;

namespace Mtf.Enums.Camera
{
    public enum FullscreenMode : byte
    {
        [Description("Default")]
        Default,
        [Description("High resolution")]
        HighResolution,
        [Description("Live mode")]
        LiveMode,
        [Description("JPEG")]
        JPEG,
        [Description("MJPEG")]
        MJPEG,
        [Description("Sunell")]
        Sunell,
        [Description("Pelco")]
        Pelco,
    }
}
