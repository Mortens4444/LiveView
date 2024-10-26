namespace Mtf.Enums.Service
{
    public enum SC_ACTION_TYPE
    {
        /// <summary>
        /// No action.
        /// </summary>
        SC_ACTION_NONE = 0,

        /// <summary>
        /// Restart the service.
        /// </summary>
        SC_ACTION_RESTART = 1,

        /// <summary>
        /// Reboot the computer.
        /// </summary>
        SC_ACTION_REBOOT = 2,

        /// <summary>
        /// Run a command.
        /// </summary>
        SC_ACTION_RUN_COMMAND = 3
    }
}
