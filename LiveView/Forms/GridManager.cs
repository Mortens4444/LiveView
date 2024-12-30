using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class GridManager : BaseView, IGridManagerView
    {
        private GridManagerPresenter presenter;

        public ComboBox CbGrids => cbGrids;

        public ListView LvGridCameras => lvGridCameras;

        public TextBox TbGridName => tbGridName;

        public ToolStripMenuItem TsmiChangeCameraTo => tsmiChangeCameraTo;

        public GridManager(IServiceProvider serviceProvider) : base(serviceProvider, typeof(GridManagerPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);
            
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
            presenter.MoveCamerasUp();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.MoveCamerasDown();
        }

        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ModifyGrid();
        }

        private void GridManager_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as GridManagerPresenter;
            presenter.Load();
        }

        private void CbGrids_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SelectGrid();
        }
    }
}
