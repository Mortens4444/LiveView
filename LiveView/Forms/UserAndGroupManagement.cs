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
    public partial class UserAndGroupManagement : BaseView, IUserAndGroupManagementView
    {
        private UserAndGroupManagementPresenter presenter;

        public Button BtnNewGroup => btnNewGroup;

        public Button BtnNewUser => btnNewUser;

        public Button BtnModify => btnModify;

        public Button BtnRemove => btnRemove;

        public TreeView TvUsersAndGroups => tvUsersAndGroups;

        public UserAndGroupManagement(IServiceProvider serviceProvider) : base(serviceProvider, typeof(UserAndGroupManagementPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(GroupManagementPermissions.Select)]
        [RequirePermission(UserManagementPermissions.Select)]
        private void UserAndGroupManagement_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter = Presenter as UserAndGroupManagementPresenter;
            presenter.Load();
        }

        [RequirePermission(GroupManagementPermissions.Create)]
        private void BtnNewGroup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            if (TvUsersAndGroups.SelectedNode.Tag is Group parentGroup)
            {
                presenter.ShowDialogWithReload<AddGroup>(parentGroup);
            }
            else
            {
                presenter.ShowError("Groups can only be added within other groups.");
            }
        }

        [RequirePermission(UserManagementPermissions.Create)]
        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddUser();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Modify();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Delete();
        }

        private void TvUsersAndGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            presenter?.ChangeButtonStates(e.Node);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}
