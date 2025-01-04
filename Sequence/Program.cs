using Database.Repositories;
using Mtf.Database;
using Sequence.Forms;
using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace Sequence
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
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
            using (var form = new MainForm(userId, sequenceId, displayId, isMdi))
            {
                Application.Run(form);
            }
        }
    }
}