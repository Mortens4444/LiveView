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
    public partial class AddGrid : BaseView, IAddGridView
    {
        private readonly AddGridPresenter addGridPresenter;
        private readonly PermissionManager permissionManager;

        public AddGrid(PermissionManager permissionManager, ILogger<AddGrid> logger, IGridRepository<Grid> gridRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            addGridPresenter = new AddGridPresenter(this, gridRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGridPresenter.SaveGrid();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            addGridPresenter.CloseForm();
        }

        private void BtnCombine_Click(object sender, EventArgs e)
        {
            addGridPresenter.CombineOnGrid();
        }

        private void BtnTemplate1_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate1Way();
        }

        private void BtnTemplate2_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate4Way();
        }

        private void BtnTemplate3_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate6Way();
        }

        private void BtnTemplate4_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate7Way();
        }

        private void BtnTemplate5_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate8Way();
        }

        private void BtnTemplate6_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate9Way();
        }

        private void BtnTemplate7_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate10Way();
        }

        private void BtnTemplate8_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate16Way();
        }

        private void BtnTemplate9_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate25Way();
        }

        private void BtnTemplate10_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate36Way();
        }

        private void BtnTemplate11_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate49Way();
        }

        private void BtnTemplate12_Click(object sender, EventArgs e)
        {
            addGridPresenter.LoadTemplate64Way();
        }

        private void Btn4_3_FixedRight_Click(object sender, EventArgs e)
        {
            addGridPresenter.SetHeightForAspect4_3();
        }

        private void Btn16_9_FixedRight_Click(object sender, EventArgs e)
        {
            addGridPresenter.SetHeightForAspect16_9();
        }

        private void Btn16_10_FixedRight_Click(object sender, EventArgs e)
        {
            addGridPresenter.SetHeightForAspect16_10();
        }

        private void Btn4_3_Click(object sender, EventArgs e)
        {
            addGridPresenter.SetWidthForAspect4_3();
        }

        private void Btn16_9_Click(object sender, EventArgs e)
        {
            addGridPresenter.SetWidthForAspect16_9();
        }

        private void Btn16_10_Click(object sender, EventArgs e)
        {
            addGridPresenter.SetWidthForAspect16_10();
        }

        private void BtnNorthUp_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustUpperEdgeUpwards();
        }

        private void BtnNorthDown_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustUpperEdgeDownwards();
        }

        private void BtnWestLeft_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustLeftEdgeLeftwards();
        }

        private void BtnWestRight_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustLeftEdgeRightwards();
        }

        private void BtnEastLeft_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustRightEdgeLeftwards();
        }

        private void BtnEastRight_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustRightEdgeRightwards();
        }

        private void BtnSouthUp_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustLowerEdgeUpwards();
        }

        private void BtnSouthDown_Click(object sender, EventArgs e)
        {
            addGridPresenter.AdjustLowerEdgeDownwards();
        }
    }
}
