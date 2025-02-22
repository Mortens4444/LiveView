using Mtf.Controls.Sunell.IPR66.CustomEventArgs;
using Mtf.Controls.Sunell.IPR66.SunellSdk;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Mtf.Controls.Sunell.IPR66
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SunellVideoWindowLegacy), "Resources.VideoSource.png")]
    public class SunellVideoWindowLegacy : PictureBox
    {
        private IntPtr nvdHandle = IntPtr.Zero;

        private const int WM_USER = 0x400;
        private const int WM_LIVEPLAY_MESSAGE = WM_USER + 1000;

        public delegate void VideoSignalChangedEventHandler(object sender, VideoSignalChangedEventArgs e);

        public event VideoSignalChangedEventHandler VideoSignalChanged;

        public SunellVideoWindowLegacy()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            //BackgroundImage = Properties.Resources.NoSignal;
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

        public void Connect(Form parentForm, string cameraIp = "192.168.0.120", ushort cameraPort = 30001, string username = "admin", string password = "admin")
        {
            var deviceInfo = new ST_DeviceInfo
            {
                UserID = username,
                Password = password,
                InetAddr = new ST_InetAddr
                {
                    HostIP = cameraIp,
                    Port = cameraPort,
                    IPProtocolVersion = 1
                }
            };

            const int transferProtocol = 2;
            var returnCode = NvdcDll.Remote_Nvd_Init(ref nvdHandle, ref deviceInfo, transferProtocol);
            CheckForError(returnCode);

            if (NvdcDll.NvdSdk_Is_Handle_Valid(nvdHandle))
            {
                _ = NvdcDll.Remote_LivePlayer2_SetAutoConnectFlag(nvdHandle, true);
                _ = NvdcDll.Remote_LivePlayer2_SetDefaultStreamId(nvdHandle, 1);

                returnCode = NvdcDll.Remote_LivePlayer2_Open(nvdHandle, 1);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_SetNotifyWindow(nvdHandle, Handle, WM_LIVEPLAY_MESSAGE, IntPtr.Zero);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_SetVideoWindow(nvdHandle, Handle, 0, 0, Width, Height);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_Play(nvdHandle);
                CheckForError(returnCode);

                BackgroundImage = null;
                IsConnected = true;
            }
            else
            {
                throw new InvalidOperationException("The handle is not valid.");
            }
        }

        public void Disconnect()
        {
            _ = NvdcDll.Remote_LivePlayer2_Close(nvdHandle);
            _ = NvdcDll.Remote_Nvd_UnInit(nvdHandle);
            IsConnected = false;
            BackgroundImage = Properties.Resources.NoSignal;
            //Invoke((Action)(() => { Invalidate(); }));
        }

        public int PTZ_Open(int cameraId)
        {
            return NvdcDll.Remote_PTZEx_Open(nvdHandle, cameraId);
        }

        public int PTZ_Close()
        {
            return NvdcDll.Remote_PTZEx_Close(nvdHandle);
        }

        public int PTZ_Stop()
        {
            return NvdcDll.Remote_PTZEx_Stop(nvdHandle);
        }

        public int PTZ_RotateUp(int speed)
        {
            return NvdcDll.Remote_PTZEx_RotateUp(nvdHandle, speed);
        }

        public int PTZ_RotateDown(int speed)
        {
            return NvdcDll.Remote_PTZEx_RotateDown(nvdHandle, speed);
        }

        public int PTZ_RotateRight(int speed)
        {
            return NvdcDll.Remote_PTZEx_RotateRight(nvdHandle, speed);
        }

        public int PTZ_RotateLeft(int speed)
        {
            return NvdcDll.Remote_PTZEx_RotateLeft(nvdHandle, speed);
        }

        public void RefreshImage()
        {
            _ = NvdcDll.Remote_LivePlayer2_SetVideoWindow(nvdHandle, Handle, 0, 0, Width, Height);
            Invoke((Action)(() => { Invalidate(); }));
        }

        protected override void OnResize(EventArgs e)
        {
            RefreshImage();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            RefreshImage();
            base.OnSizeChanged(e);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LIVEPLAY_MESSAGE:
                    switch ((SunellEventID)m.WParam.ToInt32())
                    {
                        case SunellEventID.EVENTID_CREATE_VIDEO_SESSION_SUCCESS:
                            {
                                BackgroundImage = null;
                                VideoSignalChanged?.Invoke(this, new VideoSignalChangedEventArgs(true));

                                //RefreshImage();
                                break;
                            }
                        case SunellEventID.EVENTID_LOGIN_USERNAME_WRONG:
                        case SunellEventID.EVENTID_LOGIN_PASSWORD_WRONG:
                        case SunellEventID.EVENTID_CREATE_VIDEO_SESSION_FAILED:
                        case SunellEventID.EVENTID_RECEIVE_VIDEO_ERROR:
                        case SunellEventID.EVENTID_DEVICE_NOT_SUPPORT_VIDEO:
                            {
                                BackgroundImage = Properties.Resources.NoSignal;
                                VideoSignalChanged?.Invoke(this, new VideoSignalChangedEventArgs(false));
                                break;
                            }
                        default:
                            base.WndProc(ref m);
                            break;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
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

        private void CheckForError(int errorCode, [CallerMemberName] string callerFunction = "", [CallerFilePath] string callerFile = "", [CallerLineNumber] int callerLine = 0)
        {
            if (errorCode != 0)
            {
                throw new AggregateException($"ErrorCode: {errorCode}, {callerFunction} in {callerFile}, line {callerLine}", new InvalidOperationException(NvdcDll.GetErrorMessage(errorCode)));
            }
        }
    }
}
