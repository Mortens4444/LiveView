using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class MapCreator : BaseView, IMapCreatorView
    {
        private MapCreatorPresenter presenter;

        public MapCreator(IServiceProvider serviceProvider) : base(serviceProvider, typeof(MapCreatorPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnAddObject_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddObject();
        }

        [RequirePermission(MapManagementPermissions.Delete)]
        private void BtnDeleteMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteMap();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.LoadMapImage();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveMap();
        }

        private void MapCreator_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as MapCreatorPresenter;
        }
    }
}
