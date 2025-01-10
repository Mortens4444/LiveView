using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MapCreator : BaseView, IMapCreatorView
    {
        private MapCreatorPresenter presenter;

        public Panel PCanvas => pCanvas;

        public MovableSizablePanel PTemplate => pTemplate;

        public ComboBox CbMap => cbMap;

        public RichTextBox RtbComment => rtbComment;

        public ContextMenuStrip CmsObjectMenu => cmsObjectMenu;

        public FolderBrowserDialog FolderBrowserDialog => folderBrowserDialog;

        public MapCreator(IServiceProvider serviceProvider) : base(serviceProvider, typeof(MapCreatorPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnAddObject_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddObject();
        }

        [RequirePermission(MapManagementPermissions.Delete)]
        private void BtnDeleteMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteMap();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.LoadMapImage();
        }

        [RequirePermission(MapManagementPermissions.Update)]
        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveMap();
        }

        private void MapCreator_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as MapCreatorPresenter;
            presenter.Load();
            PTemplate.BackColor = Color.Gold;
        }

        private void PTemplate_MouseDown(object sender, MouseEventArgs e)
        {
            pTemplate.DoDragDrop(pTemplate, DragDropEffects.Move);
        }

        private void PTemplate_MouseUp(object sender, MouseEventArgs e)
        {
            pTemplate.DoDragDrop(pTemplate, DragDropEffects.None);
        }

        private void PCanvas_DragEnter(object sender, DragEventArgs e)
        {
            MapCreatorPresenter.SetDragEffect(e);
        }

        private void PCanvas_DragDrop(object sender, DragEventArgs e)
        {
            presenter.AddObject(e);
        }

        private void CbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SelectMap();
        }
    }
}
