using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddCameras : Form, IAddCamerasView
    {
        private readonly long userId;
        private long serverId;
        private bool cameraLicenseRunnedOut;
        private bool isSziltech;

        public AddCameras(ILogger<AddCameras> logger, long userId, long serverId)
        {
            InitializeComponent();
            this.userId = userId;
            this.serverId = serverId;
            cameraLicenseRunnedOut = false;

            btn_AddCameras.Tag = "Btn_AddCameras_Click";
            Translator.Translate(this);
        }

        private void Cb_ServerDisplayedName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lv_CamerasOfServer_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {

        }

        private void Btn_AddSelected_Click(object sender, EventArgs e)
        {

        }

        private void Btn_AddAll_Click(object sender, EventArgs e)
        {

        }

        private void Btn_RemoveSelected_Click(object sender, EventArgs e)
        {

        }

        private void Btn_RemoveAll_Click(object sender, EventArgs e)
        {

        }

        [RequirePermission(PermissionType.CreateCamera)]
        private void Btn_AddCameras_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
