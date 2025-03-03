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

        public const int EVENTID_CREATE_VIDEO_SESSION_SUCCESS = 1;
        public const int EVENTID_CREATE_AUDIO_SESSION_SUCCESS = 2;
        public const int EVENTID_CREATE_VIDEO_SESSION_FAILED = 3;
        public const int EVENTID_CREATE_AUDIO_SESSION_FAILED = 4;
        public const int EVENTID_VIDEO_SESSION_CLOSED_SUCCESS = 5;
        public const int EVENTID_AUDIO_SESSION_CLOSED_SUCCESS = 6;
        public const int EVENTID_LOGIN_USERNAME_WRONG = 7;
        public const int EVENTID_LOGIN_PASSWORD_WRONG = 8;
        public const int EVENTID_RECEIVE_VIDEO_ERROR = 9;
        public const int EVENTID_RECEIVE_AUDIO_ERROR = 10;
        public const int EVENTID_DEVICE_NOT_SUPPORT_VIDEO = 11;
        public const int EVENTID_DEVICE_NOT_SUPPORT_AUDIO = 12;
        public const int EVENTID_DEVICE_NO_PRIVILEGE = 13;
        public const int EVENTID_DEVICE_MAX_CONNECTION = 14;
        public const int EVENTID_FILE_PLAYBACK_END = 15;
        public const int EVENTID_LOGIN_USER_REPEATED = 16;
        public const int EVENTID_LOGIN_USER_LOCKED = 17;

        public delegate void VideoSignalChangedEventHandler(object sender, VideoSignalChangedEventArgs e);

        public event VideoSignalChangedEventHandler VideoSignalChanged;

        public SunellVideoWindowLegacy()
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
                SetAutoConnectFlag(true);
                SetDefaultStreamId(1);

                returnCode = NvdcDll.Remote_LivePlayer2_SetVideoWindow(nvdHandle, Handle, 0, 0, Width, Height);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_SetNotifyWindow(nvdHandle, Handle, WM_LIVEPLAY_MESSAGE, IntPtr.Zero);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_Open(nvdHandle, 1);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_Play(nvdHandle);
                CheckForError(returnCode);

                //BackgroundImage = null;
                IsConnected = true;
            }
            else
            {
                throw new InvalidOperationException("The handle is not valid.");
            }
        }

        public void SetUseTimeStamp(bool useTimeStamp)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetUseTimeStamp(nvdHandle, useTimeStamp);
            CheckForError(returnCode);
        }

        public void SetStretchMode(bool stretch)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetStretchMode(nvdHandle, stretch);
            CheckForError(returnCode);
        }

        public void SetAutoConnectFlag(bool autoConnect)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetAutoConnectFlag(nvdHandle, autoConnect);
            CheckForError(returnCode);
        }

        public void SetContrast(int percent)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentContrast(nvdHandle, percent);
            CheckForError(returnCode);
        }

        public void SetDefaultStreamId(int streamId)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetDefaultStreamId(nvdHandle, streamId);
            CheckForError(returnCode);
        }

        public void SetBrightness(int percent)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentBrightness(nvdHandle, percent);
            CheckForError(returnCode);
        }

        public void SetHue(int percent)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentHue(nvdHandle, percent);
            CheckForError(returnCode);
        }

        public void SetSaturation(int percent)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentSaturation(nvdHandle, percent);
            CheckForError(returnCode);
        }

        public void PlaySound()
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_PlaySound(nvdHandle);
            CheckForError(returnCode);
        }

        public void Pause()
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_Pause(nvdHandle);
            CheckForError(returnCode);
        }

        public void CreateSnapShot(string filePath)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SnapShot(nvdHandle, filePath);
            CheckForError(returnCode);
        }

        public void StartRecording(string filePath)
        {
            var returnCode = NvdcDll.Remote_LivePlayer2_SetRecorderFile(nvdHandle, filePath);
            CheckForError(returnCode);

            returnCode = NvdcDll.Remote_LivePlayer2_StartRecord(nvdHandle);
            CheckForError(returnCode);
        }

        public void StopRecording(string filePath)
        {
            int recorderStatus = 0;
            var returnCode = NvdcDll.Remote_LivePlayer2_GetRecorderStatus(nvdHandle, ref recorderStatus);
            CheckForError(returnCode);
            
            if (recorderStatus == 1)
            {
                returnCode = NvdcDll.Remote_LivePlayer2_StopRecord(nvdHandle);
                CheckForError(returnCode);
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
            base.WndProc(ref m);

            switch ((int)m.WParam)
            {
                case EVENTID_CREATE_VIDEO_SESSION_SUCCESS:
                    Invoke((Action)(() => { BackgroundImage = null; }));
                    VideoSignalChanged?.Invoke(this, new VideoSignalChangedEventArgs(true));
                    base.WndProc(ref m);
                    break;
                case EVENTID_CREATE_VIDEO_SESSION_FAILED:
                case EVENTID_VIDEO_SESSION_CLOSED_SUCCESS:
                case EVENTID_RECEIVE_VIDEO_ERROR:
                case EVENTID_DEVICE_NOT_SUPPORT_VIDEO:
                    Invoke((Action)(() => { BackgroundImage = Properties.Resources.NoSignal; }));
                    VideoSignalChanged?.Invoke(this, new VideoSignalChangedEventArgs(false));
                    base.WndProc(ref m);
                    break;
                case EVENTID_CREATE_AUDIO_SESSION_SUCCESS:
                case EVENTID_CREATE_AUDIO_SESSION_FAILED:
                case EVENTID_AUDIO_SESSION_CLOSED_SUCCESS:
                case EVENTID_LOGIN_USERNAME_WRONG:
                case EVENTID_LOGIN_PASSWORD_WRONG:
                case EVENTID_RECEIVE_AUDIO_ERROR:
                case EVENTID_DEVICE_NOT_SUPPORT_AUDIO:
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
