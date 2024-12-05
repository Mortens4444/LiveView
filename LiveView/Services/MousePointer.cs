using Microsoft.Win32;
using System;

namespace LiveView.Services
{
    public static class MousePointer
    {
        // Reboot needed
        public static void ShowOnCtrlKey()
        {
            const string registryPath = @"HKEY_CURRENT_USER\Control Panel\Desktop";
            const string valueName = "UserPreferencesMask";

            var currentValue = (byte[])Registry.GetValue(registryPath, valueName, null);
            if (currentValue is null || currentValue.Length < 4)
            {
                throw new InvalidOperationException("Failed to retrieve the UserPreferencesMask value.");
            }

            currentValue[1] |= 0x40;
            Registry.SetValue(registryPath, valueName, currentValue, RegistryValueKind.Binary);
        }
    }
}
