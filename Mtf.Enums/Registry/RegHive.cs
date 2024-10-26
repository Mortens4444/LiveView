namespace Mtf.Enums.Registry
{
    public enum RegHive : uint
    {
        ClassesRoot = 0x80000000,
        CurrentUser = 0x80000001,
        LocalMachine = 0x80000002,
        Users = 0x80000003,
        CurrentConfig = 0x80000005,
        DynData = 0x80000006
    }
}
