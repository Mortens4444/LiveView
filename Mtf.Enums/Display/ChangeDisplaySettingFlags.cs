using System;

namespace Mtf.Enums.Display
{
    [Flags]
    public enum ChangeDisplaySettingFlags
    {
        /// <summary>
        /// The graphics mode for the current screen will be changed dynamically.
        /// </summary>
        AUTO = 0,
        /// <summary>
        /// The mode is temporary in nature. If you change to and from another desktop, this mode will not be reset.
        /// </summary>
        CDS_FULLSCREEN = 4,
        /// <summary>
        /// The settings will be saved in the global settings area so that they will affect all users on the machine. Otherwise, only the settings for the user are modified. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
        /// </summary>
        CDS_GLOBAL = 8,
        /// <summary>
        /// The settings will be saved in the registry, but will not take effect. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
        /// </summary>
        CDS_NORESET = 0x10000000,
        /// <summary>
        /// The settings should be changed, even if the requested settings are the same as the current settings.
        /// </summary>
        CDS_RESET = 0x40000000,
        /// <summary>
        /// This device will become the primary device.
        /// </summary>
        CDS_SET_PRIMARY = 16,
        /// <summary>
        /// The system tests if the requested graphics mode could be set.
        /// </summary>
        CDS_TEST = 2,
        /// <summary>
        /// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry. The mode information is stored in the USER profile.
        /// </summary>
        CDS_UPDATEREGISTRY = 1
    }

}
