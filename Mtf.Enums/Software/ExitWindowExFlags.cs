namespace Mtf.Enums.Software
{
    public enum ExitWindowExFlags : int
    {
        /// <summary>
        /// Log out
        /// </summary>
        LOGOUT = 0,
        /// <summary>
        /// Log out, and force terminate processes
        /// </summary>
        LOGOUT_FORCE_TERMINATE_PROCESSES = 4,
        /// <summary>
        /// Shuts down the system and turns off the power. Note: This flag is not supported on a Windows Mobile-based Pocket PC.
        /// </summary>
        EWX_POWEROFF = 1,
        /// <summary>
        /// Shuts down the system and reboots.
        /// </summary>
        EWX_REBOOT = 2
    }
}
