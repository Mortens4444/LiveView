using Camera.MAUI;
using Camera.MAUI.ZXingHelper;
using Mtf.Network;
using System.Text;

namespace LiveView.Agent.Maui
{
    public partial class MainPage : ContentPage
    {
        private bool playing;
        //private readonly HttpClient httpClient = new();
        private CancellationTokenSource? _cancellationTokenSource;
        private Server? _server;
        private readonly Dictionary<string, CancellationTokenSource> _cancellationTokenSources = new();

        public MainPage()
        {
            InitializeComponent();
            cameraView.CamerasLoaded += CameraView_CamerasLoaded;
            cameraView.BarcodeDetected += CameraView_BarcodeDetected;
        }

        private void CameraView_BarcodeDetected(object sender, BarcodeEventArgs args)
        {
            foreach (var bcr in args.Result)
            {
                string serverAddress = serverEntry.Text;
                //SendBarcode(serverAddress, bcr.Text);
            }
        }

        private void CameraView_CamerasLoaded(object? sender, EventArgs e)
        {
            if (cameraView.NumCamerasDetected > 0)
            {
                //if (cameraView.NumMicrophonesDetected > 0)
                //{ 
                //    cameraView.Microphone = cameraView.Microphones.First();
                //}
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

                    _cancellationTokenSource = new CancellationTokenSource();
                    string cameraId = "default"; // Egyedi azonosító a kamerának

                    _server = CameraCaptureServer.Capture(
                        _cancellationTokenSources,
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
                    _cancellationTokenSource?.Cancel();
                    if (_server != null)
                    {
                        _server.Dispose();
                        _server = null;
                    }

                    if (_cancellationTokenSources.ContainsKey("default"))
                    {
                        _cancellationTokenSources["default"].Cancel();
                        _cancellationTokenSources.Remove("default");
                    }

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        startStopButton.Text = "Start";
                        playing = false;
                    });
                }
            }
        }

        //private async Task CaptureAndSendLoop(CancellationToken token)
        //{
        //    while (!token.IsCancellationRequested)
        //    {
        //        try
        //        {
        //            var photo = await cameraView.CaptureAsync();
        //            if (photo != null)
        //            {
        //                using var stream = await photo.OpenReadAsync();
        //                using var memoryStream = new MemoryStream();
        //                await stream.CopyToAsync(memoryStream);
        //                var imageBytes = memoryStream.ToArray();

        //                var serverAddress = serverEntry.Text;
        //                await SendImage(serverAddress, imageBytes);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            await MainThread.InvokeOnMainThreadAsync(() => DisplayAlert("Error", $"Failed to capture/send image: {ex.Message}", "OK"));
        //        }

        //        await Task.Delay(40, token);
        //    }
        //}

        //private async Task SendBarcode(string serverAddress, string barcode)
        //{
        //    try
        //    {
        //        var content = new StringContent($"{{ \"barcode\": \"{barcode}\" }}", Encoding.UTF8, "application/json");
        //        var response = await httpClient.PostAsync($"http://{serverAddress}/barcode", content);

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            await DisplayAlert("Error", "Failed to send barcode.", "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"Failed to send barcode: {ex.Message}", "OK");
        //    }
        //}
    }
}
