using Database.Models;
using Database.Repositories;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Database;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.Configuration;
using System.Linq;
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
            ExceptionHandler.CatchUnhandledExceptions();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //#else
            //            ApplicationConfiguration.Initialize();
            //#endif

            BaseRepository.CommandTimeout = 240;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository<>).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["MasterConnectionString"]?.ConnectionString;
            BaseRepository.ExecuteWithoutTransaction("CreateDatabase");
            BaseRepository.ExecuteWithoutTransaction("CreateUser");

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;
            BaseRepository.Execute("CreateTables");
            var migrationsToExecute = new string[] { "MigrationAddConstraints", "MigrationRenameTables", "MigrationRenameColumns",
                "MigrationDropChecksums", "InsertInitialData", "MigrationData" /*"MigrationRenameConstraints"*/ };

            var migrationRepository = new MigrationRepository<Migration>();
            var migrations = migrationRepository.GetAll();
            foreach (var migrationToExecute in migrationsToExecute)
            {
                if (!migrations.Any(migration => migration.Name == migrationToExecute))
                {
                    BaseRepository.Execute(migrationToExecute);
                    migrationRepository.Insert(new Migration { Name = migrationToExecute });
                }
            }

            LiveViewTranslator.Translate();

            var serviceProvider = ServiceProviderFactory.Create();
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}