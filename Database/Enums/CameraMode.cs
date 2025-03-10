using Database.Attributes;

namespace Database.Enums
{
    public enum CameraMode
    {
        AxVideoPlayer = 0,
        VideoSource = 1,
        Vlc = 2,
        FFMpeg = 3,

        [Disabled]
        OpenCvSharp = 4,

        OpenCvSharp4 = 5,
        SunellLegacyCamera = 6,
        SunellCamera = 7,
        MortoGraphy = 8,
    }
}
