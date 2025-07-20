using Database.Models;
using Database.Repositories;
using Database.Services.PasswordHashers;
using Mtf.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Database.Services
{
    public static class DatabaseInitializer
    {
        public static bool Initialize(string connectionStringName)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.ConnectionStrings.SectionInformation.IsProtected)
                {
                    config.ConnectionStrings.SectionInformation.UnprotectSection();
                    //config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                }

                BaseRepository.CommandTimeout = 600;
                BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
                BaseRepository.DatabaseScriptsLocation = "Database.Scripts";
                BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName]?.ConnectionString;
                return BaseRepository.ConnectionString != null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }
        }

        public static void CreateDatabase()
        {
            BaseRepository.ExecuteWithoutTransaction("CreateDatabase");
            BaseRepository.CommandTimeout = 150;
            BaseRepository.ExecuteWithoutTransaction("CreateUser");
            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;
            BaseRepository.Execute("CreateTables");
            Migrate();
        }

        private static void Migrate()
        {
            const string insertInitialData = "InsertInitialData";
            var migrationsToExecute = new string[] { insertInitialData };
            var migrationParams = new Dictionary<string, object>
                {
                    {
                        insertInitialData,
                        new
                        {
                            SziltechUserName = UserPasswordHasher.Encrypt("Sziltech"),
                            AdminUserName = UserPasswordHasher.Encrypt("admin")
                        }
                    }
                };

            var migrationRepository = new MigrationRepository();
            var migrations = migrationRepository.SelectAll();
            foreach (var migrationToExecute in migrationsToExecute)
            {
                if (!migrations.Any(migration => migration.Name == migrationToExecute))
                {
                    if (migrationParams.ContainsKey(migrationToExecute))
                    {
                        BaseRepository.Execute(migrationToExecute, migrationParams[migrationToExecute]);
                    }
                    else
                    {
                        BaseRepository.Execute(migrationToExecute);
                    }
                    migrationRepository.Insert(new Migration { Name = migrationToExecute });
                }
            }
        }
    }
}
