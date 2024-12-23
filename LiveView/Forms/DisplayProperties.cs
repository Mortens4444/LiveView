using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class DisplayProperties : BaseView, IDisplayPropertiesView
    {
        private DisplayPropertiesPresenter presenter;

        public DisplayProperties(IServiceProvider serviceProvider) : base(serviceProvider, typeof(DisplayPropertiesPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void DisplayProperties_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as DisplayPropertiesPresenter;
            permissionManager.EnsurePermissions();
            presenter.Load();
        }
    }
}
