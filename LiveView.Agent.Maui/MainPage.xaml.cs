#if ANDROID
using Android.Content;
using Android.OS;
#endif

using Camera.MAUI;
using Mtf.Network;

namespace LiveView.Agent.Maui
{
    public partial class MainPage : ContentPage
    {
        private bool playing;
        private CancellationTokenSource? cancellationTokenSource;
        private Server? server;
        private string cameraId = "default";

#if ANDROID
        private static PowerManager.WakeLock? wakeLock;
#endif

        public MainPage()
        {
            InitializeComponent();

#if ANDROID
            var powerManager = (PowerManager)Android.App.Application.Context.GetSystemService(Context.PowerService);
            wakeLock = powerManager.NewWakeLock(WakeLockFlags.Partial, "CameraView:WakeLock");
            wakeLock.Acquire();
#endif

            cameraView.CamerasLoaded += CameraView_CamerasLoaded;
        }

        ~MainPage()
        {

#if ANDROID
            wakeLock?.Release();
            wakeLock = null;
#endif

        }

        private void CameraView_CamerasLoaded(object? sender, EventArgs e)
        {
            if (cameraView.NumCamerasDetected > 0)
            {
                cameraView.Camera = cameraView.Cameras.First();
            }
        }

        private async void StartCamera_Clicked(object sender, EventArgs e)
        {
            if (!playing)
            {
                if (await cameraView.StartCameraAsync(new Size(1280, 720)) == CameraResult.Success)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        startStopButton.Text = "Stop";
                        playing = true;
                    });

                    cancellationTokenSource = new CancellationTokenSource();
                    
                    var connectionInfo = serverEntry.Text.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    if (connectionInfo.Length != 2)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "IP address and port is needed in this format: 192.168.0.1:4444", "OK");
                        return;
                    }
                    var cameraCaptureServer = new ImageCaptureServer(new CameraViewImageSource(cameraView), cameraId);
                    //var cameraCaptureServer = new CameraCaptureServer(cameraView, cameraId);
                    server = cameraCaptureServer.StartVideoCaptureServer(cancellationTokenSource);
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        serverLabel.Text = $"Server: {server}";
                    });
                    var liveViewConnector = new LiveViewConnector(cameraId, server.ToString(), cancellationTokenSource);
                    _ = liveViewConnector.ConnectAsync(connectionInfo[0], Convert.ToUInt16(connectionInfo[1]));
                }
            }
            else
            {
                if (await cameraView.StopCameraAsync() == CameraResult.Success)
                {
                    cancellationTokenSource?.Cancel();
                    if (server != null)
                    {
                        server.Dispose();
                        server = null;
                    }

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        startStopButton.Text = "Start";
                        playing = false;
                        serverLabel.Text = "Server: Not started";
                    });
                }
            }
        }
    }
}
