using LiveView.Agent.Services;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace LiveView.Agent
{
    class Program
    {
        private static ILogger<ExceptionHandler> logger;

        private static LiveViewConnector liveViewConnector;

        //private static readonly GeneralOptionsRepository generalOptionsRepository;
        private static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();
        
        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static Program()
        {
            DatabaseInitializer.Initialize("LiveViewConnectionString");
            //generalOptionsRepository = new GeneralOptionsRepository();
        }

        static void Main(string[] args)
        {
            ExceptionHandler.CatchUnhandledExceptions();
            using (var serviceProvider = ServiceProviderFactory.Create())
            {
                logger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();
                ExceptionHandler.SetLogger(logger);
                liveViewConnector = new LiveViewConnector(serviceProvider.GetRequiredService<ILogger<LiveViewConnector>>());
            }

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();

#if !DEBUG
            const int SW_HIDE = 0;
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
#endif
            StartVideoCaptureServers();

            var serverIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                liveViewConnector.ConnectAsync(serverIp, serverPort);
            }
            else
            {
                var message = "LiveViewServer.ListenerPort cannot be parsed as an ushort.";
                logger.LogError(message);
                ErrorBox.Show("General error", message);
            }
        }

        private static void StartVideoCaptureServers()
        {
            var json = ConfigurationManager.AppSettings["StartCameras"];
            var videoCaptureIds = JsonSerializer.Deserialize<List<string>>(json);
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

                    var videoCaptureServer = new VideoCaptureServer();
                    var server = videoCaptureServer.StartVideoCaptureServer(liveViewConnector, videoCapture, videoCaptureId);
                    liveViewConnector.AddVideoCaptureWithServer(videoCaptureId, videoCapture, server);

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Start video capture servers failed.");
                    ErrorBox.Show(ex);
                }
            }
        }

        private static void OnExit()
        {
            liveViewConnector.Disconnect();
            Application.Exit();
        }
    }
}