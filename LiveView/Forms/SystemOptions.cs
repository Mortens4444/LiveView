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
    public partial class SystemOptions : Form, ISystemOptionsView
    {
        private readonly SystemOptionsPresenter systemOptionsPresenter;

        public SystemOptions(PermissionManager permissionManager, ILogger<SystemOptions> logger, IOptionsRepository<Options> optionsRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            systemOptionsPresenter = new SystemOptionsPresenter(this, optionsRepository, logger);

            Translator.Translate(this);
        }
    }
}
