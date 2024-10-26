namespace Mtf.Enums.Network
{
    public enum ShareType : uint
    {
        STYPE_DISK = 0, // Disk share
        STYPE_PRINTQ = 1, // Print queue
        STYPE_DEVICE = 2, // Communication device
        STYPE_IPC = 3, // IPC (interprocess communication) share
        STYPE_TEMPORARY = 0x40000000, // A temporary share
        STYPE_SPECIAL = 0x80000000,
        STYPE_HIDDEN_DISK = 0x80000000, // Admin disk share
        STYPE_HIDDEN_PRINT = 0x80000001, // Admin print share
        STYPE_HIDDEN_DEVICE = 0x80000002, // Admin device share
        STYPE_HIDDEN_IPC = 0x80000003, // Admin IPC share
    }
}
