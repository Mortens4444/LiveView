using AxVIDEOCONTROL4Lib;
using Database.Models;
using LiveView.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LiveView.Services.VideoServer
{
    public static class VideoCameraMotionTrigger
    {
        public static async Task<bool> ConnectAsync(IMotionPopupView motionPopup, Camera camera, Action motionAction, int connectionTimeoutMs, CancellationToken cancellationToken = default)
        {
            var stopwatch = new Stopwatch();
            var connectTcs = new TaskCompletionSource<bool>();

            void OnConnect(object sender, EventArgs e)
            {
                connectTcs.TrySetResult(true);

                _ = Task.Run(async () =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        ProcessMotionSignal(motionPopup, stopwatch, camera, motionAction);
                        await Task.Delay(100, cancellationToken);
                    }
                }, cancellationToken);
            }

            void OnConnectFailed(object sender, _DVideoMotionEvents_onConnectFailedEvent e)
            {
                connectTcs.TrySetResult(false);
            }

            void OnDisconnect(object sender, EventArgs e)
            {
                motionPopup.AxVideoMotion.onConnect -= OnConnect;
                motionPopup.AxVideoMotion.onConnectFailed -= OnConnectFailed;
                motionPopup.AxVideoMotion.onDisconnect -= OnDisconnect;
            }

            motionPopup.AxVideoMotion.onConnect += OnConnect;
            motionPopup.AxVideoMotion.onConnectFailed += OnConnectFailed;
            motionPopup.AxVideoMotion.onDisconnect += OnDisconnect;

            motionPopup.AxVideoMotion.Connect(camera.IpAddress, camera.Guid, camera.ServerUsername, camera.ServerPassword);

            var completedTask = await Task.WhenAny(connectTcs.Task, Task.Delay(connectionTimeoutMs));
            if (completedTask != connectTcs.Task)
            {
                return false;
            }

            return connectTcs.Task.Result;
        }

        private static void ProcessMotionSignal(IMotionPopupView motionPopup, Stopwatch stopwatch, Camera camera, Action motionAction)
        {
            if (motionPopup.AxVideoMotion.Motion > (short)camera.MotionTrigger)
            {
                if (!stopwatch.IsRunning)
                {
                    stopwatch.Restart();
                }
                else if (stopwatch.ElapsedMilliseconds > camera.MotionTriggerMinimumLength * 1000)
                {
                    motionAction();
                    stopwatch.Reset();
                }
            }
            else
            {
                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                    stopwatch.Reset();
                }
            }
        }
    }
}
