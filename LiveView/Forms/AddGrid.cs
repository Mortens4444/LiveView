using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls.x86;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddGrid : BaseView, IAddGridView
    {
        private AddGridPresenter presenter;

        public NumericUpDown NudNumberOfRows => nudNumberOfRows;

        public NumericUpDown NudNumberOfColumns => nudNumberOfColumns;

        public NumericUpDown NudPixelsFromRight => nudPixelsFromRight;

        public NumericUpDown NudPixelsFromBottom => nudPixelsFromBottom;

        public NumericUpDown NudInitialRow => nudInitialRow;

        public NumericUpDown NudClosingRow => nudClosingRow;

        public NumericUpDown NudInitialColumn => nudInitialColumn;

        public NumericUpDown NudClosingColumn => nudClosingColumn;

        public ComboBox CbDisplays => cbDisplays;

        public ComboBox CbGrids => cbGrids;

        public TextBox TbGridName => tbGridName;

        public ToolStripStatusLabel TsslNumberOfCameras => tsslNumberOfCameras;

        public Panel PMain => pMain;

        public Panel PMiniDesign => pMiniDesign;

        public CheckBox ChkConnectToCamera => chkConnectToCamera;

        public bool IsVideoConnected => axVideoPlayerWindow.AxVideoPicture.IsConnected();

        public AxVideoPlayerWindow AxVideoPlayerWindow => axVideoPlayerWindow;

        public AddGrid(IServiceProvider serviceProvider) : base(serviceProvider, typeof(AddGridPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        private void AddGrid_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddGridPresenter;
            presenter.Load();
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(GridManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveGrid();
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

        private void CbDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.DisplaySelected();
        }

        private void NudPixelsFromBottom_ValueChanged(object sender, EventArgs e)
        {
            presenter.SetBottomBorder();
        }

        private void NudPixelsFromRight_ValueChanged(object sender, EventArgs e)
        {
            presenter.SetRightBorder();
        }

        private void MiniDesign_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                presenter.DrawMiniDesign(e.Graphics);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void PMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                presenter.DrawGrid(e.Graphics);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void CbGrids_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.LoadGrid();
        }

        private void PEditor_Resize(object sender, EventArgs e)
        {
            pEditor.Invalidate();
        }

        private void NudNumberOfRows_ValueChanged(object sender, EventArgs e)
        {
            presenter.CalculateMetrics();
        }

        private void NudNumberOfColumns_ValueChanged(object sender, EventArgs e)
        {
            presenter.CalculateMetrics();
        }

        private void PEditor_LocationChanged(object sender, EventArgs e)
        {
            Invalidate(true);
            PMiniDesign.Invalidate(true);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}
