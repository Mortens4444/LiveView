using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Database;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace LiveView
{
    internal static class Program
    {
        public static ExceptionHandler ExceptionHandler { get; } = new ExceptionHandler();

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
            //ApplicationConfiguration.Initialize();
            //#endif

            BaseRepository.CommandTimeout = 240;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["MasterConnectionString"]?.ConnectionString;
            BaseRepository.ExecuteWithoutTransaction("CreateDatabase");
            BaseRepository.ExecuteWithoutTransaction("CreateUser");

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;
            BaseRepository.Execute("CreateTables");
            var migrationsToExecute = new string[] { "MigrationAddConstraints", "MigrationRenameTables", "MigrationRenameColumns",
                "MigrationDropChecksums", "InsertInitialData", "MigrationData", "MigrationDropDisplaysTableColumns",
                /*"MigrationRenameConstraints"*/ };

            var migrationRepository = new MigrationRepository();
            var migrations = migrationRepository.SelectAll();
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
            ExceptionHandler.SetLogger(serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>());

            var displayRepository = serviceProvider.GetRequiredService<IDisplayRepository>();
            var displays = displayRepository.SelectAll();

            var displayManager = new DisplayManager();
            var currentDisplays = displayManager.GetAll();

            //DeleteDiplaysFromRepository(displayRepository, displays, currentDisplays);
            InsertOrUpdateDisplay(displayRepository, displays, currentDisplays);

            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }

        private static void InsertOrUpdateDisplay(IDisplayRepository displayRepository, ReadOnlyCollection<Display> displays, List<DisplayDto> currentDisplays)
        {
            foreach (var display in currentDisplays)
            {
                displayRepository.Insert(display.ToModel());
            }
        }

        private static void DeleteDiplaysFromRepository(IDisplayRepository displayRepository, ReadOnlyCollection<Display> displays, List<DisplayDto> currentDisplays)
        {
            foreach (var display in displays)
            {
                if (currentDisplays.FirstOrDefault(d => !d.IsRemote && d.GetId() == display.Id) == null)
                {
                    displayRepository.Delete(display.Id);
                }
            }
        }
    }
}