using Database.Enums;
using Database.Interfaces;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Database.Repositories
{
    public sealed class GeneralOptionsRepository : BaseOptionsRepository<GeneralOption>, IGeneralOptionsRepository
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
                return GetValue<T>(settingName, setting);
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

            var stringValue = Convert.ToString(value, CultureInfo.InvariantCulture);
            if (cachedSettings.TryGetValue(settingName.ToString(), out var setting))
            {
                setting.Value = stringValue;
                Update(setting);
            }
            else
            {
                var newSetting = CreateOption(settingName.ToString(), stringValue, value);
                cachedSettings[settingName.ToString()] = newSetting;
                Insert(newSetting);
            }
        }

        private GeneralOption CreateOption<T>(string settingName, string settingValue, T value)
        {
            return new GeneralOption
            {
                Name = settingName.ToString(),
                TypeId = GetOptionType(value),
                Value = settingValue
            };
        }
    }
}
