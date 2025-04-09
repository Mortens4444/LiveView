using Database.Interfaces;
using LiveView.Agent.Services;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Database;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using Mtf.Network;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            var hideConsoleWindow = ConfigurationManager.AppSettings[Core.Constants.LiveViewAgentHideConsoleWindow];
            if (Boolean.TryParse(hideConsoleWindow, out var hideWindow))
            {
                if (hideWindow)
                {
                    const int SW_HIDE = 0;
                    var handle = GetConsoleWindow();
                    ShowWindow(handle, SW_HIDE);
                }
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

            var serverIp = ConfigurationManager.AppSettings[Core.Constants.LiveViewServerIpAddress];
            var listenerPort = ConfigurationManager.AppSettings[Core.Constants.LiveViewServerListenerPort];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                Task.Run(() => liveViewConnector.ConnectAsync(serverIp, serverPort, cancellationTokenSource.Token)).Wait();
            }
            else
            {
                var message = $"{Core.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.";
                logger.LogError(message);
                ErrorBox.Show("General error", message);
            }
        }

        private static void StartVideoCaptureServers()
        {
            var json = ConfigurationManager.AppSettings["StartCameras"];
            cancellationTokenSource = new CancellationTokenSource();
#if NET462
            var videoCaptureIds = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json);
#else
            var videoCaptureIds = System.Text.Json.JsonSerializer.Deserialize<List<string>>(json);
#endif

            var imageCaptureServerBufferSize = ConfigurationManager.AppSettings[Core.Constants.ImageCaptureServerBufferSize];
            int bufferSize;
            if (!Int32.TryParse(imageCaptureServerBufferSize, out bufferSize))
            {
                bufferSize = 409600;
            }

            foreach (var videoCaptureId in videoCaptureIds)
            {
                try
                {
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
                        //BufferSize = bufferSize
                    };
                    imageCaptureServers.Add(imageCaptureServer);
                    var imageCaptureServerFps = ConfigurationManager.AppSettings[Core.Constants.LiveViewAgentImageCaptureServerFps];
                    if (Byte.TryParse(imageCaptureServerFps, out var fps))
                    {
                        imageCaptureServer.FPS = fps;
                    }

                    var videoCaptureServer = imageCaptureServer.StartVideoCaptureServer(cancellationTokenSource);
                    //var videoCaptureServer = new VideoCaptureServer();
                    //var server = videoCaptureServer.StartVideoCaptureServer(liveViewConnector, videoCapture, videoCaptureId);
                    Console.WriteLine($"Video capture server ({videoCaptureId}): {videoCaptureServer}");
                    liveViewConnector.AddVideoCaptureWithServer(videoCaptureId, videoCapture, videoCaptureServer);
                    Console.Title = $"LiveView Agent: {videoCaptureServer}";
                }
                catch (Exception ex)
                {
#if NET6_0_OR_GREATER
                    logger.LogError(ex, $"Start video capture server {videoCaptureId} failed.");
#else
                    logger.LogError($"Start video capture server {videoCaptureId} failed: {ex}");
#endif
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
            liveViewConnector.Disconnect();
            Application.Exit();
        }
    }
}