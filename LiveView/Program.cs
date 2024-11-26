using Database.Repositories;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Database;
using System;
using System.Configuration;
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


            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository<>).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["MasterConnectionString"]?.ConnectionString;
            BaseRepository.ExecuteWithoutTransaction("CreateDatabase");
            BaseRepository.ExecuteWithoutTransaction("CreateUser");

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;
            BaseRepository.ExecuteWithoutTransaction("CreateTables");

            var serviceProvider = ServiceProviderFactory.Create();
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}