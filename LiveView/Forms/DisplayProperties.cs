using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

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
    }
}
