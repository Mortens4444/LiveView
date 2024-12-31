namespace LiveView.Core.Enums.Display
{
    public enum EDSModeNum : uint
    {
        ENUM_CURRENT_SETTINGS = unchecked((uint)-1), //(DWORD) -1 = 0xFFFFFFFF
        ENUM_REGISTRY_SETTINGS = unchecked((uint)-2) //(DWORD)-2 = 0xFFFFFFFE
    }
}
