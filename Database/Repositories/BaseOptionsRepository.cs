using Database.Enums;
using Database.Models;
using Mtf.Database;
using System;

namespace Database.Repositories;

public abstract class BaseOptionsRepository<TOptionType> : BaseRepository<TOptionType, string>
    where TOptionType : GeneralOption, Mtf.Database.Interfaces.IHasIdentifier<string>
{
    protected BaseOptionsRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
    protected static T GetValue<T>(Setting settingName, TOptionType setting)
    {
        return OptionConversion.GetValue<T>(settingName, setting);
    }

    protected static OptionType GetOptionType<T>(T value)
    {
        return OptionConversion.GetOptionType(value);
    }
}
