using Database.Enums;
using Database.Interfaces;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Database.Repositories
{
    public sealed class PersonalOptionsRepository : BaseOptionsRepository<PersonalOption>, IPersonalOptionsRepository
    {
        private readonly Dictionary<UserSetting, PersonalOption> cachedUserSettings = new Dictionary<UserSetting, PersonalOption>();

        public void DeletePersonalOptions()
        {
            Execute("DeletePersonalOptions");
        }

        public void ResetCache()
        {
            cachedUserSettings.Clear();
        }

        public T Get<T>(Setting settingName, long userId, T defaultValue = default)
        {
            if (cachedUserSettings.Count == 0)
            {
                var repositorySettings = SelectAll();
                foreach (var repositorySetting in repositorySettings)
                {
                    cachedUserSettings[new UserSetting(repositorySetting.Name, repositorySetting.UserId)] = repositorySetting;
                }
            }

            if (cachedUserSettings.TryGetValue(new UserSetting(settingName.ToString(), userId), out var setting))
            {
                return GetValue<T>(settingName, setting);
            }

            return defaultValue;
        }

        public void Set<T>(Setting settingName, long userId, T value)
        {
            if (cachedUserSettings.Count == 0)
            {
                var repositorySettings = SelectAll();
                foreach (var repositorySetting in repositorySettings)
                {
                    cachedUserSettings[new UserSetting(repositorySetting.Name, repositorySetting.UserId)] = repositorySetting;
                }
            }

            var stringValue = Convert.ToString(value, CultureInfo.InvariantCulture);
            var settingKey = new UserSetting(settingName.ToString(), userId);
            if (cachedUserSettings.TryGetValue(settingKey, out var setting))
            {
                setting.Value = stringValue;
                Update(setting);
            }
            else
            {
                var newSetting = CreateOption(settingName.ToString(), userId, stringValue, value);
                cachedUserSettings[settingKey] = newSetting;
                Insert(newSetting);
            }
        }

        public string GetCameraName(long userId, VideoServer server, Camera camera)
        {
            if (Get(Setting.VideoServerIdentifierDisplayName, userId, true))
            {
                return $"{server.Hostname} - {camera.CameraName}";
            }
            if (Get(Setting.VideoServerIdentifierIpAddress, userId, false))
            {
                return $"{server.IpAddress} - {camera.CameraName}";
            }
            if (Get(Setting.VideoServerIdentifierNone, userId, false))
            {
                return camera.CameraName;
            }

            return String.Empty;
        }

        public string GetCameraName(long userId, string serverIp, string videoSourceName)
        {
            if (Get(Setting.VideoServerIdentifierDisplayName, userId, true))
            {
                return $"{serverIp} - {videoSourceName}";
            }
            if (Get(Setting.VideoServerIdentifierIpAddress, userId, false))
            {
                return $"{serverIp} - {videoSourceName}";
            }
            if (Get(Setting.VideoServerIdentifierNone, userId, false))
            {
                return videoSourceName;
            }

            return String.Empty;
        }

        public string GetCameraName(long userId, string url)
        {
            if (Get(Setting.VideoServerIdentifierDisplayName, userId, true))
            {
                return url;
            }
            if (Get(Setting.VideoServerIdentifierIpAddress, userId, false))
            {
                return url;
            }
            if (Get(Setting.VideoServerIdentifierNone, userId, false))
            {
                return url;
            }

            return String.Empty;
        }

        private PersonalOption CreateOption<T>(string settingName, long userId, string settingValue, T value)
        {
            return new PersonalOption
            {
                Name = settingName.ToString(),
                TypeId = GetOptionType(value),
                Value = settingValue,
                UserId = userId
            };
        }
    }
}
