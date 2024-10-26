using System;

namespace Mtf.Enums
{
    [Flags]
    public enum EventFlags : uint
    {
        CREATE_EVENT_INITIAL_SET = 2,
        CREATE_EVENT_MANUAL_RESET = 1,
        NOTHING = 0,
    }
}
