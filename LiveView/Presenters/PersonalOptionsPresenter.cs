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
using System.Linq;
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
            logger.LogInfo(SettingsManagementPermissions.UpdatePersonal, "Personal settings has been changed.");
        }

        public override void Load()
        {
#if NET481
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
    }
}
