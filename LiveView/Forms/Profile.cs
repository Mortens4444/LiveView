using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class Profile : BaseView, IProfileView
    {
        private ProfilePresenter presenter;

        public TextBox TbFullName => tbFullName;

        public TextBox TbAddress => tbAddress;

        public TextBox TbEmailAddress => tbEmailAddress;

        public TextBox TbTelephoneNumber => tbTelephoneNumber;

        public TextBox TbLicensePlate => tbLicensePlate;

        public TextBox TbOtherInformation => tbOtherInformation;

        public TextBox TbUsername => tbUsername;

        public TextBox TbNewPassword => tbNewPassword;

        public ComboBox CbSizeMode => cbSizeMode;

        public PictureBox PbPicture => pbPicture;

        public OpenFileDialog OpenFileDialog => throw new NotImplementedException();

        public Profile(IServiceProvider serviceProvider) : base(serviceProvider, typeof(ProfilePresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(UserManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Save();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(UserManagementPermissions.Update)]
        private void BtnSelectPicture_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SelectProfilePicture();
        }

        private void Profile_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as ProfilePresenter;
            presenter.Load();
        }
    }
}
