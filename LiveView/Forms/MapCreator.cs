using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MapCreator : Form, IMapCreatorView
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
        private void Btn_AddObject_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(MapManagementPermissions.Delete)]
        private void Btn_DeleteMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void Btn_LoadImage_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void Btn_SaveMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}
