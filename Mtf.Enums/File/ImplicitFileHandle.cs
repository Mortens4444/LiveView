namespace Mtf.Enums.File
{
    public enum ImplicitFileHandle : uint
    {
        STD_INPUT_HANDLE = unchecked((uint)-10),
        STD_OUTPUT_HANDLE = unchecked((uint)-11),
        STD_ERROR_HANDLE = unchecked((uint)-12)
    }
}
