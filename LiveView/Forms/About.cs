using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class About : BaseView
    {
        public About(IServiceProvider serviceProvider) : base(serviceProvider, typeof(BasePresenter))
        {
            InitializeComponent();
            canBeClosedAlways = true;

            lblProductName.Text = Application.ProductName;
            lblVersion.Text = Application.ProductVersion.Substring(0, Application.ProductVersion.IndexOf('+'));

            Translator.Translate(this);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        [RequirePermission(GeneralPermissions.OpenLink)]
        private void EmailAddress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            permissionManager.EnsurePermissions();
            Process.Start(String.Concat("mailto:", llEmailAddress.Text));
        }

        [RequirePermission(GeneralPermissions.OpenLink)]
        private void WebPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            permissionManager.EnsurePermissions();
            Process.Start(llWebPage.Text);
        }

        private void About_Load(object sender, EventArgs e)
        {
            pbLogo.BackColor = Color.WhiteSmoke;
        }
    }
}
