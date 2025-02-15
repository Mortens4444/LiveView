using Database.Repositories;
using LiveView.Core.Services.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Database;
using Mtf.MessageBoxes.Exceptions;
using Sequence.Forms;
using Sequence.Services;
using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace Sequence
{
    internal static class Program
    {
        private static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();

        [STAThread]
        static void Main(string[] args)
        {
            //System.Threading.Thread.Sleep(10000);
            ExceptionHandler.CatchUnhandledExceptions();

#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#else
            ApplicationConfiguration.Initialize();
#endif
            BaseRepository.CommandTimeout = 240;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;

            var userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
            var sequenceId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
            var displayId = Convert.ToInt64(args[2], CultureInfo.InvariantCulture);
            var isMdi = Convert.ToBoolean(args[3], CultureInfo.InvariantCulture);

            //_ = Sdk.sdk_dev_init(null);
            using (var serviceProvider = ServiceProviderFactory.Create())
            {
                var exceptionLogger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();
                ExceptionHandler.SetLogger(exceptionLogger);

                using (var form = new MainForm(serviceProvider, userId, sequenceId, displayId, isMdi))
                {
                    Application.Run(form);
                }
            }
            //Sdk.sdk_dev_quit();
        }
    }
}