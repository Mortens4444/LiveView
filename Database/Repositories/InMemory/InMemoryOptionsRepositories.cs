using Database.Enums;
using Database.Interfaces;
using Database.Models;
using System;
using System.Globalization;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryGeneralOptionsRepository : InMemoryRepository<GeneralOption, string>, IGeneralOptionsRepository
{
    protected override bool UsesIdentity => false;

    public void ResetCache()
    {
        // Nothing is cached, the in-memory rows are always current.
    }

    public T Get<T>(Setting settingName, T defaultValue = default)
    {
        lock (SyncRoot)
        {
            var setting = Items.FirstOrDefault(option => option.Name == settingName.ToString());
            return setting == null ? defaultValue : OptionConversion.GetValue<T>(settingName, setting);
        }
    }

    public void Set<T>(Setting settingName, T value)
    {
        var stringValue = Convert.ToString(value, CultureInfo.InvariantCulture);
        lock (SyncRoot)
        {
            var setting = Items.FirstOrDefault(option => option.Name == settingName.ToString());
            if (setting != null)
            {
                setting.Value = stringValue;
                return;
            }

            Insert(new GeneralOption
            {
                Name = settingName.ToString(),
                TypeId = OptionConversion.GetOptionType(value),
                Value = stringValue
            });
        }
    }
}

public sealed class InMemoryPersonalOptionsRepository : InMemoryRepository<PersonalOption, string>, IPersonalOptionsRepository
{
    protected override bool UsesIdentity => false;

    /// <summary>A personal option is identified by its name and its owner.</summary>
    protected override bool SameRow(PersonalOption left, PersonalOption right)
    {
        return left.Name == right.Name && left.UserId == right.UserId;
    }

    public void ResetCache()
    {
        // Nothing is cached, the in-memory rows are always current.
    }

    public T Get<T>(Setting settingName, long userId, T defaultValue = default)
    {
        lock (SyncRoot)
        {
            var setting = Items.FirstOrDefault(option => option.Name == settingName.ToString() && option.UserId == userId);
            return setting == null ? defaultValue : OptionConversion.GetValue<T>(settingName, setting);
        }
    }

    public void Set<T>(Setting settingName, long userId, T value)
    {
        var stringValue = Convert.ToString(value, CultureInfo.InvariantCulture);
        lock (SyncRoot)
        {
            var setting = Items.FirstOrDefault(option => option.Name == settingName.ToString() && option.UserId == userId);
            if (setting != null)
            {
                setting.Value = stringValue;
                return;
            }

            Insert(new PersonalOption
            {
                Name = settingName.ToString(),
                TypeId = OptionConversion.GetOptionType(value),
                Value = stringValue,
                UserId = userId
            });
        }
    }

    public string GetCameraName(long userId, VideoServer server, Camera camera)
    {
        return GetCameraName(userId, $"{server.Hostname} - {camera.CameraName}", $"{server.IpAddress} - {camera.CameraName}", camera.CameraName);
    }

    public string GetCameraName(long userId, string serverIp, string videoSourceName)
    {
        return GetCameraName(userId, $"{serverIp} - {videoSourceName}", $"{serverIp} - {videoSourceName}", videoSourceName);
    }

    public string GetCameraName(long userId, string url)
    {
        return GetCameraName(userId, url, url, url);
    }

    private string GetCameraName(long userId, string displayNameFormat, string ipAddressFormat, string noneFormat)
    {
        if (Get(Setting.VideoServerIdentifierDisplayName, userId, true))
        {
            return displayNameFormat;
        }

        if (Get(Setting.VideoServerIdentifierIpAddress, userId, false))
        {
            return ipAddressFormat;
        }

        if (Get(Setting.VideoServerIdentifierNone, userId, false))
        {
            return noneFormat;
        }

        return String.Empty;
    }
}
