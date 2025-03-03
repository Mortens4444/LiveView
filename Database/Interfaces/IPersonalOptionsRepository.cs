using Database.Enums;
using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IPersonalOptionsRepository : IRepository<PersonalOption>
    {
        void ResetCache();

        T Get<T>(Setting settingName, long userId, T defaultValue = default);

        void Set<T>(Setting settingName, long userId, T value);

        string GetCameraName(long userId, Server server, Camera camera);

        string GetCameraName(long userId, string url);
    }
}
