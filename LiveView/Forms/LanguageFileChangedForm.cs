using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LanguageFileChangedForm : BaseView, ILanguageFileChangedView
    {
        private LanguageFileChangedPresenter presenter;

        public LanguageFileChangedForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(LanguageFileChangedPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        public CheckBox ChkDoNotShowAgain => chkDoNotShowAgain;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            presenter.AcknowledgeLanguageFileModification();
        }

        private void LanguageFileChangedForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as LanguageFileChangedPresenter;
            presenter.Load();
        }

        private void BtnRestoreOriginal_Click(object sender, EventArgs e)
        {
            presenter.RestoreOriginalLanguageFile();
        }
    }
}
