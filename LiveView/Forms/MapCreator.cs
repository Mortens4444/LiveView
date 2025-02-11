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

        public OpenFileDialog OpenFileDialog => openFileDialog;

        public ToolStripMenuItem TsmiOpenCamera => tsmiOpenCamera;

        public ToolStripMenuItem TsmiOpenMap => tsmiOpenMap;

        public ImageList IlImages => ilImages;

        public MapCreator(IServiceProvider serviceProvider) : base(serviceProvider, typeof(MapCreatorPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
            Translator.Translate(cmsObjectMenu.Items);
        }

        [RequirePermission(MapManagementPermissions.Select)]
        private void MapCreator_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter = Presenter as MapCreatorPresenter;
            presenter.Load();
            PTemplate.BackColor = Color.Gold;
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

        [RequireAnyPermission(MapManagementPermissions.Create | MapManagementPermissions.Update)]
        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveMap();
            presenter.Load();
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

        private void TsmiDelete_Click(object sender, EventArgs e)
        {
            presenter.DeleteMapObject(sender);
        }

        private void TsmiAddComment_DropDownOpening(object sender, EventArgs e)
        {
            MapCreatorPresenter.LoadCommentFromPanel(sender);
        }

        private void TstComment_Leave(object sender, EventArgs e)
        {
            MapCreatorPresenter.AddCommentToPanel(sender);
        }

        private void TsmiCameraIcon_Click(object sender, EventArgs e)
        {
            presenter.SetCameraIcon(sender);
        }

        private void TsmiMapIcon_Click(object sender, EventArgs e)
        {
            presenter.SetMapIcon(sender);
        }

        private void TsmiBrowse_Click(object sender, EventArgs e)
        {
            presenter.SetCustomImage(sender);
        }

        private void BtnNewMap_Click(object sender, EventArgs e)
        {
            presenter.CreateNewMap();
        }

        private void PCanvas_Resize(object sender, EventArgs e)
        {
            presenter?.CanvasResize();
        }

        private void PCanvas_BackgroundImageChanged(object sender, EventArgs e)
        {
            presenter.SetImageLocationAndSize();
        }
    }
}
