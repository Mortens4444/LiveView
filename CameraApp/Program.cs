using CameraApp.Services;
using CameraForms.Enums;
using Database.Enums;
using Database.Services;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using System;
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
            if (AppConfig.GetBoolean(LiveView.Core.Constants.AttachDebugger))
            {
                Debugger.Launch();
            }
            var waitTime = AppConfig.GetInt32(LiveView.Core.Constants.WaitAtStartup);
            Thread.Sleep(waitTime);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            ExceptionHandler.CatchUnhandledExceptions();
            Console.WriteLine($"Camera app started with args: {String.Join(" ", args)}");

            try
            {
                //#if NETFRAMEWORK
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                //#else
                //  ApplicationConfiguration.Initialize();
                //#endif

                if (!DatabaseInitializer.Initialize("LiveViewConnectionString"))
                {
                    return;
                }

                var serviceProvider = ServiceProviderFactory.Create();
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
            catch (Exception ex)
            {
                logger.LogException(ex, "CameraApp start error.");
                ErrorBox.Show(ex);
            }
        }
    }
}