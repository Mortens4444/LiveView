using Database.Repositories;
using Mtf.Database;
using Mtf.MessageBoxes;
using System;
using System.Configuration;

namespace LiveView.Core.Services
{
    public static class DatabaseInitializer
    {
        public static bool Initialize(string connectionStringName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.ConnectionStrings.SectionInformation.IsProtected)
            {
                config.ConnectionStrings.SectionInformation.UnprotectSection();
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }

            BaseRepository.CommandTimeout = 240;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";
            try
            {
                BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName]?.ConnectionString;
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                ErrorBox.Show("General error", ex.Message);
            }
            return false;
        }
    }
}
