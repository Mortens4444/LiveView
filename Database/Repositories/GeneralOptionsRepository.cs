using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System;
using System.Collections.Generic;

namespace Database.Repositories
{
    public sealed class GeneralOptionsRepository : BaseRepository<GeneralOption>, IGeneralOptionsRepository
    {
        private readonly Dictionary<string, GeneralOption> cachedSettings = new Dictionary<string, GeneralOption>();

        public void ResetCache()
        {
            cachedSettings.Clear();
        }

        public T Get<T>(Setting settingName, T defaultValue = default)
        {
            if (cachedSettings.Count == 0)
            {
                var repositorySettings = SelectAll();
                foreach (var repositorySetting in repositorySettings)
                {
                    cachedSettings[repositorySetting.Name] = repositorySetting;
                }
            }

            if (cachedSettings.TryGetValue(settingName.ToString(), out var setting))
            {
                try
                {
                    switch (setting.TypeId)
                    {
                        case OptionType.Bool:
                        case OptionType.Float:
                        case OptionType.Int32:
                        case OptionType.Int64:
                        case OptionType.String:
                            return (T)Convert.ChangeType(setting.Value, typeof(T));
                        default:
                            throw new NotImplementedException();
                    }
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException($"The value for setting '{settingName}' cannot be converted to type {typeof(T).Name}.");
                }
            }

            return defaultValue;
        }

        public void Set<T>(Setting settingName, T value)
        {
            if (cachedSettings.Count == 0)
            {
                var repositorySettings = SelectAll();
                foreach (var repositorySetting in repositorySettings)
                {
                    cachedSettings[repositorySetting.Name] = repositorySetting;
                }
            }

            var stringValue = Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
            if (cachedSettings.TryGetValue(settingName.ToString(), out var setting))
            {
                setting.Value = stringValue;
                Update(setting);
            }
            else
            {
                var newSetting = new GeneralOption
                {
                    Name = settingName.ToString(),
                    TypeId = GetOptionType(value),
                    Value = stringValue
                };

                cachedSettings[settingName.ToString()] = newSetting;
                Insert(newSetting);
            }
        }

        private OptionType GetOptionType<T>(T value)
        {
            if (value is bool) return OptionType.Bool;
            if (value is float) return OptionType.Float;
            if (value is int) return OptionType.Int32;
            if (value is long) return OptionType.Int64;
            if (value is string) return OptionType.String;

            throw new NotSupportedException($"Unsupported type: {typeof(T).Name}");
        }
    }
}
