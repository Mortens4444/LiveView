using System;

namespace LiveView.Core.Enums.Keyboard
{
    [Flags]
    public enum ModifierKeys : uint
    {
        NO_MODIFIER = 0,
        MOD_ALT = 1,
        MOD_CONTROL = 2,
        MOD_SHIFT = 4,
        MOD_WIN = 8,
    }
}
