namespace Mtf.Enums.Permission
{
    public enum AccessRight : uint
    {
        FILE_READ_DATA = 0x1,
        FILE_WRITE_DATA = 0x2,
        FILE_APPEND_DATA = 0x4,
        FILE_READ_EA = 0x8,
        FILE_WRITE_EA = 0x10,
        FILE_EXECUTE = 0x20,
        FILE_DELETE_CHILD = 0x40,
        FILE_READ_ATTRIBUTES = 0x80,
        FILE_WRITE_ATTRIBUTES = 0x100,

        DELETE = 0x10000,
        READ_CONTROL = 0x20000,
        WRITE_DAC = 0x40000,
        WRITE_OWNER = 0x80000,
        SYNCRONIZE = 0x100000,

        ACCESS_SYSTEM_SECURITY = 0x1000000,
        MAXIMUM_ALLOWED = 0x2000000,

        GENERIC_ALL = 0x10000000,
        GENERIC_EXECUTE = 0x20000000,
        GENERIC_WRITE = 0x40000000,
        GENERIC_READ = 0x80000000
    }

}
