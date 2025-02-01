using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class IOPortEditor : BaseView, IIOPortEditorView
    {
        private IOPortEditorPresenter presenter;
        
        public IOPort IOPort { get; }

        public TextBox TbFriendlyName => tbFriendlyName;

        public NumericUpDown NudMinTriggerTime => nudMinTriggerTime;

        public NumericUpDown NudMaxSignalPerDay => nudMaxSignalPerDay;

        public IOPortEditor(IServiceProvider serviceProvider, IOPort ioPort) : base(serviceProvider, typeof(IOPortEditorPresenter))
        {
            InitializeComponent();
            IOPort = ioPort;

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
            presenter.Load();
        }
    }
}
