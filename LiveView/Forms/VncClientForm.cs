using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.Enums;
using Mtf.Network.EventArg;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class VncClientForm : Form
    {
        private const int IMAGE_SIZE = 4096000;
        private const int SCREEN_WAIT_TIME = 200;

        private readonly VncClient vncClient;
        private bool working = true;
        private int expectedImageSize;
        private byte[] rawImageData;

        public VncClientForm(string ipOrHostname, ushort port)
        {
            InitializeComponent();
            DoubleBuffered = true;
            vncClient = new VncClient(ipOrHostname, port);
            vncClient.ErrorOccurred += VncClient_ErrorOccurred;
            vncClient.FrameArrived += VncClient_FrameArrived;
            vncClient.Start();
            //ClientSize = new Size(width, height);
        }

        private void VncClient_FrameArrived(object sender, FrameArrivedEventArgs e)
        {
            BackgroundImage = (Image)e.Frame.Clone();
            e.Frame.Dispose();
        }

        private void VncClient_ErrorOccurred(object sender, ExceptionEventArgs e)
        {
            ErrorBox.Show(e.Exception);
        }

        private void VncClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            working = false;
        }

        private void VncClientForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Send($"{VncCommand.KeyPressed} {e.KeyChar}");
        }

        private void VncClient_MouseClick(object sender, MouseEventArgs e)
        {
            SendMouseEvent(VncCommand.MouseClick, e);
        }

        private void VncClient_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SendMouseEvent(VncCommand.MouseDoubleClick, e);
        }

        private void VncClient_MouseMove(object sender, MouseEventArgs e)
        {
            Send($"{VncCommand.MouseMove} {e.X} {e.Y}");
        }

        private void VncClient_MouseDown(object sender, MouseEventArgs e)
        {
            SendMouseEvent(VncCommand.MouseDown, e);
        }

        private void VncClient_MouseUp(object sender, MouseEventArgs e)
        {
            SendMouseEvent(VncCommand.MouseUp, e);
        }

        private void VncClient_Wheel(object sender, MouseEventArgs e)
        {
            Send($"{VncCommand.Scroll} {e.Delta}");
        }

        private void SendMouseEvent(string eventType, MouseEventArgs e)
        {
            var button = Get(e.Button);
            Send($"{eventType} {button}");
        }

        private void Send(string message, [CallerMemberName] string callerFunction = "")
        {
            try
            {
                vncClient.Send(message);
            }
            catch (Exception ex)
            {
                ErrorBox.Show(callerFunction, ex);
            }
        }

        private int Get(MouseButtons mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButtons.Left:
                    return 0;
                case MouseButtons.Middle:
                    return 1;
                case MouseButtons.Right:
                    return 2;
            }
            return -1;
        }
    }
}
