using System;

namespace Mtf.Enums.Avi
{
    [Flags]
    public enum AviStreamFlags : uint
    {
        AVISTREAMINFO_DISABLED = 0x00000001,
        AVISTREAMINFO_FORMATCHANGES = 0x00010000
    }
}
