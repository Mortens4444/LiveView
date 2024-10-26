using System;

namespace Mtf.Enums.Dev
{
    [Flags]
    public enum FilePermissionType : int
    {
        FullAccess = 1,
        ModifyAccess = 2,
        ReadAndExecuteAccess = 4,
        ReadOnlyAccess = 8,
        WriteOnlyAccess = 16,
        Delete = 32,
        ReadControl = 64,
        WriteDAC = 128,
        WriteOwner = 256,
        Syncronize = 512,
        AccessSystemSecurity = 1024,
        MaximumAllowed = 2048,
        GenericRead = 4096,
        GenericWrite = 8192,
        GenericExecute = 16384,
        GenericAll = 32768,
        ReadData_ListDirectory = 65536,
        WriteData_AddFile = 131072,
        AppendData_AddSubdirectory = 262144,
        ReadExtendedAttributes = 524288,
        WriteExctendedAttributes = 1048576,
        Execute_Traverse = 2097152,
        DeleteChild = 4194304,
        ReadAttributes = 8388608,
        WriteAttributes = 16777216
    }
}
