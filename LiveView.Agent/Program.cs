using Database.Services;
using LiveView.Agent.Services;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Database;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using Mtf.Network;
using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Agent
{
    class Program
    {
        private static readonly bool databaseInitialized;

        private static ILogger<ExceptionHandler> logger;

        private static LiveViewConnector liveViewConnector;

        private static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();
        
        private static VncServer vncServer;

        private static VideoCaptureServer videoCaptureServer;

        static Program()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            databaseInitialized = DatabaseInitializer.Initialize("LiveViewConnectionString");
        }

        static void Main(string[] args)
        {
            if (!databaseInitialized)
            {
                return;
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            vncServer = Vnc.Start();

            ExceptionHandler.CatchUnhandledExceptions();
            var serviceProvider = ServiceProviderFactory.Create();
            //using (var serviceProvider = ServiceProviderFactory.Create())
            {
                try
                {
                    logger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();
                    ExceptionHandler.SetLogger(logger);

                    var liveViewConnectorLogger = serviceProvider.GetRequiredService<ILogger<LiveViewConnector>>();
                    var displayManager = serviceProvider.GetRequiredService<IDisplayManager>();
                    liveViewConnector = new LiveViewConnector(liveViewConnectorLogger, displayManager);
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

            ConsoleWindow.Hide();

            try
            {
                videoCaptureServer = new VideoCaptureServer(serviceProvider);
                videoCaptureServer.StartAll(liveViewConnector);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }

            var serverIp = AppConfig.GetString(Database.Constants.LiveViewServerIpAddress);
            var serverPort = AppConfig.GetUInt16WithThrowOnError(Database.Constants.LiveViewServerListenerPort);
            if (serverPort != default)
            {
                Task.Run(() => liveViewConnector.ConnectAsync(serverIp, serverPort, vncServer.CommandServer.ListenerPortOfServer, videoCaptureServer.CancellationTokenSource.Token)).Wait();
            }
            else
            {
                var message = $"{Database.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.";
                logger.LogError(message);
                ErrorBox.Show("General error", message);
            }
        }

        private static void OnExit()
        {
            videoCaptureServer.Dispose();
            liveViewConnector.Disconnect();
            Application.Exit();
        }
    }
}