using Mtf.MessageBoxes;
using Mtf.Network;
using System;

namespace LiveView.Core.Services.Net
{
    public class MyVideoCaptureClient : VideoCaptureClient
    {
        private byte[] previousFrame = Array.Empty<byte>();

        public event EventHandler FrameUnchanged;

        public MyVideoCaptureClient(string serverIp, int serverPort) : base(serverIp, serverPort)
        {
        }

        private void OnFrameArrived(byte[] fullImageData)
        {
            try
            {
                if (IsSameAsPrevious(fullImageData))
                {
                    FrameUnchanged?.Invoke(this, EventArgs.Empty);
                    return;
                }

                previousFrame = new byte[fullImageData.Length];
                Array.Copy(fullImageData, previousFrame, fullImageData.Length);

                base.OnFrameArrived(fullImageData);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private bool IsSameAsPrevious(byte[] currentFrame)
        {
            if (previousFrame.Length != currentFrame.Length)
            {
                return false;
            }

            for (int i = 0; i < currentFrame.Length; i++)
            {
                if (currentFrame[i] != previousFrame[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
