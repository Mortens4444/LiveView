using Database.Enums;
using Database.Interfaces;
using LiveView.Core.Services.PasswordHashers;
using LiveView.Enums;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.Logging;
using Mtf.Extensions;
using Mtf.HardwareKey;
using Mtf.LanguageService;
using Mtf.Network.EventArg;
using Mtf.Network.Services;
using Mtf.Windows.Forms.Extensions;
using Mtf.WmiHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class ServerAndCameraPropertiesPresenter : BasePresenter, IDisposable
    {
        private IServerAndCameraPropertiesView view;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<ServerAndCameraProperties> logger;
        private Ping ping;
        private CancellationTokenSource cancellationTokenSource;
        private Task hardwareInfoRetrieverTask;

        public ServerAndCameraPropertiesPresenter(ServerAndCameraPropertiesPresenterDependencies dependencies)
            : base(dependencies)
        {
            serverRepository = dependencies.ServerRepository;
            cameraRepository = dependencies.CameraRepository;
            logger = dependencies.Logger;
        }
        
        public async override void Load()
        {
            var hwKey = Globals.HardwareKey as SiliconVideoHardwareKey;
            view.TbVideoServerName.Text = view.Server.Hostname;
            view.TbHost.Text = view.Server.IpAddress;
            view.TbVideoServerUsername.Text = view.Server.Username;
            view.TbVideoServerPassword.Text = view.Server.Password;
            view.TbMacAddress.Text = view.Server.MacAddress;
            view.TbWindowsUsername.Text = view.Server.WinUser;
            view.TbWindowsPassword.Text = WindowsPasswordCryptor.Decrypt(view.Server.WinPass);

            var iszSziltechDeice = SziltechDeviceChecker.IsSziltechDevice(view.Server?.DongleSn, out var deviceInfo);
            if (iszSziltechDeice)
            {
                view.TbManufacturer.Text = "Sziltech Electronic Kft.";
                view.TbModel.Text = Lng.Elem(deviceInfo.Model);
            }
            else
            {
                view.TbManufacturer.Text = Lng.Elem("Unknown");
                view.TbModel.Text = Lng.Elem("Unknown");
            }

            var connectionTimeout = generalOptionsRepository.Get(Setting.MaximumTimeToWaitForAVideoServerIs, 500);
            var connectionResult = await VideoServerConnector.ConnectAsync(view.GetSelf<IVideoServerView>(), view.Server, connectionTimeout);
            if (connectionResult.ErrorCode == VideoServerErrorHandler.Success)
            {
                view.PbRemoteVideoServerConnectionStatus.Image = view.ImageList.Images[0];
                view.LblRemoteVideoServerConnectionStatus.Text = Lng.Elem("Remote Video Server connection successful");
                view.LvCameraList.Items.Clear();
                foreach (var camera in connectionResult.Cameras)
                {
                    var item = new ListViewItem(camera.Name);
                    foreach (CameraStatusInfo status in Enum.GetValues(typeof(CameraStatusInfo)))
                    {
                        var cameraRpcCode = (int)camera[CameraStatusInfo.RPC_ReturnCode];
                        var value = cameraRpcCode == VideoServerErrorHandler.Success || status == CameraStatusInfo.RPC_ReturnCode ?
                            camera[status]?.ToString() ?? String.Empty :
                            Lng.Elem("N/A");

                        item.SubItems.Add(value);
                    }
                    view.LvCameraList.Items.Add(item);
                }
                view.TbReturnCode.BackColor = Color.YellowGreen;
                var recorderReturnCode = (int)connectionResult[RecorderStatusInfo.ReturnCode];
                var recorderStatusMessage =  Lng.Elem(VideoServerErrorHandler.GetMessage(recorderReturnCode));
                view.TbRecorderStatus.Text = $"{recorderReturnCode}: {recorderStatusMessage}";
                view.TbRecorderStatus.BackColor = view.TbRecorderStatus.Text == "0" ? Color.YellowGreen : Color.IndianRed;

                if (recorderReturnCode == VideoServerErrorHandler.Success)
                {
                    view.TbCpuUsage.Text = $"{connectionResult[RecorderStatusInfo.CPU_Usage]}%";

                    view.TbDongleSerial.Text = $"{connectionResult[RecorderStatusInfo.DongleSerial]}";
                    view.TbDongleSubtype.Text = $"{connectionResult[RecorderStatusInfo.DongleSubtype]}";

                    view.TbVideoRecorderProtocolVersion.Text = $"{connectionResult[RecorderStatusInfo.ProtocolVersion]}";
                    view.TbRecorderVersion.Text = $"{connectionResult[RecorderStatusInfo.RecorderVersion]}";
                    view.TbRemoteVideoServerVersion.Text = $"{connectionResult[RecorderStatusInfo.ServerVersion]}";

                    view.TbLicensedCameraNumber.Text = $"{connectionResult[RecorderStatusInfo.NumberOfLocalCameras]}";
                    view.TbRecordingInterval.Text = $"{connectionResult[RecorderStatusInfo.OnTimeInSeconds]}";
                    view.TbVideoServerTime.Text = $"{DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(connectionResult[RecorderStatusInfo.ServerLocalTime_UnixTime])).DateTime}";
                    view.TbLiveViewDisplay.Text = $"{connectionResult[RecorderStatusInfo.FullScreenMode]}";
                    view.TbRecording.Text = Lng.Elem(Convert.ToBoolean(connectionResult[RecorderStatusInfo.On_Off]).ToString());
                }
                else
                {
                    view.TbCpuUsage.Text = Lng.Elem("N/A");

                    view.TbDongleSerial.Text = Lng.Elem("N/A");
                    view.TbDongleSubtype.Text = Lng.Elem("N/A");

                    view.TbVideoRecorderProtocolVersion.Text = Lng.Elem("N/A");
                    view.TbRecorderVersion.Text = Lng.Elem("N/A");
                    view.TbRemoteVideoServerVersion.Text = Lng.Elem("N/A");

                    view.TbLicensedCameraNumber.Text = Lng.Elem("N/A");
                    view.TbRecordingInterval.Text = Lng.Elem("N/A");
                    view.TbVideoServerTime.Text = Lng.Elem("N/A");
                    view.TbLiveViewDisplay.Text = Lng.Elem("N/A");
                    view.TbRecording.Text = Lng.Elem("N/A");
                }

                view.TbRecordedLocalCameraNumber.Text = $"{connectionResult.Cameras.Count}";
            }
            else
            {
                view.TbRecording.Text = Lng.Elem("N/A");
                view.TbLiveViewDisplay.Text = Lng.Elem("N/A");
                view.TbVideoServerTime.Text = Lng.Elem("N/A");
                view.TbRecordingInterval.Text = Lng.Elem("N/A");

                view.TbLicensedCameraNumber.Text = Lng.Elem("N/A");
                view.TbRecordedLocalCameraNumber.Text = Lng.Elem("N/A");

                view.TbVideoRecorderProtocolVersion.Text = Lng.Elem("N/A");
                view.TbRecorderVersion.Text = Lng.Elem("N/A");
                view.TbRemoteVideoServerVersion.Text = Lng.Elem("N/A");

                view.TbRecorderStatus.Text = Lng.Elem("N/A");
                view.TbCpuUsage.Text = Lng.Elem("N/A");
                view.TbDongleSerial.Text = Lng.Elem("N/A");
                view.TbDongleSubtype.Text = Lng.Elem("N/A");

                view.PbRemoteVideoServerConnectionStatus.Image = view.ImageList.Images[1];
                view.LblRemoteVideoServerConnectionStatus.Text = Lng.Elem("Remote Video Server connection failed");
                view.TbReturnCode.BackColor = Color.IndianRed;
            }
            view.TbReturnCode.Text = connectionResult.ErrorCode.ToString();
            view.TbVideoServerErrorMessage.Text = Lng.Elem(VideoServerErrorHandler.GetMessage(connectionResult.ErrorCode));

            ping = new Ping(view.Server.IpAddress);
            ping.PingReplyArrived += Ping_PingReplyArrived;

            GetHardwareInfo();
        }

        private void Ping_PingReplyArrived(object sender, PingReplyArrivedEventArgs e)
        {
            var imageIndex = e.Success ? 0 : 1;
            view.PbPingTestStatus.Image = view.ImageList.Images[imageIndex];
            view.LblPingTestStatus.Text = e.Success ? Lng.Elem("Ping test successful") : Lng.Elem("Ping test failed");
            ping.Dispose();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IServerAndCameraPropertiesView;
        }

        public void ExportCameraList()
        {
            view.SaveFileDialog.FileName = $"{view.Server} {Lng.Elem("Camera list")}.csv";
            if (view.SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                view.LvCameraList.ExportItemsToCsv(view.SaveFileDialog.FileName);
            }
        }

        public void ExportHardwareInfo()
        {
            view.SaveFileDialog.FileName = $"{view.Server} {Lng.Elem("Hardware information")}.csv";
            if (view.SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                view.LvHardwareInformation.ExportItemsToCsv(view.SaveFileDialog.FileName);
            }
        }

        public void GetHardwareInfo()
        {
            try
            {
                cancellationTokenSource?.CancelAndDispose();
                hardwareInfoRetrieverTask?.Wait();

                cancellationTokenSource = new CancellationTokenSource();
                hardwareInfoRetrieverTask = Task.Run(() =>
                {
                    var queries = new Dictionary<string, string>
                    {
                        { "Parallel Port", "SELECT * FROM Win32_ParallelPort" },
                        { "Base Board", "SELECT * FROM Win32_BaseBoard" },
                        { "Processor Information", "SELECT * FROM Win32_Processor" },
                        { "BIOS", "SELECT * FROM Win32_BIOS" },
                        { "Disk Drives", "SELECT * FROM Win32_DiskDrive" },
                        { "System Operating System", "SELECT * FROM Win32_SystemOperatingSystem" },
                        { "Operating System", "SELECT * FROM Win32_OperatingSystem" },
                        { "Computer System", "SELECT * FROM Win32_ComputerSystem" },
                        { "Physical Memory", "SELECT * FROM Win32_PhysicalMemory" },
                        //{ "Log Event", "SELECT * FROM Win32_NTLogEvent" } // Throws OutOfMemoryException
                    };

                    view.LvHardwareInformation.InvokeIfRequired(() =>
                    {
                        view.LvHardwareInformation.Groups.Clear();
                        view.LvHardwareInformation.Items.Clear();
                    });
                    foreach (var query in queries)
                    {
                        var group = new ListViewGroup(query.Key, HorizontalAlignment.Left);
                        try
                        {
                            view.LvHardwareInformation.InvokeIfRequired(() => view.LvHardwareInformation.Groups.Add(group));
                            var wmiReaderResult = Wmi.GetObjects(query.Value, "CIMv2", view.Server.IpAddress, ImpersonationLevel.Impersonate, AuthenticationLevel.Default, true, view.TbWindowsUsername.Text, null, view.TbWindowsPassword.Text);
                            view.PbWindowsConnectionStatus.Image = view.ImageList.Images[0];

                            foreach (var row in wmiReaderResult)
                            {
                                foreach (KeyValuePair<string, int> item in wmiReaderResult.ColumnIndexes)
                                {
                                    var listViewItem = new ListViewItem
                                    {
                                        Group = group,
                                        Text = item.Key
                                    };
                                    var value = row.ElementAt(item.Value);
                                    listViewItem.SubItems.Add(value is Array array ?
                                        String.Join(", ", array.Cast<object>()) :
                                        value?.ToString() ?? "N/A");

                                    view.LvHardwareInformation.InvokeIfRequired(() =>
                                    {
                                        view.LvHardwareInformation.Items.Add(listViewItem);
                                    });
                                }
                            }
                        }
                        catch (ObjectDisposedException) { }
                        catch (Exception ex)
                        {
                            try
                            {
                                if (view.ImageList.Images.Count > 1)
                                { 
                                    view.PbWindowsConnectionStatus.Image = view.ImageList.Images[1];
                                }
                                view.TbWindowErrorMessage.Text = ex.Message;
                                var errorItem = new ListViewItem("Error fetching data")
                                {
                                    Group = group,
                                    SubItems = { ex.Message }
                                };
                                view.LvHardwareInformation.InvokeIfRequired(() =>
                                {
                                    view.LvHardwareInformation.Items.Add(errorItem);
                                });
                            }
                            catch (InvalidOperationException) { }
                        }
                    }
                }, cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void ShowWinPassword()
        {
            view.TbWindowsPassword.PasswordChar = '\0';
        }

        public void ShowPassword()
        {
            view.TbPassword.PasswordChar = '\0';
        }

        public void WakeOnLAN()
        {
            try
            {
                WakeOnLan.SendMagicPacket(view.Server.MacAddress);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void Dispose()
        {
            cancellationTokenSource?.Dispose();
        }
    }
}
