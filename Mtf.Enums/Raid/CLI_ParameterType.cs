namespace Mtf.Enums.Raid
{
    public enum CLI_ParameterType : byte
    {
        SetCommands,                // set
        RAID_SetFunctions,          // rsf
        VolumeSetFunctions,         // vsf
        DiskFunctions,              // disk
        RAID_SystemFunctions,       // sys
        EthernetConfiguration,      // net
        EventFunctions,             // event
        HardwareMonitorFunctions,   // hw
    }
}
