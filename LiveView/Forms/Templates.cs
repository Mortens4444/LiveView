using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class Templates : BaseView, ITemplatesView
    {
        private TemplatesPresenter presenter;

        public ListView LvTemplates => lvTemplates;

        public TextBox TbTemplateName => tbTemplateName;

        public Templates(IServiceProvider serviceProvider) : base(serviceProvider, typeof(TemplatesPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(TemplateManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Save();
        }

        [RequirePermission(TemplateManagementPermissions.Delete)]
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Delete();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void Templates_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as TemplatesPresenter;
            presenter.Load();
        }
    }
}
