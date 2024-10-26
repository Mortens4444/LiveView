using System;

namespace Mtf.Enums.Avi
{
    [Flags]
    public enum AviCompressionOptions : uint
    {
        ICMF_CHOOSE_KEYFRAME = 0x00000001,
        ICMF_CHOOSE_DATARATE = 0x00000002,
        ICMF_CHOOSE_PREVIEW = 0x00000004,
        ICMF_CHOOSE_ALLCOMPRESSORS = 0x00000008,
    }
}
