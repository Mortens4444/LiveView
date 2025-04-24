using CameraApp.Services;
using CameraForms.Enums;
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

                    var context = CameraLaunchContextParser.Parse(args);
                    if (context.CameraMode == CameraMode.SunellCamera && (context.StartType != StartType.StartCameraInRectangle && context.StartType != StartType.StartVideoSourceInRectangle))
                    {
                        _ = Sdk.sdk_dev_init(null);
                    }

                    var factory = new CameraWindowFactory();
                    using (var form = factory.Create(context, serviceProvider))
                    {
                        Application.Run(form);
                    }

                    if (context.CameraMode == CameraMode.SunellCamera && (context.StartType != StartType.StartCameraInRectangle && context.StartType != StartType.StartVideoSourceInRectangle))
                    {
                        Sdk.sdk_dev_quit();
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