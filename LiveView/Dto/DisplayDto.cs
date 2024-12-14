using Database.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Dto
{
    public class DisplayDto
    {
        public int Id => Convert.ToInt32(DeviceName.Replace("\\\\.\\DISPLAY", String.Empty));

        public string DeviceName { get; set; }

        public string[] HardwareId { get; set; }

        public string DeviceDescription { get; set; }

        public string Driver { get; set; }

        public string Mfg { get; set; }

        public byte[] EDID { get; set; }

        public string DeviceId { get; set; }

        public string PnPDeviceId { get; set; }

        public Screen Screen { get; set; }

        public object Tag { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Rectangle Bounds { get; set; }

        public Rectangle WorkingArea { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public int LittleX { get; set; }

        public int LittleY { get; set; }

        public int LittleWidth { get; set; }

        public int LittleHeight { get; set; }

        public string MonitorName { get; set; }

        public string AdapterName { get; set; }

        public string SziltechId { get; set; }

        public bool Selected { get; set; }

        public bool Primary { get; set; }

        public bool Removable { get; set; }

        public bool AttachedToDesktop { get; set; }

        public bool MainForm { get; set; }

        public bool Fullscreen { get; set; }

        public bool CanShowSequence { get; set; }

        public bool CanShowFullscreen { get; set; }

        public override string ToString()
        {
            return $"DeviceID: {DeviceId}, Location: ({X}, {Y}), Size: {MaxWidth}x{MaxHeight}, Sziltech ID: {SziltechId}";
        }

        public Display ToDisplay()
        {
            return new Display
            {
                Id = Id,
                CanShowFullscreen = CanShowFullscreen,
                CanShowSequence = CanShowSequence,
                FullscreenDisplay = Fullscreen,
                PnPDeviceId = PnPDeviceId,
                ShownName = MonitorName
            };
        }
    }
}
