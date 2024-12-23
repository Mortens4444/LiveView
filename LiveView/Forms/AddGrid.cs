using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class AddGrid : BaseView, IAddGridView
    {
        private AddGridPresenter presenter;

        public AddGrid(IServiceProvider serviceProvider) : base(serviceProvider, typeof(AddGridPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveGrid();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void BtnCombine_Click(object sender, EventArgs e)
        {
            presenter.CombineOnGrid();
        }

        private void BtnTemplate1_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate1Way();
        }

        private void BtnTemplate2_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate4Way();
        }

        private void BtnTemplate3_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate6Way();
        }

        private void BtnTemplate4_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate7Way();
        }

        private void BtnTemplate5_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate8Way();
        }

        private void BtnTemplate6_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate9Way();
        }

        private void BtnTemplate7_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate10Way();
        }

        private void BtnTemplate8_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate16Way();
        }

        private void BtnTemplate9_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate25Way();
        }

        private void BtnTemplate10_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate36Way();
        }

        private void BtnTemplate11_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate49Way();
        }

        private void BtnTemplate12_Click(object sender, EventArgs e)
        {
            presenter.LoadTemplate64Way();
        }

        private void Btn4_3_FixedRight_Click(object sender, EventArgs e)
        {
            presenter.SetHeightForAspect4_3();
        }

        private void Btn16_9_FixedRight_Click(object sender, EventArgs e)
        {
            presenter.SetHeightForAspect16_9();
        }

        private void Btn16_10_FixedRight_Click(object sender, EventArgs e)
        {
            presenter.SetHeightForAspect16_10();
        }

        private void Btn4_3_Click(object sender, EventArgs e)
        {
            presenter.SetWidthForAspect4_3();
        }

        private void Btn16_9_Click(object sender, EventArgs e)
        {
            presenter.SetWidthForAspect16_9();
        }

        private void Btn16_10_Click(object sender, EventArgs e)
        {
            presenter.SetWidthForAspect16_10();
        }

        private void BtnNorthUp_Click(object sender, EventArgs e)
        {
            presenter.AdjustUpperEdgeUpwards();
        }

        private void BtnNorthDown_Click(object sender, EventArgs e)
        {
            presenter.AdjustUpperEdgeDownwards();
        }

        private void BtnWestLeft_Click(object sender, EventArgs e)
        {
            presenter.AdjustLeftEdgeLeftwards();
        }

        private void BtnWestRight_Click(object sender, EventArgs e)
        {
            presenter.AdjustLeftEdgeRightwards();
        }

        private void BtnEastLeft_Click(object sender, EventArgs e)
        {
            presenter.AdjustRightEdgeLeftwards();
        }

        private void BtnEastRight_Click(object sender, EventArgs e)
        {
            presenter.AdjustRightEdgeRightwards();
        }

        private void BtnSouthUp_Click(object sender, EventArgs e)
        {
            presenter.AdjustLowerEdgeUpwards();
        }

        private void BtnSouthDown_Click(object sender, EventArgs e)
        {
            presenter.AdjustLowerEdgeDownwards();
        }

        private void AddGrid_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddGridPresenter;
        }
    }
}
