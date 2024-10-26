using System;

namespace Mtf.Enums.Electronics
{
    [Flags]
    public enum CHANNELCONFIG_OPTIONS : uint
    {
        I2C_DISABLE_3PHASE_CLOCKING = 1,
        I2C_ENABLE_DRIVE_ONLY_ZERO = 2
    }
}
