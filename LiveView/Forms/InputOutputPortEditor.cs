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
    public partial class InputOutputPortEditor : BaseView, IInputOutputPortEditorView
    {
        private InputOutputPortEditorPresenter presenter;
        
        public InputOutputPort InputOutputPort { get; }

        public TextBox TbFriendlyName => tbFriendlyName;

        public NumericUpDown NudMinTriggerTime => nudMinTriggerTime;

        public NumericUpDown NudMaxSignalPerDay => nudMaxSignalPerDay;

        public InputOutputPortEditor(IServiceProvider serviceProvider, InputOutputPort inputOutputPort) : base(serviceProvider, typeof(InputOutputPortEditorPresenter))
        {
            InitializeComponent();
            InputOutputPort = inputOutputPort;

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

        private void InputOutputPortEditor_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as InputOutputPortEditorPresenter;
            presenter.Load();
        }
    }
}
