using Camera.MAUI;
using Mtf.Network;
using System.Collections.ObjectModel;
using System.Net.Sockets;

namespace LiveView.Agent.Maui
{
    public partial class MainPage : ContentPage
    {
        private bool playing;
        private CancellationTokenSource? cancellationTokenSource;
        private Server? server;

        public int BufferSize { get; set; } = 409600;

        public ObservableCollection<CameraInfo> AvailableCameras { get; } = new();


        private CameraInfo? selectedCamera;
        
        public CameraInfo? SelectedCamera
        {
            get => selectedCamera;
            set
            {
                if (selectedCamera == value)
                {
                    return;
                }

                selectedCamera = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            cameraView.Loaded += (s, e) => LoadCameras();
            DeviceDisplay.KeepScreenOn = true;
        }

        private void LoadCameras()
        {
            AvailableCameras.Clear();
            foreach (var camera in cameraView.Cameras)
            {
                AvailableCameras.Add(camera);
            }

            SelectedCamera = AvailableCameras.FirstOrDefault();
        }

        private void OnNumberCompleted(object sender, EventArgs e)
        {
            const int min = 4096;
            const int max = Int32.MaxValue;

            if (sender is Entry entry)
            {
                if (UInt32.TryParse(entry.Text, out var value))
                {
                    if (value < min)
                    {
                        value = min;
                    }
                    else if (value > max)
                    {
                        value = max;
                    }

                    entry.Text = value.ToString();
                }
                else
                {
                    entry.Text = min.ToString();
                }
            }
        }

        private async void StartCamera_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!playing)
                {
                    cameraView.Camera = SelectedCamera;
                    var result = await cameraView.StartCameraAsync(new Size(1280, 720));
                    if (result == CameraResult.Success)
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

                        var ipAddress = NetworkHelper.GetDeviceIpAddressPreferPrivate(AddressFamily.InterNetwork, preferredIpAddressEntry.Text);
                        if (ipAddress == null)
                        {
                            throw new InvalidOperationException("IP address cannot be retrieved.");
                        }
                        var cameraCaptureServer = new ImageCaptureServer(new CameraViewImageSource(cameraView), cameraNameEntry.Text, ipAddress)
                        {
                            BufferSize = BufferSize
                        };
                        server = cameraCaptureServer.StartVideoCaptureServer(cancellationTokenSource);
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            serverLabel.Text = $"Server: {server}";
                        });
                        var liveViewConnector = new LiveViewConnector(cameraNameEntry.Text, server.ToString(), cancellationTokenSource);
                        _ = liveViewConnector.ConnectAsync(connectionInfo[0], Convert.ToUInt16(connectionInfo[1]));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", $"The cameraView.StartCameraAsync call failed: {result}", "OK");
                    }
                }
                else
                {
                    var result = await cameraView.StopCameraAsync();
                    if (result == CameraResult.Success)
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
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", $"The cameraView.StopCameraAsync call failed: {result}", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
