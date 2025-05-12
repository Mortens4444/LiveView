using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Services;
#if NET462
using System.Data.SqlClient;
#else
using Microsoft.Data.SqlClient;
#endif
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Database;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Database.Services;

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

#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#else
            ApplicationConfiguration.Initialize();
#endif

            if (!DatabaseInitializer.Initialize("MasterConnectionString"))
            {
                return;
            }

            try
            {
                BaseRepository.ExecuteWithoutTransaction("CreateDatabase");
            }
            catch (SqlException ex) when (ex.Number == 26)
            {
                Thread.Sleep(10000);
                ErrorBox.Show(ex);
                Application.Restart();
            }
            
            BaseRepository.ExecuteWithoutTransaction("CreateUser");

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;
            BaseRepository.Execute("CreateTables");
            var migrationsToExecute = new string[] { "MigrationAddConstraints", "MigrationRenameTables", "MigrationRenameColumns",
                "MigrationDropChecksums", "InsertInitialData", "MigrationData", "MigrationDropDisplaysTableColumns", "MigrationRestructureGridCameras",
                "MigrationExtendGridName", "MigrationExtendSequenceName", "MigrationAlterTableOperation", "MigrationDropLogsTableColumn",
                "MigrationAlterTableGridCameras", "MigrationUpdateGridCameras", "MigrationUpdateCamerasHttpStreamUrlLength", "MigrationAlterTableDisplays",
                "MigrationAlterTableCameras", "MigrationAlterTableTemplateProcesses", "MigrationAlterTableCamerasAddPermissionCameraColumn",
                "MigrationAlterTableCamerasFillPermissionCameraColumn" };

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
            //using (var serviceProvider = ServiceProviderFactory.Create())
            {
                var exceptionLogger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();

                ExceptionHandler.SetLogger(exceptionLogger);

                FillOrUpdateDisplaysTable(serviceProvider);
                FillOperationsTable(serviceProvider);

                Application.Run(serviceProvider.GetRequiredService<MainForm>());
            }
        }

        private static void FillOrUpdateDisplaysTable(IServiceProvider serviceProvider)
        {
            var displayRepository = serviceProvider.GetRequiredService<IDisplayRepository>();
            var displays = displayRepository.SelectAll();

            var displayManager = new DisplayManager();
            var currentDisplays = displayManager.GetAll();

            //DeleteDiplaysFromRepository(displayRepository, displays, currentDisplays);
            InsertOrUpdateDisplay(displayRepository, displays, currentDisplays);
        }

        private static void FillOperationsTable(IServiceProvider serviceProvider)
        {
            var operationRepository = serviceProvider.GetRequiredService<IOperationRepository>();
            if (!operationRepository.HasAnyRow())
            {
                var enums = PermissionEnumProviders.Get();
                foreach (var enumType in enums)
                {
                    foreach (var value in EnumExtensions.GetIndividualValues(enumType))
                    {
                        var valueStr = value.ToString();
                        var operation = new Operation
                        {
                            Id = UniqueIdGenerator.Get(String.Concat(enumType.Name, valueStr)),
                            PermissionGroup = enumType.Name,
                            PermissionValue = valueStr
                        };
                        operationRepository.Insert(operation);
                    }
                }
            }
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