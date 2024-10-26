namespace Mtf.Enums.Keyboard
{
    public enum LoadKeyboardLayoutFlags
    {
        /// <summary>
        /// If the specified input locale identifier is not already loaded, the function loads and activates the input locale identifier for the current thread.
        /// </summary>
        KLF_ACTIVATE = 0x00000001,
        /// <summary>
        /// Prevents a ShellProc hook procedure from receiving an HSHELL_LANGUAGE hook code when the new input locale identifier is loaded. This value is typically used when an application loads multiple input locale identifiers one after another. Applying this value to all but the last input locale identifier delays the shell's processing until all input locale identifiers have been added.
        /// </summary>
        KLF_NOTELLSHELL = 0x00000080,
        /// <summary>
        /// Moves the specified input locale identifier to the head of the input locale identifier list, making that locale identifier the active locale identifier for the current thread. This value reorders the input locale identifier list even if KLF_ACTIVATE is not provided.
        /// </summary>
        KLF_REORDER = 0x00000008,
        /// <summary>
        /// Windows 95/98/Me, Windows NT 4.0, and Windows 2000/XP:If the new input locale identifier has the same language identifier as a current input locale identifier, the new input locale identifier replaces the current one as the input locale identifier for that language. If this value is not provided and the input locale identifiers have the same language identifiers, the current input locale identifier is not replaced and the function returns NULL. 
        /// </summary>
        KLF_REPLACELANG = 0x00000010,
        /// <summary>
        /// Substitutes the specified input locale identifier with another locale preferred by the user. The system starts with this flag set, and it is recommended that your application always use this flag. The substitution occurs only if the registry key HKEY_CURRENT_USER\Keyboard\Layout\Substitutes explicitly defines a substitution locale. For example, if the key includes the value name "00000409" with value "00010409", loading the U.S. English layout ("00000409") causes the Dvorak U.S. English layout ("00010409") to be loaded instead. The system uses KLF_SUBSTITUTE_OK when booting, and it is recommended that all applications use this value when loading input locale identifiers to ensure that the user's preference is selected.
        /// </summary>
        KLF_SUBSTITUTE_OK = 0x00000002,
        /// <summary>
        /// Windows 2000/XP:: This flag is valid only with KLF_ACTIVATE. Activates the specified input locale identifier for the entire process and sends the WM_INPUTLANGCHANGE message to the current thread's Focus or Active window. Typically, LoadKeyboardLayout activates an input locale identifier only for the current thread.
        /// </summary>
        KLF_SETFORPROCESS = 0x00000100,
        /// <summary>
        /// This flag is unsupported. Use the UnloadKeyboardLayout function instead.
        /// </summary>
        KLF_UNLOADPREVIOUS
    }
}
