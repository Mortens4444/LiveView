using Camera.MAUI;
using Mtf.Network;

namespace LiveView.Agent.Maui
{
    public partial class MainPage : ContentPage
    {
        private bool playing;
        private CancellationTokenSource? cancellationTokenSource;
        private Server? server;
        private readonly Dictionary<string, CancellationTokenSource> cancellationTokenSources = new();
        private string cameraId = "default";

        public MainPage()
        {
            InitializeComponent();
            cameraView.CamerasLoaded += CameraView_CamerasLoaded;
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

                    server = CameraCaptureServer.Capture(
                        cancellationTokenSources,
                        cameraView,
                        cameraId,
                        fps: 25
                    );
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

                    if (cancellationTokenSources.ContainsKey(cameraId))
                    {
                        cancellationTokenSources[cameraId].Cancel();
                        cancellationTokenSources.Remove(cameraId);
                    }

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        startStopButton.Text = "Start";
                        playing = false;
                    });
                }
            }
        }
    }
}
