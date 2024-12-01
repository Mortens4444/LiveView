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

namespace LiveView.Forms
{
    public partial class GridManager : BaseView, IGridManagerView
    {
        private readonly GridManagerPresenter gridManagerPresenter;
        private readonly PermissionManager permissionManager;

        public GridManager(PermissionManager permissionManager, ILogger<GridManager> logger, IGridRepository<Grid> gridRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            gridManagerPresenter = new GridManagerPresenter(this, gridRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.Delete)]
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        private void Btn_NewGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Create | GridManagementPermissions.Update)]
        private void Btn_MoveUp_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void Btn_MoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}
