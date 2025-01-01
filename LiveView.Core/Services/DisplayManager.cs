using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Core.Services
{
    public class DisplayManager
    {
        public const int FrameWidth = 3;
        private const int Delta = 5;

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
                if ((adapter.StateFlags & DisplayDeviceStateFlags.MirroringDriver) == DisplayDeviceStateFlags.MirroringDriver)
                {
                    deviceIndex++;
                    continue; // Skip virtual mirror displays
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

        public (Rectangle, Point) GetScreensBounds()
        {
            var minX = Int32.MaxValue;
            var minY = Int32.MaxValue;
            var maxX = Int32.MinValue;
            var maxY = Int32.MinValue;

            var screens = Screen.AllScreens;
            foreach (var screen in screens)
            {
                if (screen is null) continue;

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
            return (new Rectangle(minX, minY, maxX - minX, maxY - minY), deltaPoint);
        }

        public Dictionary<int, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size drawnSize)
        {
            var result = new Dictionary<int, Rectangle>();
            var (screenBounds, deltaPoint) = GetScreensBounds();
            var scale = GetScaleFactor(screenBounds, drawnSize);

            var offsetX = screenBounds.Left / scale;
            var offsetY = screenBounds.Top / scale;

            foreach (var display in displays)
            {
                var scaledX = offsetX + (display.X + deltaPoint.X) / scale + FrameWidth;
                var scaledY = offsetY + (display.Y + deltaPoint.Y) / scale + FrameWidth;

                result.Add(display.Id, new Rectangle(
                    (int)Math.Round(scaledX),
                    (int)Math.Round(scaledY) + Delta,
                    (int)Math.Round(display.Width / scale),
                    (int)Math.Round(display.Height / scale) + Delta
                ));
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
