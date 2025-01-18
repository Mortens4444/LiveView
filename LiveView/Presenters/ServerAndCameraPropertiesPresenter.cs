using Database.Interfaces;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.Network.Services;
using Mtf.WmiHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class ServerAndCameraPropertiesPresenter : BasePresenter
    {
        private IServerAndCameraPropertiesView view;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<ServerAndCameraProperties> logger;

        public ServerAndCameraPropertiesPresenter(ServerAndCameraPropertiesPresenterDependencies serverAndCameraPropertiesPresenterDependencies)
            : base(serverAndCameraPropertiesPresenterDependencies)
        {
            serverRepository = serverAndCameraPropertiesPresenterDependencies.ServerRepository;
            cameraRepository = serverAndCameraPropertiesPresenterDependencies.CameraRepository;
            logger = serverAndCameraPropertiesPresenterDependencies.Logger;
        }
        
        public override void Load()
        {

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

        public void ExportHadwareInfo()
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
                Task.Run(() =>
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
                        { "Log Event", "SELECT * FROM Win32_NTLogEvent" }
                    };

                    view.LvHardwareInformation.Invoke((Action)(() =>
                    {
                        view.LvHardwareInformation.Groups.Clear();
                        view.LvHardwareInformation.Items.Clear();
                    }));
                    foreach (var query in queries)
                    {
                        var group = new ListViewGroup(query.Key, HorizontalAlignment.Left);
                        view.LvHardwareInformation.Invoke((Action)(() => view.LvHardwareInformation.Groups.Add(group)));
                        try
                        {
                            var wmiReaderResult = Wmi.GetObjects(query.Value, "CIMv2", view.Server.IpAddress, ImpersonationLevel.Impersonate, AuthenticationLevel.Default, true, view.TbWindowsUsername.Text, null, view.TbWindowsPassword.Text);

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

                                    view.LvHardwareInformation.Invoke((Action)(() =>
                                    {
                                        view.LvHardwareInformation.Items.Add(listViewItem);
                                    }));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var errorItem = new ListViewItem("Error fetching data")
                            {
                                Group = group,
                                SubItems = { ex.Message }
                            };
                            view.LvHardwareInformation.Invoke((Action)(() =>
                            {
                                view.LvHardwareInformation.Items.Add(errorItem);
                            }));
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void Refresh()
        {
            throw new NotImplementedException();
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
    }
}
