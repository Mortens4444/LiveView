using Mtf.Controls.Sunell.IPR67.CustomEventArgs;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Sunell.IPR67
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SunellVideoWindow), "Resources.VideoSource.png")]
    public class SunellVideoWindow : PictureBox
    {
        public delegate void VideoSignalChangedEventHandler(object sender, VideoSignalChangedEventArgs e);

        public event VideoSignalChangedEventHandler VideoSignalChanged;

        private UInt32 sdkHandler;
        private int streamId;

        public SunellVideoWindow()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disconnect();
            }
            base.Dispose(disposing);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text to be displayed on the control.")]
        public string OverlayText { get; set; } = String.Empty;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Font type of the text to be displayed on the control.")]
        public Font OverlayFont { get; set; } = new Font("Arial", 32, FontStyle.Bold);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color of the text to be displayed on the control.")]
        public Brush OverlayBrush { get; set; } = Brushes.White;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Location of the text to be displayed on the control.")]
        public Point OverlayLocation { get; set; } = new Point(10, 10);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConnected { get; set; }

        public void Connect(string cameraIp = "192.168.0.120", ushort cameraPort = 30001, string username = "admin", string password = "admin", int streamId = 1, int channel = 1, StreamType streamType = StreamType.HighDensity, bool hardwareAcceleration = true)
        {
            var p_obj = IntPtr.Zero;
            sdkHandler = Sdk.sdk_dev_conn(cameraIp, cameraPort, username, password, new Sdk.SDK_DISCONN_CB(DisconnectCallback), p_obj);
            this.streamId = Sdk.sdk_md_live_start(sdkHandler, channel, streamType, Handle, hardwareAcceleration, new Sdk.SDK_PLAY_TIME_CB(PlayTimeCallback), p_obj);
            //if (this.streamId != streamId)
            //{
            //    _ = Sdk.sdk_md_chg_stream(sdkHandler, streamId, streamType);
            //    this.streamId = streamId;
            //}
            IsConnected = true;
        }

        private void PlayTimeCallback(uint handle, int stream_id, IntPtr p_obj, ref byte p_time)
        {
            Debug.WriteLine($"Handle: {handle}, Stream Id: {stream_id}, Obj: {p_obj}, Time: {p_time}");
        }

        private void DisconnectCallback(uint handle, IntPtr p_obj, uint type)
        {
            Debug.WriteLine($"Handle: {handle}, Obj: {p_obj}, Type: {type}");
        }

        public void Disconnect()
        {
            var returnCode = Sdk.sdk_md_live_stop(sdkHandler, streamId);
            IsConnected = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!String.IsNullOrEmpty(OverlayText))
            {
                var graphics = e.Graphics;
                {
                    //_ = graphics.MeasureString(OverlayText, OverlayFont);
                    graphics.DrawString(OverlayText, OverlayFont, OverlayBrush, OverlayLocation);
                }
            }
        }
    }
}
