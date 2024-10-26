namespace Mtf.Enums.Window
{
    public enum nCmdShow : int
    {
        /// <summary>Minimizes a window, even if the thread that owns the window is not responding.
        /// This flag should only be used when minimizing windows from different thread.</summary>
        /// <remarks>SW_FORCEMINIMIZE</remarks>
        SW_FORCEMINIMIZE = 11,

        /// <summary>Hides this window and activates another window.</summary>
        /// <remarks>SW_HIDE</remarks>
        SW_HIDE = 0,

        /// <summary>Maximizes the specified window.</summary>
        /// <remarks>SW_MAXIMIZE</remarks>
        SW_MAXIMIZE = 3,

        /// <summary>Minimizes the specified window and activates the top-level window in the system's list (Z order).</summary>
        /// <remarks>SW_MINIMIZE</remarks>
        SW_MINIMIZE = 6,

        /// <summary>Activates and displays the window. If the window is minimized or maximized, Windows restores it to its original size and position.</summary>
        /// <remarks>SW_RESTORE</remarks>
        SW_RESTORE = 9,

        /// <summary>Activates the window and displays it in its current size and position.</summary>
        /// <remarks>SW_SHOW</remarks>
        SW_SHOW = 5,

        /// <summary>Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.</summary>
        /// <remarks>SW_SHOWDEFAULT</remarks>
        SW_SHOWDEFAULT = 10,

        /// <summary>Activates the window and displays it as a maximized window.</summary>
        /// <remarks>SW_SHOWMAXIMIZED</remarks>
        SW_SHOWMAXIMIZED = 3,

        /// <summary>Activates the window and displays it as a minimized window.</summary>
        /// <remarks>SW_SHOWMINIMIZED</remarks>
        SW_SHOWMINIMIZED = 2,

        /// <summary>Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.</summary>
        /// <remarks>SW_SHOWMINNOACTIVE</remarks>
        SW_SHOWMINNOACTIVE = 7,

        /// <summary>Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.</summary>
        /// <remarks>SW_SHOWNA</remarks>
        SW_SHOWNA = 8,

        /// <summary>Displays the window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except the window is not activated.</summary>
        /// <remarks>SW_SHOWNOACTIVATE</remarks>
        SW_SHOWNOACTIVATE = 4,

        /// <summary>Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window for the first time.</summary>
        /// <remarks>SW_SHOWNORMAL</remarks>
        SW_SHOWNORMAL = 1,
    }
}
