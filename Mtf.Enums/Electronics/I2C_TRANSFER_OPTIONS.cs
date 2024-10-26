using System;

namespace Mtf.Enums.Electronics
{
    [Flags]
    public enum I2C_TRANSFER_OPTIONS : uint
    {
        START_BIT = 1,
        STOP_BIT = 2,
        BREAK_ON_NACK = 4,
        FAST_TRANSFER_BYTES = 16,
        FAST_TRANSFER_BITS = 32,
        NO_ADDRESS = 64
    }
}
