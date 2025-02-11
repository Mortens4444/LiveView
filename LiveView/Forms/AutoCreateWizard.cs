using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AutoCreateWizard : BaseView, IAutoCreateWizardView
    {
        private AutoCreateWizardPresenter presenter;

        public ListView LeftSide => lvLeftSide;

        public ListView RightSide => lvRightSide;

        public ComboBox CbGrids => cbGrids;

        public CheckBox ChkCreateSequences => chkCreateSequences;

        public ComboBox CbX => cbX;

        public TextBox TbGridNamePrefix => tbGridNamePrefix;

        public TextBox TbGridNamePostfix => tbGridNamePostfix;

        public TextBox TbSequenceNamePrefix => tbSequenceNamePrefix;

        public TextBox TbSequenceNamePostfix => tbSequenceNamePostfix;

        public NumericUpDown NudSecondsToShow => nudSecondsToShow;

        public MtfPictureBox PbCheck => pbCheck;

        public ImageList ImageList => ilImages;

        public AutoCreateWizard(IServiceProvider serviceProvider) : base(serviceProvider, typeof(AutoCreateWizardPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(GridManagementPermissions.Create)]
        [RequirePermission(SequenceManagementPermissions.Create)]
        [RequirePermission(TemplateManagementPermissions.Create)]
        private void BtnAutoCreate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AutoCreate();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            presenter.AddSelected();
        }

        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            presenter.AddAll();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            presenter.RemoveSelected();
        }

        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            presenter.RemoveAll();
        }

        private void AutoCreateWizard_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AutoCreateWizardPresenter;
            presenter.Load();
        }

        private void CbGrids_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.AfterItemCountChange();
    }
    }
}
