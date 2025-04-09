using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.MessageBoxes.Exceptions;
using Sequence.Forms;
using Sequence.Services;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Sequence
{
    internal static class Program
    {
        private static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();

        [STAThread]
        static void Main(string[] args)
        {
            if (Boolean.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.AttachDebugger], out var attach) && attach)
            {
                Debugger.Launch();
            }
            if (Int32.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.WaitAtStartup], out var waitTime))
            {
                Thread.Sleep(waitTime);
            }

            ExceptionHandler.CatchUnhandledExceptions();

#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#else
            ApplicationConfiguration.Initialize();
#endif
            if (!DatabaseInitializer.Initialize("LiveViewConnectionString"))
            {
                return;
            }

            var userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
            var sequenceId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
            var displayId = Convert.ToInt64(args[2], CultureInfo.InvariantCulture);
            var isMdi = Convert.ToBoolean(args[3], CultureInfo.InvariantCulture);

            _ = Sdk.sdk_dev_init(null);

            var serviceProvider = ServiceProviderFactory.Create();
            //using (var serviceProvider = ServiceProviderFactory.Create())
            {
                var exceptionLogger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();
                ExceptionHandler.SetLogger(exceptionLogger);

                using (var form = new MainForm(serviceProvider, userId, sequenceId, displayId, isMdi))
                {
                    Application.Run(form);
                }
            }
            Sdk.sdk_dev_quit();
        }
    }
}