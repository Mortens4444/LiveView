using Database.Repositories;
using Mtf.Database;
using System.Configuration;

namespace LiveView.Core.Services
{
    public static class DatabaseInitializer
    {
        public static void Initialize(string connectionStringName)
        {
            BaseRepository.CommandTimeout = 240;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";
            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName]?.ConnectionString;
        }
    }
}
