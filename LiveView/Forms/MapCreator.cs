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
        private readonly MapCreatorPresenter mapCreatorPresenter;
        private readonly PermissionManager permissionManager;

        public MapCreator(PermissionManager permissionManager, ILogger<MapCreator> logger, IMapRepository<Map> mapRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            mapCreatorPresenter = new MapCreatorPresenter(this, mapRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnAddObject_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mapCreatorPresenter.AddObject();
        }

        [RequirePermission(MapManagementPermissions.Delete)]
        private void BtnDeleteMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mapCreatorPresenter.DeleteMap();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mapCreatorPresenter.LoadMapImage();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            mapCreatorPresenter.SaveMap();
        }
    }
}
