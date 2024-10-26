using System.ComponentModel;

namespace Mtf.Enums.Audio
{
    public enum mci_command : byte
    {
        [Description("set cdaudio door open")]
        set_cdaudio_door_open,
        [Description("set cdaudio door close")]
        set_cdaudio_door_close
    }
}
