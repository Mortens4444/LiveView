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
    public partial class GeneralOptionsForm : Form, IGeneralOptionsView
    {
        private readonly GeneralOptionsPresenter generalOptionsPresenter;

        public GeneralOptionsForm(PermissionManager permissionManager, ILogger<GeneralOptionsForm> logger, IGeneralOptionsRepository<GeneralOptions> generalOptionsRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            generalOptionsPresenter = new GeneralOptionsPresenter(this, generalOptionsRepository, logger);

            Translator.Translate(this);
        }
    }
}
