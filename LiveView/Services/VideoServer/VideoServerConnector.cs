using AxVIDEOCONTROL4Lib;
using Database.Models;
using LiveView.Core.Services.PasswordHashers;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Models.VideoServer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveView.Services.VideoServer
{
    public static class VideoServerConnector
    {
        public static async Task<VideoServerConnectionResult> ConnectAsync(IVideoServerView videoServerView, Server server, int connectionTimeoutMs)
        {
            object recorderStatus = null;
            var cameras = new List<VideoServerCamera>();
            try
            {
                int errorCode = VideoServerErrorHandler.TimeoutErrorCode;
                var connectTcs = new TaskCompletionSource<bool>();

                var originalAxVideoServer = videoServerView.AxVideoServer;
                AxVideoServer axVideoServer = null;
                videoServerView.InvokeAction(() => axVideoServer = ShallowCopyHelper.ShallowCopy(originalAxVideoServer));

                axVideoServer.onConnect += (object sender, EventArgs e) =>
                {
                    errorCode = VideoServerErrorHandler.Success;
                    cameras = VideoCameraConnector.GetOrUpdateCameras(axVideoServer);
                    recorderStatus = axVideoServer.RecorderStatus();
                    connectTcs.TrySetResult(true);

                    // This command makes hanging the software, as this function runs asynchronous, it won't bother us.
                    //axVideoServer.Disconnect();

                    // Testing new approach to disconnect
                    axVideoServer = axVideoServer.RecreateFrom(originalAxVideoServer);
                };
                axVideoServer.onConnectFailed += (object sender, _DVideoServerEvents_onConnectFailedEvent e) =>
                {
                    errorCode = e.errorCode;
                    connectTcs.TrySetResult(false);
                };

                axVideoServer.Connect(server.IpAddress, server.Username, VideoServerPasswordCryptor.Decrypt(server.Password));
                //axVideoServer.WaitForConnect(server.VideoServerInfo.ConnectionTimeoutMs); // It will hang the UI

                await Task.WhenAny(connectTcs.Task, Task.Delay(connectionTimeoutMs));
                //server.VideoServerInfo.LastErrorCode = errorCode;
                return new VideoServerConnectionResult(errorCode, cameras, recorderStatus);
            }
            catch (ObjectDisposedException)
            {
                return new VideoServerConnectionResult(VideoServerErrorHandler.NoResult, cameras, recorderStatus);
            }
            catch (Exception)
            {
                return new VideoServerConnectionResult(VideoServerErrorHandler.UnknownErrorOccurred, cameras, recorderStatus);
            }
        }
    }
}
