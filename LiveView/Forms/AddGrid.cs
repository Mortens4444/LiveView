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
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            addGridPresenter.CloseForm();
        }

        private void Btn_Combine_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template3_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template4_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template5_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template6_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template7_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template8_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template9_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template10_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template11_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Template12_Click(object sender, EventArgs e)
        {

        }

        private void Btn_4_3_FixedRight_Click(object sender, EventArgs e)
        {

        }

        private void Btn_16_9_FixedRight_Click(object sender, EventArgs e)
        {

        }

        private void Btn_16_10_FixedRight_Click(object sender, EventArgs e)
        {

        }
    }
}
