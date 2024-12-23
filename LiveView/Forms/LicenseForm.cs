using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LicenseForm : BaseView, ILicenseFormView
    {
        private LicenseFormPresenter presenter;

        public LicenseForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(LicenseFormPresenter))
        {
            InitializeComponent();

            Translator.Translate(this);
        }

        public Label LblLicenseStatusResult => lblLicenseStatusResult;

        public Label LblId => lblId;

        public Label LblUsersMaxPerAct => lblUsersMaxPerAct;

        public Label LblValidatedServersMaxPerAct => lblValidatedServersMaxPerAct;

        public Label LblValidatedCamerasMaxPerAct => lblValidatedCamerasMaxPerAct;

        public Label LblNotValidatedServersMaxPerAct => lblNotValidatedServersMaxPerAct;

        public Label LblNotValidatedCamerasMaxPerAct => lblNotValidatedCamerasMaxPerAct;

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            presenter.Upgrade();
        }

        private void LicenseForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as LicenseFormPresenter;
            presenter.Load();
        }
    }
}
