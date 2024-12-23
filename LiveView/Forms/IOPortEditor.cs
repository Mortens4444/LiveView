using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class IOPortEditor : BaseView, IIOPortEditorView
    {
        private IOPortEditorPresenter presenter;

        public IOPortEditor(IServiceProvider serviceProvider) : base(serviceProvider, typeof(IOPortEditorPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(IODeviceManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Save();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void IOPortEditor_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as IOPortEditorPresenter;
        }
    }
}
