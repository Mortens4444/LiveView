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
    public partial class IOPortSettings : Form, IIOPortSettingsView
    {
        private readonly IOPortSettingsPresenter ioPortSettingsPresenter;

        public IOPortSettings(PermissionManager permissionManager, ILogger<IOPortSettings> logger, IIOPortRepository<IOPort> ioPortRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            ioPortSettingsPresenter = new IOPortSettingsPresenter(this, ioPortRepository, logger);

            Translator.Translate(this);
        }
    }
}
