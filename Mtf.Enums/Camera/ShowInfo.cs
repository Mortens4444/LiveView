using System;

namespace Mtf.Enums.Camera
{
    [Flags]
    public enum ShowInfo : byte
    {
        None = 0,
        CameraName = 1,
        DateTime = 2,
        CameraNameAndDateTime = CameraName | DateTime
    }
}
