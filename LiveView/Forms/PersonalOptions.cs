using Database.Interfaces;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class PersonalOptions : Form, IPersonalOptionsView
    {
        private readonly PersonalOptionsPresenter personalOptionsPresenter;

        public PersonalOptions(PermissionManager permissionManager, ILogger<PersonalOptions> logger, IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            personalOptionsPresenter = new PersonalOptionsPresenter(this, personalOptionsRepository, logger);

            Translator.Translate(this);
        }
    }
}
