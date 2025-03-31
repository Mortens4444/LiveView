using Database.Enums;
using Database.Interfaces;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Language = Mtf.LanguageService.Enums.Language;

namespace LiveView.Presenters
{
    public class PersonalOptionsPresenter : BasePresenter
    {
        private IPersonalOptionsView view;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly ILogger<PersonalOptionsForm> logger;
        private readonly PermissionManager<Database.Models.User> permissionManager;

        public PersonalOptionsPresenter(PersonalOptionsPresenterDependencies dependencies)
            : base(dependencies)
        {
            permissionManager = dependencies.PermissionManager;
            personalOptionsRepository = dependencies.PersonalOptionsRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IPersonalOptionsView;
        }

        public void SaveSettings()
        {
            personalOptionsRepository.Set(Setting.Language, permissionManager.CurrentUser.Tag.Id, view.CbLanguages.SelectedIndex);
            personalOptionsRepository.Set(Setting.UseCustomControlColors, permissionManager.CurrentUser.Tag.Id, view.ChkUseCustomColors.Checked);
            personalOptionsRepository.Set(Setting.VideoServerIdentifierDisplayName, permissionManager.CurrentUser.Tag.Id, view.RbDisplayedName.Checked);
            personalOptionsRepository.Set(Setting.VideoServerIdentifierIpAddress, permissionManager.CurrentUser.Tag.Id, view.RbIpAddress.Checked);
            personalOptionsRepository.Set(Setting.VideoServerIdentifierNone, permissionManager.CurrentUser.Tag.Id, view.RbNone.Checked);
            personalOptionsRepository.Set(Setting.CameraFont, permissionManager.CurrentUser.Tag.Id, view.LblTest.Font.FontFamily.Name);
            personalOptionsRepository.Set(Setting.CameraLargeFontSize, permissionManager.CurrentUser.Tag.Id, (int)view.NudLargeFontSize.Value);
            personalOptionsRepository.Set(Setting.CameraSmallFontSize, permissionManager.CurrentUser.Tag.Id, (int)view.NudSmallFontSize.Value);
            personalOptionsRepository.Set(Setting.CameraFontColor, permissionManager.CurrentUser.Tag.Id, view.PbFontColor.BackColor.ToArgb());
            personalOptionsRepository.Set(Setting.CameraFontShadowColor, permissionManager.CurrentUser.Tag.Id, view.PbFontShadowColor.BackColor.ToArgb());

            logger.LogInfo(SettingsManagementPermissions.UpdatePersonal, "Personal settings has been changed.");
        }

        public override void Load()
        {
#if NET462 || NET48 || NET481
            var languages = Enum.GetValues(typeof(ImplementedLanguage))
                .Cast<ImplementedLanguage>()
                .Select(language => $"{language} ({language.GetDescription()})");
#else
            var languages = Enum.GetValues<ImplementedLanguage>()
                .Select(language => $"{language} ({language.GetDescription()})");
#endif

            view.AddItems(view.CbLanguages, languages);
            int selectedLanguage = personalOptionsRepository.Get(Setting.Language, permissionManager.CurrentUser.Tag.Id, Constants.HungarianLanguageIndex);
            view.SelectByIndex(view.CbLanguages, selectedLanguage);
            
            view.ChkUseCustomColors.Checked = personalOptionsRepository.Get(Setting.UseCustomControlColors, permissionManager.CurrentUser.Tag.Id, false);

            view.RbDisplayedName.Checked = personalOptionsRepository.Get(Setting.VideoServerIdentifierDisplayName, permissionManager.CurrentUser.Tag.Id, true);
            view.RbIpAddress.Checked = personalOptionsRepository.Get(Setting.VideoServerIdentifierIpAddress, permissionManager.CurrentUser.Tag.Id, false);
            view.RbNone.Checked = personalOptionsRepository.Get(Setting.VideoServerIdentifierNone, permissionManager.CurrentUser.Tag.Id, false);

            view.LblTest.Font = new Font(personalOptionsRepository.Get(Setting.CameraFont, permissionManager.CurrentUser.Tag.Id, "Arial"), view.LblTest.Font.SizeInPoints);
            view.NudLargeFontSize.Value = personalOptionsRepository.Get(Setting.CameraLargeFontSize, permissionManager.CurrentUser.Tag.Id, 30);
            view.NudSmallFontSize.Value = personalOptionsRepository.Get(Setting.CameraSmallFontSize, permissionManager.CurrentUser.Tag.Id, 15);
            view.PbFontColor.BackColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, permissionManager.CurrentUser.Tag.Id, Color.White.ToArgb()));
            view.PbFontShadowColor.BackColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, permissionManager.CurrentUser.Tag.Id, Color.Black.ToArgb()));
        }

        public void ChangeLanguage()
        {
            var selectedItem = view.CbLanguages.SelectedItem?.ToString();
            if (!String.IsNullOrEmpty(selectedItem))
            {
                var lngParts = selectedItem.Split(' ');
                var languageEnum = EnumExtensions.GetFromDescription<Language>(lngParts[0]);
                Lng.DefaultLanguage = languageEnum;
                view.SetOriginalTexts();
                Translator.Translate(view.GetSelf());
                view.CbLanguages.SelectedItem = selectedItem;
            }
        }

        public void ChangeCameraFont()
        {
            if (view.FdFontPicker.ShowDialog() == DialogResult.OK)
            {
                view.LblTest.Font = view.FdFontPicker.Font;
            }
        }

        public void ChangeFontColor()
        {
            if (view.CdColorPicker.ShowDialog() == DialogResult.OK)
            {
                view.PbFontColor.BackColor = view.CdColorPicker.Color;
            }
        }

        public void ChangeFontShadowColor()
        {
            if (view.CdColorPicker.ShowDialog() == DialogResult.OK)
            {
                view.PbFontShadowColor.BackColor = view.CdColorPicker.Color;
            }
        }
    }
}
