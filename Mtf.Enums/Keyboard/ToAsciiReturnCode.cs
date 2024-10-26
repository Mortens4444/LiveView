namespace Mtf.Enums.Keyboard
{
    public enum ToAsciiReturnCode : int
    {
        /// <summary>
        /// The specified virtual key has no translation for the current state of the keyboard.
        /// </summary>
        No_translation = 0,
        /// <summary>
        /// One character was copied to the buffer.
        /// </summary>
        One_character = 1,
        /// <summary>
        /// Two characters were copied to the buffer. This usually happens when a dead-key character (accent or diacritic) stored in the keyboard layout cannot be composed with the specified virtual key to form a single character.
        /// </summary>
        Two_character = 2
    }
}
