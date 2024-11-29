using AxVIDEOCONTROL4Lib;
using Database.Interfaces;
using Database.Models;
using LanguageService;
using LanguageService.Windows.Forms;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Models.VideoServer;
using LiveView.Presenters;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddCameras : Form, IAddCamerasView, IVideoServerView
    {
        private readonly Server server;
        private readonly bool cameraLicenseRunnedOut;
        private readonly bool isSziltech;
        private readonly PermissionManager permissionManager;

        private readonly AddCamerasPresenter addCamerasPresenter;

        private const int CameraIconIndex = 0;

        public AddCameras(PermissionManager permissionManager, ILogger<AddCameras> logger, ICameraRepository<Camera> cameraRepository, IServerRepository<Server> serverRepository, Server server = null)
        {
            InitializeComponent();
            this.server = server;
            this.permissionManager = permissionManager;
            cameraLicenseRunnedOut = false;

            permissionManager.ApplyPermissionsOnControls(this);

            addCamerasPresenter = new AddCamerasPresenter(this, cameraRepository, serverRepository, logger);

            Translator.Translate(this);
        }

        private void Cb_Servers_SelectedIndexChanged(object sender, EventArgs e)
        {
            addCamerasPresenter.GetCameras();
        }

        private void Lv_CamerasOfServer_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {

        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_AddSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.AddSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_AddAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.AddAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void Btn_RemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.RemoveSelectedCamera();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        private void Btn_RemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addCamerasPresenter.RemoveAllCamera();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_AddCameras_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            addCamerasPresenter.CloseForm();
        }

        private void AddCameras_Shown(object sender, EventArgs e)
        {
            addCamerasPresenter.LoadServers();
        }

        public void AddAllCameras()
        {
            addCamerasPresenter.AddAllCamera();
        }

        public void AddSelectedCamera()
        {
            addCamerasPresenter.AddSelectedCamera();
        }

        public void RemoveAllCamera()
        {
            lv_CamerasToView.Items.Clear();
        }

        public void RemoveSelectedCamera()
        {
            for (int i = lv_CamerasToView.SelectedItems.Count - 1; i >= 0; i--)
            {
                lv_CamerasToView.Items.Remove(lv_CamerasToView.SelectedItems[i]);
            }
        }

        public void LoadServers(ReadOnlyCollection<Server> servers)
        {
            foreach (var server in servers)
            {
                cb_Servers.Items.Add(server);
            }
            cb_Servers.SelectedIndex = 0;
        }

        public AxVideoServer GetVideoServerControl()
        {
            return axVideoServer;
        }

        public void InvokeAction(Action action)
        {
            Invoke(action);
        }

        public async void GetCameras()
        {
            var connectionResult = await VideoServerConnector.ConnectAsync(this, (Server)cb_Servers.SelectedItem);
            if (connectionResult.ErrorCode == VideoServerErrorHandler.Success)
            {
                foreach (var camera in connectionResult.Cameras)
                {
                    var listViewItem = new ListViewItem(camera.Name, CameraIconIndex)
                    {
                        Tag = camera
                    };
                    lv_CamerasOfServer.Items.Add(listViewItem);
                }
            }
            else
            {
                ErrorBox.Show(Lng.Elem("Connection failed"), VideoServerErrorHandler.GetMessage(connectionResult.ErrorCode));
            }
        }

        public ListView.ListViewItemCollection GetServerCameras()
        {
            return lv_CamerasOfServer.Items;
        }

        public ListView.SelectedListViewItemCollection GetServerSelectedCameras()
        {
            return lv_CamerasOfServer.SelectedItems;
        }

        public bool CamerasToViewHasElementWithGuid(string guid)
        {
            return lv_CamerasToView.HasElementWithGuid<VideoServerCamera>(guid);
        }

        public void AddToItemsToView(params ListViewItem[] itemsToView)
        {
            lv_CamerasToView.Items.AddRange(itemsToView);
        }
    }
}
