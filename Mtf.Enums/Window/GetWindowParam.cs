namespace Mtf.Enums.Window
{
    public enum GetWindowParam
    {
        /// <summary>
        /// The retrieved handle identifies the child window at the top of the z-order, if the specified window is a parent window; otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not examine descendant windows.
        /// </summary>
        GW_CHILD,
        /// <summary>
        /// The retrieved handle identifies the window of the same type that is highest in the z-order. If the specified window is a topmost window, the handle identifies the topmost window that is highest in the z-order. If the specified window is a child window, the handle identifies the sibling window that is highest in the z-order.
        /// </summary>
        GW_HWNDFIRST,
        /// <summary>
        /// The retrieved handle identifies the window of the same type that is lowest in the z-order. If the specified window is a topmost window, the handle identifies the topmost window that is lowest in the z-order. If the specified window is a child window, the handle identifies the sibling window that is lowest in the z-order.
        /// </summary>
        GW_HWNDLAST,
        /// <summary>
        /// The retrieved handle identifies the window below the specified window in the z-order. If the specified window is a topmost window, the handle identifies the topmost window below the specified window. If the specified window is a child window, the handle identifies the sibling window below the specified window.
        /// </summary>
        GW_HWNDNEXT,
        /// <summary>
        /// The retrieved handle identifies the window above the specified window in the z-order. If the specified window is a topmost window, the handle identifies the topmost window above the specified window. If the specified window is a child window, the handle identifies the sibling window above the specified window.
        /// </summary>
        GW_HWNDPREV,
        /// <summary>
        /// The retrieved handle identifies the specified window's owner window, if any. This flag will not retrieve a parent window.
        /// </summary>
        GW_OWNER
    }
}
