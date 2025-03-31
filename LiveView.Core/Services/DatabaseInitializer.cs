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
                ErrorBox.Show("General error", ex.Message);
            }
            return false;
        }
    }
}
