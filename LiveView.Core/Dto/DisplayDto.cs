using Database.Models;
using System;
using System.Text.Json;
using System.Windows.Forms;

namespace LiveView.Core.Dto
{
    public class DisplayDto
    {
        public string Id => String.Concat(GetId(), Host ?? String.Empty);

        public bool IsRemote => !String.IsNullOrEmpty(Host);

        public int GetId()
        {
            return Convert.ToInt32(DeviceName.Replace("\\\\.\\DISPLAY", String.Empty));
        }

        public string Host { get; set; }

        public string DeviceName { get; set; }

        public string[] HardwareId { get; set; }

        public string DeviceDescription { get; set; }

        public string Driver { get; set; }

        public string Mfg { get; set; }

        public byte[] EDID { get; set; }

        public string DeviceId { get; set; }

        public string PnPDeviceId { get; set; }

        public Screen Screen { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public string MonitorName { get; set; }

        public string AdapterName { get; set; }

        public string SziltechId { get; set; }

        public bool Selected { get; set; }

        public bool IsPrimary { get; set; }

        public bool Removable { get; set; }

        public bool AttachedToDesktop { get; set; }

        public bool MainForm { get; set; }

        public bool Fullscreen { get; set; }

        public bool CanShowSequence { get; set; }

        public bool CanShowFullscreen { get; set; }

        public override string ToString()
        {
            return SziltechId;
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public Display ToModel()
        {
            return new Display
            {
                Id = GetId(),
                X = X,
                Y = Y,
                Width = Width,
                MaxWidth = MaxWidth,
                Height = Height,
                MaxHeight = MaxHeight,
                IsPrimary = IsPrimary,
                Removable = Removable,
                CanShowFullscreen = CanShowFullscreen,
                CanShowSequence = CanShowSequence,
                Fullscreen = Fullscreen,
                AttachedToDesktop = AttachedToDesktop,
                DeviceName = DeviceName,
                MonitorName = MonitorName,
                AdapterName = AdapterName,
                SziltechId = SziltechId
            };
        }
    }
}
