using CameraApp.Forms;
using Database.Repositories;
using Mtf.Database;
using Mtf.MessageBoxes;
using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace CameraApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

//#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //#else
            //            ApplicationConfiguration.Initialize();
            //#endif

            BaseRepository.CommandTimeout = 240;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;

            try
            {
                long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                long cameraId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
                long? displayId = args.Length > 2 ? Convert.ToInt64(args[2], CultureInfo.InvariantCulture) : (long?)null;
                using (var form = new FullScreenCamera(userId, cameraId, displayId))
                {
                    Application.Run(form);
                }
            }
            catch (Exception ex)
            {
                ErrorBox.Show(ex);
            }
        }
    }
}