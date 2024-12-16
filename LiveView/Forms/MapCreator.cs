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
    public partial class MapCreator : BaseView, IMapCreatorView
    {
        private readonly MapCreatorPresenter presenter;

        public MapCreator(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<MapCreator> logger, IMapRepository<Map> mapRepository) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new MapCreatorPresenter(this, generalOptionsRepository, mapRepository, logger);
            SetPresenter(presenter);

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
    }
}
