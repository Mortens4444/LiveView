namespace Mtf.Enums.Keyboard
{
    public enum KeyboardEventFlags : uint
    {
        NOTHING = 0x0000,
        KEYEVENTF_EXTENDEDKEY = 0x0001,
        KEYEVENTF_KEYUP = 0x0002,
        KEYEVENTF_EXTENDEDKEY_AND_KEYUP = 0x0003
    }
}
