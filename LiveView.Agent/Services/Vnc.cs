using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;

namespace LiveView.Agent.Services
{
    public static class Vnc
    {
        public static VncServer Start()
        {
            try
            {
                Console.WriteLine("Starting VNC server...");
                var vncServer = new VncServer(new ScreenInfoProvider());
                vncServer.ErrorOccurred += VncServer_ErrorOccurred;
                vncServer.Start();
                Console.WriteLine($"VNC server started at: {vncServer}");
                return vncServer;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                ErrorBox.Show(ex);
                return null;
            }
        }

        private static void VncServer_ErrorOccurred(object sender, ExceptionEventArgs e)
        {
            Console.Error.WriteLine(e.Exception);
        }
    }
}
