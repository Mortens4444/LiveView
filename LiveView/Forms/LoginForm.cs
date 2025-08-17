using Database.Models;
using Database.Services;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LoginForm : BaseView, ILoginFormView
    {
        private LoginFormPresenter presenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User SecondaryUser { get; set; }

        public TextBox TbUsername => tbUsername;

        public PasswordBox TbPassword => tbPassword;

        public LoginForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(LoginFormPresenter))
        {
            InitializeComponent();
            tbPassword.ShowRealPasswordLength = AppConfig.GetBoolean(Database.Constants.ProtectPasswordLength);

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            SecondaryUser = presenter.Login();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as LoginFormPresenter;
        }
    }
}
