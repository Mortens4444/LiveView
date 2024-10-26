namespace Mtf.Enums.HardwareKey
{
    public enum LicenseCheckResult : byte
    {
        HardwareKey_Algorithm_Error,
        HardwareKey_Checksum_Error,
        HardwareKey_Initialization,
        Unknown_Error,
        Video_Supervisor_Is_Not_Licensed,
        Live_View_Is_Not_Licensed,
        Licensed
    }
}
