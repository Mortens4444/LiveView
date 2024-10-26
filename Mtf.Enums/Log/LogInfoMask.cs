using System;

namespace Mtf.Enums.Log
{
    [Flags]
    public enum LogInfoMask
    {
        DefaultValue = 0,
        EventTime = 1,
        Message = 2,
        OtherInformation = 4,
        LogSeverity = 8,
        StatusCode = 16,
        Computer = 32,
        Logger = 64,
        Checksum = 128,
        EventLogEntry_WrittenTime = 256,
        EventLogEntry_Message = 512,
    }
}
