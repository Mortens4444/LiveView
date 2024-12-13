using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
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

        public GridManager(PermissionManager permissionManager, ILogger<GridManager> logger, IGridRepository<Grid> gridRepository, FormFactory formFactory)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            gridManagerPresenter = new GridManagerPresenter(this, gridRepository, logger, formFactory);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.Delete)]
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            gridManagerPresenter.DeleteGrid();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        private void BtnNewGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            gridManagerPresenter.ShowDialogWithReload<AddGrid>();
        }

        [RequirePermission(GridManagementPermissions.Create | GridManagementPermissions.Update)]
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            gridManagerPresenter.MoveUpCamera();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            gridManagerPresenter.MoveDownCamera();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            gridManagerPresenter.ModifyGrid();
        }

        private void GridManager_Shown(object sender, EventArgs e)
        {
            gridManagerPresenter.Load();
        }

        private void CbGrids_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridManagerPresenter.SelectGrid();
        }
    }
}
