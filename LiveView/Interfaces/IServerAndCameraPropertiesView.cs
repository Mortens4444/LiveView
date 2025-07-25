using Database.Models;
using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IServerAndCameraPropertiesView : IView
    {
        VideoServer Server { get; }

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

        TextBox TbManufacturer { get; }

        TextBox TbModel { get; }

        PictureBox PbPingTestStatus { get; }

        PictureBox PbRemoteVideoServerConnectionStatus { get; }

        ImageList ImageList { get; }

        Label LblPingTestStatus { get; }

        Label LblRemoteVideoServerConnectionStatus { get; }

        TextBox TbVideoServerErrorMessage { get; }

        TextBox TbReturnCode { get; }

        TextBox TbVideoServerTime { get; }

        TextBox TbRecorderVersion { get; }

        TextBox TbRemoteVideoServerVersion { get; }

        TextBox TbVideoRecorderProtocolVersion { get; }

        TextBox TbRecorderStatus { get; }

        TextBox TbCpuUsage { get; }

        TextBox TbRecordingInterval { get; }

        TextBox TbRecordedLocalCameraNumber { get; }

        TextBox TbLicensedCameraNumber { get; }

        TextBox TbLiveViewDisplay { get; }

        TextBox TbWindowErrorMessage { get; }

        PictureBox PbWindowsConnectionStatus { get; }

        TextBox TbRecording { get; }
    }
}
