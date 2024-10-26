namespace Mtf.Enums.Window
{
    public enum WM_SYSCOMMAND_lParam : int
    {
        /// <summary>Closes the window.</summary>
        /// <remarks>SC_CLOSE</remarks>
        SC_CLOSE = 0xF060,

        /// <summary>Changes the cursor to a question mark with a pointer. If the user then clicks a cotorl in the dialog box, the control recives a WM_HELP message.</summary>
        /// <remarks>SC_CONTEXTHELP</remarks>
        SC_CONTEXTHELP = 0xF180,

        /// <summary>Selects the default item; the user double-clicked the window menu.</summary>
        /// <remarks>SC_DEFAULT</remarks>
        SC_DEFAULT = 0xF160,

        /// <summary>Activate the CWnd object associated with the application-specified hot key. The low-order word of lParam identifies the HWND of the window to activate.</summary>
        /// <remarks>SC_HOTKEY</remarks>
        SC_HOTKEY = 0xF150,

        /// <summary>Scroll horizontally.</summary>
        /// <remarks>SC_HSCROLL</remarks>
        SC_HSCROLL = 0xF080,

        /// <summary>Indicates whether the screen saver is secure.</summary>
        /// <remarks>SCF_ISSECURE</remarks>
        SCF_ISSECURE = 0x00000001,

        /// <summary>Retrieve a menu through a keystroke.</summary>
        /// <remarks>SC_KEYMENU</remarks>
        SC_KEYMENU = 0xF100,

        /// <summary>Maximize the CWnd object.</summary>
        /// <remarks>SC_MAXIMIZE (or SC_ZOOM)</remarks>
        SC_MAXIMIZE = 0xF030,

        /// <summary>Minimize the CWnd object.</summary>
        /// <remarks>SC_MINIMIZE (or SC_ICON)</remarks>
        SC_MINIMIZE = 0xF020,

        /// <summary>Sets the state of the display. This command supports devices that have power-saving features, such as a battery-powered personal computer.
        /// The lParam parameter can have the following values:
        ///		o -1 (the display is powering on)
        ///		o 1 (the display is going to low power)
        ///		o 2 (the display is being shut off)</summary>
        /// <remarks>SC_MONITORPOWER</remarks>
        SC_MONITORPOWER = 0xF170,

        /// <summary>Retrieve a window menu as a result of a mouse click.</summary>
        /// <remarks>SC_MOUSEMENU</remarks>
        SC_MOUSEMENU = 0xF090,

        /// <summary>Move the CWnd object.</summary>
        /// <remarks>SC_MOVE</remarks>
        SC_MOVE = 0xF010,

        /// <summary>Move to the next window.</summary>
        /// <remarks>SC_NEXTWINDOW</remarks>
        SC_NEXTWINDOW = 0xF040,

        /// <summary>Move to the previous window.</summary>
        /// <remarks>SC_PREVWINDOW</remarks>
        SC_PREVWINDOW = 0xF050,

        /// <summary>Restore window to normal position and size.</summary>
        /// <remarks>SC_RESTORE</remarks>
        SC_RESTORE = 0xF120,

        /// <summary>Executes the screen-saver application specified in the [boot] section of the SYSTEM.INI file.</summary>
        /// <remarks>SC_SCREENSAVE</remarks>
        SC_SCREENSAVE = 0xF140,

        /// <summary>Size the CWnd object.</summary>
        /// <remarks>SC_SIZE</remarks>
        SC_SIZE = 0xF000,

        /// <summary>Execute or activate the Windows Task Manager application.</summary>
        /// <remarks>SC_TASKLIST</remarks>
        SC_TASKLIST = 0xF130,

        /// <summary>Scroll vertically.
        /// lParam
        /// If a Control-menu command is chosen with the mouse, lParam contains the cursor coordinates. The low-order word contains the x coordinate, and the high-order word contains the y coordinate. Otherwise this parameter is not used.</summary>
        /// <remarks>SC_VSCROLL</remarks>
        SC_VSCROLL = 0xF070
    }
}
