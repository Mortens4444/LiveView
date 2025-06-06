using Database.Interfaces;
using Database.Services;
using LiveView.Agent.Services;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Controls.Video.OpenCvSharp;
using Mtf.Database;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using Mtf.Network;
using Mtf.Network.EventArg;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Agent
{
    class Program
    {
        private static bool databaseInitialized;

        private static ILogger<ExceptionHandler> logger;

        private static LiveViewConnector liveViewConnector;

        //private static readonly GeneralOptionsRepository generalOptionsRepository;
        private static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();
        
        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static CancellationTokenSource cancellationTokenSource;

        private static List<ImageCaptureServer> imageCaptureServers = new List<ImageCaptureServer>();

        private static VncServer vncServer;

        static Program()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            databaseInitialized = DatabaseInitializer.Initialize("LiveViewConnectionString");
            //generalOptionsRepository = new GeneralOptionsRepository();
        }

        static void Main(string[] args)
        {
            if (!databaseInitialized)
            {
                return;
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            try
            {
                Console.WriteLine("Starting VNC server...");
                vncServer = new VncServer(new ScreenInfoProvider());
                vncServer.ErrorOccurred += VncServer_ErrorOccurred;
                vncServer.Start();
                Console.WriteLine($"VNC server started at: {vncServer}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                ErrorBox.Show(ex);
            }

            ExceptionHandler.CatchUnhandledExceptions();
            var serviceProvider = ServiceProviderFactory.Create();
            //using (var serviceProvider = ServiceProviderFactory.Create())
            {
                try
                {
                    logger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();
                    ExceptionHandler.SetLogger(logger);

                    var liveViewConnectorLogger = serviceProvider.GetRequiredService<ILogger<LiveViewConnector>>();
                    var agentRepository = serviceProvider.GetRequiredService<IAgentRepository>();
                    var videoSourceRepository = serviceProvider.GetRequiredService<IVideoSourceRepository>();
                    liveViewConnector = new LiveViewConnector(liveViewConnectorLogger, agentRepository, videoSourceRepository);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                    Console.Error.WriteLine($"Used connection string: {BaseRepository.ConnectionString}");
                    throw;
                }
            }

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();

            if (AppConfig.GetBoolean(Core.Constants.LiveViewAgentHideConsoleWindow))
            {
                const int SW_HIDE = 0;
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
            }

            try
            {
                StartVideoCaptureServers();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }

            var serverIp = AppConfig.GetString(Core.Constants.LiveViewServerIpAddress);
            var serverPort = AppConfig.GetUInt16WithThrowOnError(Core.Constants.LiveViewServerListenerPort);
            if (serverPort != default)
            {
                Task.Run(() => liveViewConnector.ConnectAsync(serverIp, serverPort, vncServer.CommandServer.ListenerPortOfServer, cancellationTokenSource.Token)).Wait();
            }
            else
            {
                var message = $"{Core.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.";
                logger.LogError(message);
                ErrorBox.Show("General error", message);
            }
        }

        private static void VncServer_ErrorOccurred(object sender, ExceptionEventArgs e)
        {
            Console.Error.WriteLine(e.Exception);
        }

        private static void StartVideoCaptureServers()
        {
            Console.WriteLine("Starting video capture servers...");
            var json = AppConfig.GetString(Core.Constants.StartCameras);
            cancellationTokenSource?.CancelAndDispose();
            cancellationTokenSource = new CancellationTokenSource();

            var videoCaptureIds = Json.Deserialize<List<string>>(json);
            var bufferSize = AppConfig.GetInt32(Core.Constants.ImageCaptureServerBufferSize, 409600);

            foreach (var videoCaptureId in videoCaptureIds)
            {
                try
                {
                    Console.WriteLine($"Starting video capture server ({videoCaptureId})");
                    var videoCapture = Int32.TryParse(videoCaptureId, out var videoCaptureIndex) ?
                        new VideoCapture(videoCaptureIndex) : new VideoCapture(videoCaptureId);

                    // Cameras should have uniques values
                    //var exposure = generalOptionsRepository.Get<int>(Database.Enums.Setting.Exposure, 0);
                    //videoCapture.Set(VideoCaptureProperties.Exposure, exposure); // -4, 1, 0.75

                    //var brightness = generalOptionsRepository.Get<int>(Database.Enums.Setting.Brightness, 0);
                    //videoCapture.Set(VideoCaptureProperties.Brightness, brightness); // 50 (scale 0–100)

                    //var gain = generalOptionsRepository.Get<int>(Database.Enums.Setting.Gain, 0);
                    //videoCapture.Set(VideoCaptureProperties.Gain, gain); // 10

                    var imageCaptureServer = new ImageCaptureServer(new VideoCaptureImageSource(videoCapture), videoCaptureId)
                    {
                        BufferSize = bufferSize
                    };
                    imageCaptureServers.Add(imageCaptureServer);
                    imageCaptureServer.FPS = AppConfig.GeByte(Core.Constants.LiveViewAgentImageCaptureServerFps, 4);

                    var videoCaptureServer = imageCaptureServer.StartVideoCaptureServer(cancellationTokenSource);
                    //var videoCaptureServer = new VideoCaptureServer();
                    //var server = videoCaptureServer.StartVideoCaptureServer(liveViewConnector, videoCapture, videoCaptureId);
                    Console.WriteLine($"Video capture server ({videoCaptureId}): {videoCaptureServer}");
                    liveViewConnector.AddVideoCaptureWithServer(videoCaptureId, videoCapture, videoCaptureServer);
                    Console.Title = $"LiveView Agent: {videoCaptureServer}";
                }
                catch (Exception ex)
                {
                    logger.LogException(ex, $"Start video capture server {videoCaptureId} failed.");
                    ErrorBox.Show(ex);
                }
            }
        }

        private static void OnExit()
        {
            foreach (var imageCaptureServer in imageCaptureServers)
            {
                imageCaptureServer.Dispose();
            }
            cancellationTokenSource?.CancelAndDispose();
            liveViewConnector.Disconnect();
            Application.Exit();
        }
    }
}