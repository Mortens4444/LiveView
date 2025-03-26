using Mtf.MessageBoxes;
using Mtf.Network;
using System;

namespace LiveView.Core.Services.Net
{
    public class MyVideoCaptureClient : VideoCaptureClient
    {
        public MyVideoCaptureClient(string serverIp, int serverPort) : base(serverIp, serverPort)
        {
        }

        private void OnFrameArrived(byte[] fullImageData)
        {
            try
            {
                base.OnFrameArrived(fullImageData);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }
    }
}
