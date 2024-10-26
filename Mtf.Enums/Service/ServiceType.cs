namespace Mtf.Enums.Service
{
    public enum ServiceType : uint
    {
        SERVICE_FILE_SYSTEM_DRIVER = 0x2,
        SERVICE_KERNEL_DRIVER = 0x1,
        SERVICE_WIN32OWN_PROCESS = 0x10,
        SERVICE_WIN32_SHARE_PROCESS = 0x20
        //SERVICE_INTERACTIVE_PROCESS
    }
}
