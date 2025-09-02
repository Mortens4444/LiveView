using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using LiveView.Core.Interfaces;
using Microsoft.Win32;
using Mtf.Network.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LiveView.Core.Services
{
    public class DisplayManager : IDisplayManager
    {
        public const int FrameWidth = 3;
        private const int Delta = 5;

        public static readonly ObservableList<DisplayDto> RemoteDisplays = new ObservableList<DisplayDto>();

        /// <summary>
        /// Retrieves all connected display devices.
        /// </summary>
        /// <returns>A list of <see cref="DisplayDevice"/> representing the connected display devices.</returns>
        public List<DisplayDto> GetAll()
        {
            var result = new List<DisplayDto>();

            var adapter = new DISPLAY_DEVICE();
            adapter.Initialize();

            uint deviceIndex = 0;
            while (WinAPI.EnumDisplayDevices(null, deviceIndex, ref adapter, 0))
            {
                Console.WriteLine($"Checking: {adapter.DeviceName} - {adapter.DeviceString}");
                if ((adapter.StateFlags & DisplayDeviceStateFlags.MirroringDriver) == DisplayDeviceStateFlags.MirroringDriver)
                {
                    if ((adapter.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) == DisplayDeviceStateFlags.PrimaryDevice)
                    {
                        Console.WriteLine($"Primary Display Found: {adapter.DeviceName}");
                    }
                    else if ((adapter.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop) == DisplayDeviceStateFlags.AttachedToDesktop)
                    {
                        Console.WriteLine($"Attached to Desktop: {adapter.DeviceName}");
                    }
                    else
                    {
                        deviceIndex++;
                        continue;
                    }
                }

                var displayDevice = new DISPLAY_DEVICE();
                displayDevice.Initialize();

                uint devMon = 0;
                while (WinAPI.EnumDisplayDevices(adapter.DeviceName, devMon, ref displayDevice, 0))
                {
                    if ((displayDevice.StateFlags & DisplayDeviceStateFlags.Active) == DisplayDeviceStateFlags.Active)
                    {
                        break;
                    }

                    devMon++;
                }

                if (String.IsNullOrEmpty(displayDevice.DeviceString))
                {
                    WinAPI.EnumDisplayDevices(adapter.DeviceName, 0, ref displayDevice, 0);
                    displayDevice.DeviceString = displayDevice.DeviceString ?? "Default display";
                }

                var deviceMode = new DEVMODE();
                deviceMode.Initialize();
                if (WinAPI.EnumDisplaySettingsEx(adapter.DeviceName, EDSModeNum.ENUM_CURRENT_SETTINGS, ref deviceMode, EDSFlags.NULL))
                {
                    var monitorHandle = IntPtr.Zero;
                    var monitorInfo = new MONITORINFO();
                    monitorInfo.Initialize();

                    if ((adapter.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop) == DisplayDeviceStateFlags.AttachedToDesktop)
                    {
                        var position = new Point(deviceMode.dmPositionX, deviceMode.dmPositionY);
                        monitorHandle = WinAPI.MonitorFromPoint(position, MonitorOptions.MONITOR_DEFAULTTONULL);
                    }

                    bool mainForm = false, fullscreen = false, primary = false, removable = true, attachedToDesktop = true;
                    if (monitorHandle != IntPtr.Zero)
                    {
                        WinAPI.GetMonitorInfo(monitorHandle, ref monitorInfo);
                        mainForm = monitorInfo.rcWork.Left == 0 && monitorInfo.rcWork.Top == 0;
                        fullscreen = mainForm;
                        primary = (adapter.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) != 0;
                        removable = (adapter.StateFlags & DisplayDeviceStateFlags.Removable) != 0;
                        attachedToDesktop = (adapter.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop) != 0;
                    }

                    result.Add(new DisplayDto
                    {
                        DeviceId = deviceIndex.ToString(),
                        X = monitorInfo.rcWork.Left,
                        Y = monitorInfo.rcWork.Top,
                        Width = monitorInfo.rcWork.Right - monitorInfo.rcWork.Left,
                        Height = monitorInfo.rcWork.Bottom - monitorInfo.rcWork.Top,
                        MaxWidth = deviceMode.dmPelsWidth,
                        MaxHeight = deviceMode.dmPelsHeight,
                        MonitorName = displayDevice.DeviceString,
                        AdapterName = adapter.DeviceString,
                        DeviceName = adapter.DeviceName,
                        SziltechId = $"M-{deviceIndex + 1}",
                        IsPrimary = primary,
                        Removable = removable,
                        AttachedToDesktop = attachedToDesktop,
                        MainForm = mainForm,
                        Fullscreen = fullscreen,
                    });
                }

                deviceIndex++;
            }

            var localIps = NetUtils.GetLocalIPAddresses(AddressFamily.InterNetwork).ToList();
            foreach (var remoteDisplay in RemoteDisplays)
            {
                var hostAndPort = remoteDisplay.Host.Split(':');
                //if (!localIps.Contains(hostAndPort[0]))
                {
                    result.Add(remoteDisplay);
                }
            }

            if (result.Count == 0)
            {
                int i = 0;
                foreach (var screen in Screen.AllScreens)
                {
                    i++;
                    result.Add(new DisplayDto
                    {
                        DeviceId = i.ToString(),
                        X = screen.Bounds.Left,
                        Y = screen.Bounds.Top,
                        Width = screen.Bounds.Right - screen.Bounds.Left,
                        Height = screen.Bounds.Bottom - screen.Bounds.Top,
                        MaxWidth = screen.Bounds.Width,
                        MaxHeight = screen.Bounds.Height,
                        MonitorName = adapter.DeviceName,
                        AdapterName = adapter.DeviceString,
                        DeviceName = $"\\\\.\\DISPLAY{i}",
                        SziltechId = $"M-{i}",
                        IsPrimary = screen.Primary,
                        Removable = true,
                        AttachedToDesktop = true,
                        MainForm = screen.Primary,
                        Fullscreen = false,
                    });
                }
            }

            if ((!result.Any(display => display.Selected)) && result.Count > 0)
            {
                result[0].Selected = true;
            }

            return result;
        }

        /// <summary>
        /// Creates a Display from device name
        /// </summary>
        /// <param name="deviceName">Ex.: \\\\.\\DISPLAY1</param>
        public DisplayDto GetDisplay(string deviceName)
        {
            var result = new DisplayDto
            {
                DeviceName = deviceName
            };

            //this.factorySupportedModes = new List<string>();

            var displays = GetAll();
            foreach (var display in displays)
            {
                if (display.DeviceName == deviceName)
                {
                    result.Screen = Screen.FromPoint(new Point(display.X, display.Y));
                    //result.DisplayDevice = display;
                    // TODO: Copy properties
                    break;
                }
            }

            var displayDevice = new DISPLAY_DEVICE();
            displayDevice.Initialize();

            const uint devMon = 0;
            WinAPI.EnumDisplayDevices(deviceName, devMon, ref displayDevice, 1);
            result.PnPDeviceId = displayDevice.DeviceID.Replace("\\\\?\\", String.Empty).Replace('#', '\\').ToUpper();

            WinAPI.EnumDisplayDevices(deviceName, devMon, ref displayDevice, 0);
            result.DeviceId = displayDevice.DeviceID;

            var registryKeyPath = $"SYSTEM\\CurrentControlSet\\Enum\\{result.PnPDeviceId}";
            using (var displayDeviceKey = Registry.LocalMachine.OpenSubKey(registryKeyPath))
            {
                if (displayDeviceKey?.OpenSubKey("Control") != null)
                {
                    result.HardwareId = displayDeviceKey.GetValue("HardwareID") as string[];
                    result.DeviceDescription = displayDeviceKey.GetValue("DeviceDesc") as string;
                    result.Driver = displayDeviceKey.GetValue("Driver") as string;
                    result.Mfg = displayDeviceKey.GetValue("Mfg") as string;

                    using (var parametersKey = displayDeviceKey.OpenSubKey("Device Parameters"))
                    {
                        result.EDID = parametersKey?.GetValue("EDID") as byte[];
                    }
                }
                return result;
            }
        }

        public DisplayDimensions ScreensBounds
        {
            get
            {
                var minX = Int32.MaxValue;
                var minY = Int32.MaxValue;
                var maxX = Int32.MinValue;
                var maxY = Int32.MinValue;

                var screens = Screen.AllScreens;
                foreach (var screen in screens)
                {
                    if (screen is null)
                    {
                        continue;
                    }

                    var bounds = screen.Bounds;

                    minX = Math.Min(minX, bounds.X);
                    minY = Math.Min(minY, bounds.Y);
                    maxX = Math.Max(maxX, bounds.Right);
                    maxY = Math.Max(maxY, bounds.Bottom);
                }

                var deltaPoint = new Point();
                if (minX < 0)
                {
                    minX = 0;
                    maxX += minX;
                    deltaPoint.X = minX;
                }
                if (minY < 0)
                {
                    minY = 0;
                    maxY += minY;
                    deltaPoint.Y = minY;
                }
                return new DisplayDimensions(new Rectangle(minX, minY, maxX - minX, maxY - minY), deltaPoint);
            }
        }

        private static Size GetDisplayGroupSizesByAgent(List<DisplayDto> displays)
        {
            var dimensionsByAgents = displays?
                .GroupBy(d => d.Host ?? String.Empty)
                .ToDictionary(
                    g => g.Key,
                    g => new Size(
                        g.Sum(d => d.MaxWidth),
                        g.Max(d => d.MaxHeight)
                    )
                );
            return GetTotalDisplayArea(dimensionsByAgents);
        }

        private static Size GetTotalDisplayArea(Dictionary<string, Size> groupedSizes)
        {
            var totalWidth = groupedSizes.Values.Sum(s => s.Width);
            var maxHeight = groupedSizes.Values.Max(s => s.Height);
            return new Size(totalWidth, maxHeight);
        }

        public Dictionary<string, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size drawnSize)
        {
            var displayDimensions = GetDisplayGroupSizesByAgent(displays);
            var result = new Dictionary<string, Rectangle>();
            var scale = GetScaleFactor(new Rectangle(new Point(0, 0), displayDimensions), drawnSize);

            var displaysGroupedByHost = displays
                .GroupBy(d => d.Host)
                .OrderBy(g => g.Key);

            int width = 0;
            foreach (var agentDisplays in displaysGroupedByHost)
            {
                var offset = new Point(width, 0);
                foreach (var display in agentDisplays)
                {
                    var scaledX = (int)Math.Round((/*offset.X +*/ display.X) / scale + FrameWidth);
                    var scaledY = (int)Math.Round((/*offset.Y +*/ display.Y) / scale + FrameWidth);
                    var scaledBounds = new Rectangle(
                        scaledX + offset.X,
                        scaledY + offset.Y + Delta,
                        (int)Math.Round(display.Width / scale),
                        (int)Math.Round(display.Height / scale) + Delta
                    );
                    result.Add(display.Id, scaledBounds);

                    width = Math.Max(width, scaledX + scaledBounds.Width + offset.X);
                }
            }

            return result;
        }

        public double GetScaleFactor(Rectangle screenBounds, Size drawnSize)
        {
            const double adjustmentFactor = 5;
            const double baseDivisor = 1000;

            double adjustedHeight = ((screenBounds.Height / baseDivisor) + 1) * adjustmentFactor + screenBounds.Height;
            double adjustedWidth = ((screenBounds.Width / baseDivisor) + 1) * adjustmentFactor + screenBounds.Width;

            double scaleHeight = adjustedHeight / drawnSize.Height + 1;
            double scaleWidth = adjustedWidth / drawnSize.Width + 1;

            return Math.Max(scaleHeight, scaleWidth);
        }
    }
}
