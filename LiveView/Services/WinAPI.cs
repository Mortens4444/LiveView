using LiveView.Dto;
using Mtf.Enums;
using Mtf.Enums.Display;
using Mtf.Enums.Keyboard;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LiveView.Services
{
    public static class WinAPI
    {
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, ModifierKeys fsModifiers, VirtualKeyCodes vk);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(uint hWnd, uint msg, IntPtr wParam, string lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(uint hWnd, uint msg, IntPtr wParam, string lParam, uint flags, int timeout, out IntPtr result);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("Kernel32.dll")]
        public static extern ulong GetTickCount64();

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("User32.dll")]
        public static extern bool EnumDisplaySettingsEx(string lpszDeviceName, EDSModeNum iModeNum, ref DEVMODE lpDevMode, EDSFlags dwFlags);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

        [DllImport("User32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpPoint);
    }
}
