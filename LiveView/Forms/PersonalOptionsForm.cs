using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class PersonalOptionsForm : Form, IPersonalOptionsView
    {
        private readonly PersonalOptionsPresenter personalOptionsPresenter;

        public PersonalOptionsForm(PermissionManager permissionManager, ILogger<PersonalOptionsForm> logger, IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            personalOptionsPresenter = new PersonalOptionsPresenter(this, personalOptionsRepository, logger);

            Translator.Translate(this);
        }
    }
}
