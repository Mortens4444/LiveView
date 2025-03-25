using Camera.MAUI;
using Camera.MAUI.ZXingHelper;

namespace LiveView.Agent.Maui
{
    public partial class MainPage : ContentPage
    {
        bool playing;

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
                //Send(bcr.Text);
            }
        }

        private void CameraView_CamerasLoaded(object? sender, EventArgs e)
        {
            if (cameraView.NumCamerasDetected > 0)
            {
                if (cameraView.NumMicrophonesDetected > 0)
                { 
                    cameraView.Microphone = cameraView.Microphones.First();
                }
                cameraView.Camera = cameraView.Cameras.First();
                //if (await cameraView.StartCameraAsync() == CameraResult.Success)
                //{
                //}
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
                }
            }
            else
            {
                if (await cameraView.StopCameraAsync() == CameraResult.Success)
                {
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
