using Database.Models;
using Database.Repositories;
using Database.Repositories.InMemory;
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
        public static string ConnectionString { get; set; }

        /// <summary>
        /// True when the application runs without a database: every repository keeps its data in memory
        /// (see <see cref="UseInMemoryStorage"/>) and nothing is saved when the application exits.
        /// </summary>
        public static bool IsInMemoryStorage { get; private set; }

        /// <summary>
        /// Switches to in-memory repositories and loads the built-in data (users, groups, ...) that a new database would contain.
        /// Call it before the service provider is created, because the repositories are registered based on <see cref="IsInMemoryStorage"/>.
        /// </summary>
        public static void UseInMemoryStorage()
        {
            IsInMemoryStorage = true;
            InMemoryDataSeeder.Seed();
        }

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
                ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName]?.ConnectionString;
                return ConnectionString != null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }
        }

        public static void CreateDatabase()
        {
            new Mtf.Database.BaseRepository(ConnectionString).ExecuteWithoutTransaction("CreateDatabase");
            Mtf.Database.BaseRepository.CommandTimeout = 150;
            new Mtf.Database.BaseRepository(ConnectionString).ExecuteWithoutTransaction("CreateUser");
            ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;
            new Mtf.Database.BaseRepository(ConnectionString).Execute("CreateTables");
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
                            SziltechUserName = UserPasswordHasher.UsernameEncrypt("Sziltech"),
                            AdminUserName = UserPasswordHasher.UsernameEncrypt("admin")
                        }
                    }
                };

            var repository = new Mtf.Database.BaseRepository(ConnectionString);
            var migrationRepository = new MigrationRepository();
            var migrations = migrationRepository.SelectAll();
            foreach (var migrationToExecute in migrationsToExecute)
            {
                if (!migrations.Any(migration => migration.Name == migrationToExecute))
                {
                    if (migrationParams.TryGetValue(migrationToExecute, out var value))
                    {
                        repository.Execute(migrationToExecute, value);
                    }
                    else
                    {
                        repository.Execute(migrationToExecute);
                    }
                    migrationRepository.Insert(new Migration { Name = migrationToExecute });
                }
            }
        }
    }
}
