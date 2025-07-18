using Database.Repositories;
using Mtf.Database;
using System;
using System.Configuration;

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
    }
}
