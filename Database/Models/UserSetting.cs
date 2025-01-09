using System;

namespace Database.Models
{
    public class UserSetting
    {
        public UserSetting(string settingName, long userId)
        {
            SettingName = settingName;
            UserId = userId;
        }

        public string SettingName { get; set; }

        public long UserId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is UserSetting other)
            {
                return String.Equals(SettingName, other.SettingName, StringComparison.Ordinal) && UserId == other.UserId;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (SettingName?.GetHashCode() ?? 0);
                hash = hash * 23 + UserId.GetHashCode();
                return hash;
            }
        }
    }
}
