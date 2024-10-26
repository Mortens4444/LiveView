namespace Mtf.Enums.Window
{
    public enum SkipChildWindowType : uint
    {
        /// <summary>
        /// Does not skip any child windows
        /// </summary>
        CWP_ALL = 0,
        /// <summary>
        /// Skips invisible child windows
        /// </summary>
        CWP_SKIPINVISIBLE = 1,
        /// <summary>
        /// Skips disabled child windows
        /// </summary>
        CWP_SKIPDISABLED = 2,
        /// <summary>
        /// Skips transparent child windows
        /// </summary>
        CWP_SKIPTRANSPARENT = 4
    }
}
