using Mtf.Extensions.Attributes;

namespace Database.Enums
{
    public enum CameraMode
    {
        AxVideoPlayer = 0,
        
        VideoSource = 1,
        
        Vlc = 2,
        
        FFMpeg = 3,

        OpenCvSharp = 4,

        OpenCvSharp4 = 5,
        
        SunellLegacyCamera = 6,
        
        SunellCamera = 7,

        MortoGraphy = 8,

        [Disabled]
        Chromium = 9,

#if NETFRAMEWORK

        [Disabled]
        AccordJpeg = 10,

        [Disabled]
        AccordMjpeg = 11,

        [Disabled]
        AccordScreenCapture = 12,

        [Disabled]
        AForgeJpeg = 13,

        [Disabled]
        AForgeMjpeg = 14,

        [Disabled]
        AForgeScreenCapture = 15,

        [Disabled]
        AForgeVideoSource = 16

#endif
    }
}
