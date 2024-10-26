using System;

namespace Mtf.Enums.Avi
{
    [Flags]
    public enum AviFileOpenMode : uint
    {
        OF_CREATE = 0x00001000,
        OF_PARSE = 0x00000100,
        OF_READ = 0x00000000,
        OF_READWRITE = 0x00000002,
        OF_SHARE_DENY_NONE = 0x00000040,
        OF_SHARE_DENY_READ = 0x00000030,
        OF_SHARE_DENY_WRITE = 0x00000020,
        OF_SHARE_EXCLUSIVE = 0x00000010,
        OF_WRITE = 0x00000001
    }
}
