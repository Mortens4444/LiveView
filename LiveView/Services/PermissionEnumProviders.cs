using Mtf.Permissions.Enums;
using System;
using System.Collections.Generic;

namespace LiveView.Services
{
    public static class PermissionEnumProviders
    {
        public static List<Type> Get()
        {
            return new List<Type>
                {
                    typeof(ApplicationManagementPermissions),
                    typeof(CameraManagementPermissions),
                    typeof(DatabaseServerManagementPermissions),
                    typeof(DisplayManagementPermissions),
                    typeof(EventManagementPermissions),
                    typeof(GeneralPermissions),
                    typeof(GridManagementPermissions),
                    typeof(GroupManagementPermissions),
                    typeof(HardwareManagementPermissions),
                    typeof(IODeviceManagementPermissions),
                    typeof(JoystickManagementPermissions),
                    typeof(LanguageManagementPermissions),
                    typeof(LogManagementPermissions),
                    typeof(MapManagementPermissions),
                    typeof(NetworkManagementPermissions),
                    typeof(PasswordManagementPermissions),
                    typeof(PermissionManagementPermissions),
                    typeof(SequenceManagementPermissions),
                    typeof(SerialDeviceManagementPermissions),
                    typeof(ServerManagementPermissions),
                    typeof(SettingsManagementPermissions),
                    typeof(TemplateManagementPermissions),
                    typeof(UserManagementPermissions),
                    typeof(WindowManagementPermissions)
                };
        }
    }
}
