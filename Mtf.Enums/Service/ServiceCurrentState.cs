using System;

namespace Mtf.Enums.Service
{
    [Flags]
    public enum ServiceCurrentState : uint
    {
        SERVICE_CONTINUE_PENDING = 0x5,
        SERVICE_PAUSE_PENDING = 0x6,
        SERVICE_PAUSED = 0x7,
        SERVICE_RUNNING = 0x4,
        SERVICE_START_PENDING = 0x2,
        SERVICE_STOP_PENDING = 0x3,
        SERVICE_STOPPED = 0x1
    }
}
