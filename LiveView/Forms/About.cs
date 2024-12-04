using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class About : BaseView
    {
        private readonly PermissionManager permissionManager;

        public About(PermissionManager permissionManager)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;
            lblProductName.Text = Application.ProductName;
            lblVersion.Text = Application.ProductVersion.Substring(0, Application.ProductVersion.IndexOf('+'));
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
    }
}
