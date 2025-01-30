using Database.Models;
using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IServerAndCameraPropertiesView : IView
    {
        Server Server { get; }

        MtfListView LvCameraList { get; }

        MtfListView LvHardwareInformation { get; }

        SaveFileDialog SaveFileDialog { get; }

        TextBox TbPassword { get; }

        TextBox TbVideoServerName { get; }

        TextBox TbHost { get; }

        TextBox TbWindowsUsername { get; }

        TextBox TbWindowsPassword { get; }

        TextBox TbVideoServerUsername { get; }

        TextBox TbVideoServerPassword { get; }

        TextBox TbDongleSerial { get; }

        TextBox TbDongleSubtype { get; }

        TextBox TbMacAddress { get; }

        TextBox TbModel { get; }

        PictureBox PbPingTestStatus { get; }

        PictureBox PbRemoteVideoServerConnectionStatus { get; }

        ImageList ImageList { get; }
    }
}
