using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Database;
using System;
using System.Windows.Forms;

namespace LiveView
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

//#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//#else
//            ApplicationConfiguration.Initialize();
//#endif

            BaseRepository.ScriptsToExecute.Add("CreateDatabase");

            var serviceProvider = ServiceProviderFactory.Create();
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}