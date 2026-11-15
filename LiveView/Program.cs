using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Database.Services;
using Mtf.Extensions;
using LiveView.Core.Interfaces;

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
            ExceptionHandler.ShowDebugInfo(AppConfig.GetBoolean(Database.Constants.ShowDebugInfo));
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("hu-HU");
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("hu-HU");

#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#else
            ApplicationConfiguration.Initialize();
#endif

            if (!TryInitializeDatabase())
            {
                DatabaseInitializer.UseInMemoryStorage();
            }

            LiveViewTranslator.Translate();

            var serviceProvider = ServiceProviderFactory.Create();
            //using (var serviceProvider = ServiceProviderFactory.Create())
            {
                var exceptionLogger = serviceProvider.GetRequiredService<ILogger<ExceptionHandler>>();

                ExceptionHandler.SetLogger(exceptionLogger);

                FillOrUpdateDisplaysTable(serviceProvider);
                FillOperationsTable(serviceProvider);

                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                if (DatabaseInitializer.IsInMemoryStorage)
                {
                    mainForm.Text += " - IN-MEMORY MODE (data is not saved)";
                }

                Application.Run(mainForm);
            }
        }

        /// <summary>
        /// Connects to the database and creates it if needed. When that is not possible the user is warned
        /// and the caller falls back to the in-memory storage, so the application can still be started.
        /// </summary>
        private static bool TryInitializeDatabase()
        {
            string reason;
            try
            {
                if (DatabaseInitializer.Initialize("MasterConnectionString"))
                {
                    DatabaseInitializer.CreateDatabase();
                    return true;
                }

                reason = "The 'MasterConnectionString' connection string is not configured.";
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                reason = ex.GetBaseException().Message;
            }

            MessageBox.Show(
                $"The database is not available:{Environment.NewLine}{reason}{Environment.NewLine}{Environment.NewLine}" +
                "The application starts with temporary in-memory storage. Everything you create or change (users, cameras, grids, options, logs) " +
                "is kept only while the application is running and is lost when it is closed." + Environment.NewLine + Environment.NewLine +
                "To use the database, fix the connection strings (or start the SQL Server) and restart the application.",
                "LiveView - Database not available",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }

        private static void FillOrUpdateDisplaysTable(IServiceProvider serviceProvider)
        {
            var displayRepository = serviceProvider.GetRequiredService<IDisplayRepository>();
            var displays = displayRepository.SelectAll();

            var displayManager = serviceProvider.GetRequiredService<IDisplayManager>();
            var currentDisplays = displayManager.GetAll();

            //DeleteDisplaysFromRepository(displayRepository, displays, currentDisplays);
            InsertOrUpdateDisplay(displayRepository, displays, currentDisplays);
        }

        private static void FillOperationsTable(IServiceProvider serviceProvider)
        {
            var operationRepository = serviceProvider.GetRequiredService<IOperationRepository>();
            var permissionRepository = serviceProvider.GetRequiredService<IPermissionRepository>();
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
                        permissionRepository.Insert(new Permission
                        {
                            OperationId = operation.Id,
                            GroupId = 1,
                            UserEventId = 1,
                        });
                        permissionRepository.Insert(new Permission
                        {
                            OperationId = operation.Id,
                            GroupId = 2,
                            UserEventId = 1,
                        });
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

        private static void DeleteDisplaysFromRepository(IDisplayRepository displayRepository, ReadOnlyCollection<Display> displays, List<DisplayDto> currentDisplays)
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