using CameraForms.Dto;
using Database.Enums;
using Database.Interfaces;
using System.Drawing;

namespace CameraForms.Extensions
{
    public static class PersonalOptionsRepositoryExtensions
    {
        public static OsdSettings GetOsdSettings(this IPersonalOptionsRepository personalOptionsRepository, long userId)
        {
            return new OsdSettings
            {
                LargeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30),
                SmallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15),
                FontName = personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial"),
                FontColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb())),
                ShadowColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()))
            };
        }
    }
}
