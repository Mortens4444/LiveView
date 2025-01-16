using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using System;
using System.ComponentModel;

namespace LiveView.Forms
{
    public partial class LoginForm : BaseView, ILoginFormView
    {
        private LoginFormPresenter presenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User User { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User SecondaryUser { get; set; }

        public LoginForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(LoginFormPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            presenter.Login();
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
