using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class About : Form
    {
        private readonly PermissionManager permissionManager;

        public About(PermissionManager permissionManager)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;
            lbl_ProductName.Text = Application.ProductName;
            lbl_Version.Text = Application.ProductVersion.Substring(0, Application.ProductVersion.IndexOf('+'));
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        [RequirePermission(GeneralPermissions.OpenLink)]
        private void EmailAddress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            permissionManager.EnsurePermissions();
            Process.Start(String.Concat("mailto:", ll_EmailAddress.Text));
        }

        [RequirePermission(GeneralPermissions.OpenLink)]
        private void WebPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            permissionManager.EnsurePermissions();
            Process.Start(ll_WebPage.Text);
        }
    }
}
