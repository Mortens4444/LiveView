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
        private readonly DisplayPropertiesPresenter presenter;

        public DisplayProperties(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<DisplayProperties> logger, IDisplayRepository<Display> displayRepository) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new DisplayPropertiesPresenter(this, generalOptionsRepository, displayRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void DisplayProperties_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Load();
        }
    }
}
