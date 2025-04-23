using CameraApp.Services;
using CameraForms.Forms;
using Database.Enums;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CameraApp
{
    internal static class Program
    {
        public static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();

        private static ILogger<ExceptionHandler> logger;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (Boolean.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.AttachDebugger], out var attach) && attach)
            {
                Debugger.Launch();
            }
            if (Int32.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.WaitAtStartup], out var waitTime))
            {
                Thread.Sleep(waitTime);
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            ExceptionHandler.CatchUnhandledExceptions();
            Console.WriteLine($"Camera app started with args: {String.Join(" ", args)}");

            try
            {
                //#if NETFRAMEWORK
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //#else
                //            ApplicationConfiguration.Initialize();
                //#endif

                if (!DatabaseInitializer.Initialize("LiveViewConnectionString"))
                {
                    return;
                }

                //InfoBox.Show("Camera app started", $"{String.Join(" ", args)}");

                var serviceProvider = ServiceProviderFactory.Create();
                //using (var serviceProvider = ServiceProviderFactory.Create())
                {
                    logger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();
                    ExceptionHandler.SetLogger(logger);

                    if (args.Length == 3)
                    {
                        long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                        long cameraId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
                        var cameraMode = (CameraMode)Convert.ToInt32(args[2], CultureInfo.InvariantCulture);
                        switch (cameraMode)
                        {
                            case CameraMode.AxVideoPlayer:
                                using (var form = new AxVideoCameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.SunellLegacyCamera:
                                using (var form = new SunellLegacyCameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.SunellCamera:
                                _ = Sdk.sdk_dev_init(null);
                                using (var form = new SunellCameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                Sdk.sdk_dev_quit();
                                break;
                            case CameraMode.MortoGraphy:
                                using (var form = new MortoGraphyCameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.FFMpeg:
                                using (var form = new FFMpegCameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.OpenCvSharp:
                                using (var form = new OpenCvSharpCameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.OpenCvSharp4:
                                using (var form = new OpenCvSharp4CameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.Vlc:
                                using (var form = new VlcCameraWindow(serviceProvider, userId, cameraId, null))
                                {
                                    Application.Run(form);
                                }
                                break;
                            default:
                                throw new NotSupportedException($"{cameraMode} is not supported.");
                        }
                    }
                    if (args.Length == 4)
                    {
                        long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                        var cameraMode = (CameraMode)Convert.ToInt32(args[3], CultureInfo.InvariantCulture);

                        if (Int64.TryParse(args[1], out var cameraId))
                        {
                            long? displayId = Convert.ToInt64(args[2], CultureInfo.InvariantCulture);

                            switch (cameraMode)
                            {
                                case CameraMode.AxVideoPlayer:
                                    using (var form = new AxVideoCameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                case CameraMode.SunellLegacyCamera:
                                    using (var form = new SunellLegacyCameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                case CameraMode.SunellCamera:
                                    _ = Sdk.sdk_dev_init(null);
                                    using (var form = new SunellCameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    Sdk.sdk_dev_quit();
                                    break;
                                case CameraMode.MortoGraphy:
                                    using (var form = new MortoGraphyCameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                case CameraMode.FFMpeg:
                                    using (var form = new FFMpegCameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                case CameraMode.OpenCvSharp:
                                    using (var form = new OpenCvSharpCameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                case CameraMode.OpenCvSharp4:
                                    using (var form = new OpenCvSharp4CameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                case CameraMode.Vlc:
                                    using (var form = new VlcCameraWindow(serviceProvider, userId, cameraId, displayId))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                default:
                                    throw new NotSupportedException($"{cameraMode} is not supported.");
                            }
                        }
                        else
                        {
                            switch (cameraMode)
                            {
                                case CameraMode.VideoSource:
                                    var serverIp = args[1];
                                    var videoCaptureSource = args[2];

                                    using (var form = new VideoSourceCameraWindow(serviceProvider, userId, serverIp, videoCaptureSource, null))
                                    {
                                        Application.Run(form);
                                    }
                                    break;
                                default:
                                    throw new NotSupportedException($"{cameraMode} is not supported.");
                            }
                        }
                    }
                    else if (args.Length == 5)
                    {
                        long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                        var serverIp = args[1];
                        var videoCaptureSource = args[2];
                        long? displayId = Convert.ToInt64(args[3], CultureInfo.InvariantCulture);
                        var cameraMode = (CameraMode)Convert.ToInt32(args[4], CultureInfo.InvariantCulture);

                        switch (cameraMode)
                        {
                            case CameraMode.VideoSource:
                                using (var form = new VideoSourceCameraWindow(serviceProvider, userId, serverIp, videoCaptureSource, displayId))
                                {
                                    Application.Run(form);
                                }
                                break;
                            default:
                                throw new NotSupportedException($"{cameraMode} is not supported.");
                        }
                    }
                    else if (args.Length == 7)
                    {
                        long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                        long cameraId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
                        int x = Convert.ToInt32(args[2], CultureInfo.InvariantCulture);
                        int y = Convert.ToInt32(args[3], CultureInfo.InvariantCulture);
                        int width = Convert.ToInt32(args[4], CultureInfo.InvariantCulture);
                        int height = Convert.ToInt32(args[5], CultureInfo.InvariantCulture);
                        var cameraMode = (CameraMode)Convert.ToInt32(args[6], CultureInfo.InvariantCulture);
                        var rectangle = new Rectangle(new Point(x, y), new Size(width, height));

                        switch (cameraMode)
                        {
                            case CameraMode.AxVideoPlayer:
                                using (var form = new AxVideoCameraWindow(serviceProvider, userId, cameraId, new Point(x, y), new Size(width, height)))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.SunellLegacyCamera:
                                using (var form = new SunellLegacyCameraWindow(serviceProvider, userId, cameraId, rectangle))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.SunellCamera:
                                _ = Sdk.sdk_dev_init(null);
                                using (var form = new SunellCameraWindow(serviceProvider, userId, cameraId, rectangle))
                                {
                                    Application.Run(form);
                                }
                                Sdk.sdk_dev_quit();
                                break;
                            case CameraMode.MortoGraphy:
                                using (var form = new MortoGraphyCameraWindow(serviceProvider, userId, cameraId, rectangle))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.FFMpeg:
                                using (var form = new FFMpegCameraWindow(serviceProvider, userId, cameraId, rectangle))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.OpenCvSharp:
                                using (var form = new OpenCvSharpCameraWindow(serviceProvider, userId, cameraId, rectangle))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.OpenCvSharp4:
                                using (var form = new OpenCvSharp4CameraWindow(serviceProvider, userId, cameraId, rectangle))
                                {
                                    Application.Run(form);
                                }
                                break;
                            case CameraMode.Vlc:
                                using (var form = new VlcCameraWindow(serviceProvider, userId, cameraId, rectangle))
                                {
                                    Application.Run(form);
                                }
                                break;
                            default:
                                throw new NotSupportedException($"{cameraMode} is not supported.");
                        }
                    }
                    else if (args.Length == 8)
                    {
                        long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                        var serverIp = args[1];
                        var videoCaptureSource = args[2];
                        int x = Convert.ToInt32(args[3], CultureInfo.InvariantCulture);
                        int y = Convert.ToInt32(args[4], CultureInfo.InvariantCulture);
                        int width = Convert.ToInt32(args[5], CultureInfo.InvariantCulture);
                        int height = Convert.ToInt32(args[6], CultureInfo.InvariantCulture);
                        var cameraMode = (CameraMode)Convert.ToInt32(args[7], CultureInfo.InvariantCulture);
                        long cameraId;

                        switch (cameraMode)
                        {
                            case CameraMode.VideoSource:
                                using (var form = new VideoSourceCameraWindow(serviceProvider, userId, serverIp, videoCaptureSource, new Point(x, y), new Size(width, height)))
                                {
                                    Application.Run(form);
                                }
                                break;
                            default:
                                throw new NotSupportedException($"{cameraMode} is not supported.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if NET462
                logger?.LogError($"CameraApp start error: {ex}");
#else
                logger?.LogError(ex, "CameraApp start error.");
#endif
                ErrorBox.Show(ex);
            }
        }
    }
}