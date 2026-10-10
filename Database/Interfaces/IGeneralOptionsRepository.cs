using Database.Enums;
using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces;

public interface IGeneralOptionsRepository : IRepository<GeneralOption, string>
{
    T Get<T>(Setting settingName, T defaultValue = default);

    void Set<T>(Setting settingName, T value);

    void ResetCache();
}
