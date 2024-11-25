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
    public partial class DisplayOptions : Form, IDisplayOptionsView
    {
        private readonly DisplayOptionsPresenter displayOptionsPresenter;

        public DisplayOptions(PermissionManager permissionManager, ILogger<DisplayOptions> logger, IDisplayRepository<Display> displayRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            displayOptionsPresenter = new DisplayOptionsPresenter(this, displayRepository, logger);

            Translator.Translate(this);
        }
    }
}
