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
        private readonly GridManagerPresenter presenter;

        public GridManager(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<GridManager> logger, IGridRepository<Grid> gridRepository, FormFactory formFactory)
             : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new GridManagerPresenter(this, generalOptionsRepository, gridRepository, logger, formFactory);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.Delete)]
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteGrid();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        private void BtnNewGrid_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowDialogWithReload<AddGrid>();
        }

        [RequirePermission(GridManagementPermissions.Create | GridManagementPermissions.Update)]
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveUpCamera();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveDownCamera();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ModifyGrid();
        }

        private void GridManager_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }

        private void CbGrids_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SelectGrid();
        }
    }
}
