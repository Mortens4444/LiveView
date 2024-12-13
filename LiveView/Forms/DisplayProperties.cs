using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class DisplayProperties : BaseView, IDisplayPropertiesView
    {
        private readonly DisplayPropertiesPresenter displayPropertiesPresenter;
        private readonly PermissionManager permissionManager;

        public DisplayProperties(PermissionManager permissionManager, ILogger<DisplayProperties> logger, IDisplayRepository<Display> displayRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            displayPropertiesPresenter = new DisplayPropertiesPresenter(this, displayRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void DisplayProperties_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            displayPropertiesPresenter.Load();
        }
    }
}
