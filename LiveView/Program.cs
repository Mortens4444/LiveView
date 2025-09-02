using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Services;
#if NET462
using System.Data.SqlClient;
#else
using Microsoft.Data.SqlClient;
#endif
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
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

            if (!DatabaseInitializer.Initialize("MasterConnectionString"))
            {
                return;
            }

            try
            {
                DatabaseInitializer.CreateDatabase();
            }
            catch (SqlException ex) when (ex.Number == 26)
            {
                Thread.Sleep(10000);
                ErrorBox.Show(ex);
                Application.Restart();
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