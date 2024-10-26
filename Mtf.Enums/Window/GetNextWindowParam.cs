namespace Mtf.Enums.Window
{
    public enum GetNextWindowParam : uint
    {
        GW_CHILD = 5,
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        /// <summary>Returns a handle to the window below the given window.</summary>
        GW_HWNDNEXT = 2,
        /// <summary>Returns a handle to the window above the given window.</summary>
        GW_HWNDPREV = 3,
        GW_OWNER = 4
    }
}
