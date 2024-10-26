namespace Mtf.Enums.Window
{
    public enum hWndInsertAfter : int
    {
        /// <summary>Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows. </summary>
        /// <remarks>HWND_BOTTOM</remarks>
        HWND_BOTTOM = 1,
        /// <summary>Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window. This value is not supported in Windows CE 1.0 and 1.01.</summary>
        /// <remarks>HWND_NOTOPMOST</remarks>
        HWND_NOTOPMOST = -2,
        /// <summary>Places the window at the top of the z-order.</summary>
        /// <remarks>HWND_TOP</remarks>
        HWND_TOP = 0,
        /// <summary>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated. This value is not supported in Windows CE 1.0 and 1.01.</summary>
        /// <remarks>HWND_TOPMOST</remarks>
        HWND_TOPMOST = -1
    }
}
