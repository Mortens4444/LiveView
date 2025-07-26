using Database.Interfaces;
using Database.Models;
using Database.Services.PasswordHashers;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using ImageConverter = LiveView.Services.ImageConverter;

namespace LiveView.Presenters
{
    public class ProfilePresenter : BasePresenter
    {
        private IProfileView view;
        private readonly IUserRepository userRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly ILogger<Profile> logger;
        private readonly User user;

        public ProfilePresenter(ProfilePresenterDependencies dependencies)
            : base(dependencies)
        {
            userRepository = dependencies.UserRepository;
            permissionManager = dependencies.PermissionManager;
            logger = dependencies.Logger;
            user = userRepository.Select(permissionManager.CurrentUser.Tag.Id);
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IProfileView;
        }

        public override void Load()
        {
            view.TbUsername.Text = user.Username;
            view.TbFullName.Text = user.FullName;
            view.TbAddress.Text = user.Address;
            view.TbEmailAddress.Text = user.Email;
            view.TbLicensePlate.Text = user.LicensePlate;
            view.TbOtherInformation.Text = user.OtherInformation;
            view.TbTelephoneNumber.Text = user.Phone;
            view.PbPicture.Image = ImageConverter.ByteArrayToImage(user.Image);
        }

        public void Save()
        {
            if (!String.IsNullOrEmpty(view.TbNewPassword.Password))
            {
                if (UserPasswordHasher.Hash(view.TbCurrentPassword.Password) != user.EncryptedPassword)
                {
                    logger.LogWarning(SettingsManagementPermissions.UpdatePersonal, "Profile cannot be changed because the current password is incorrect.");
                    ShowError("The current password does not match.");
                    return;
                }
            }

            user.EncryptedPassword = UserPasswordHasher.Hash(view.TbNewPassword.Password);
            user.FullName = view.TbFullName.Text;
            user.Address = view.TbAddress.Text;
            user.Email = view.TbEmailAddress.Text;
            user.LicensePlate = view.TbLicensePlate.Text;
            user.OtherInformation = view.TbOtherInformation.Text;
            user.Phone = view.TbTelephoneNumber.Text;
            user.Image = ImageConverter.ImageToByteArray(view.PbPicture.Image);
            userRepository.Update(user);
            logger.LogInfo(SettingsManagementPermissions.UpdatePersonal, "Profile has been changed.");
            CloseForm();
        }

        public void SelectProfilePicture()
        {
            if (view.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                view.PbPicture.Image = Image.FromFile(view.OpenFileDialog.FileName);
            }
        }
    }
}
