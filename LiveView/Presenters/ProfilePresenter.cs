using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;
using System.Drawing.Imaging;

namespace LiveView.Presenters
{
    public class ProfilePresenter : BasePresenter
    {
        private IProfileView view;
        private readonly IUserRepository userRepository;
        private readonly PermissionManager permissionManager;
        private readonly ILogger<Profile> logger;
        private readonly User user;

        public ProfilePresenter(ProfilePresenterDependencies profilePresenterDependencies)
            : base(profilePresenterDependencies)
        {
            userRepository = profilePresenterDependencies.UserRepository;
            permissionManager = profilePresenterDependencies.PermissionManager;
            logger = profilePresenterDependencies.Logger;
            user = userRepository.Select(permissionManager.CurrentUser.Id);
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
            user.FullName = view.TbFullName.Text;
            user.Address = view.TbAddress.Text;
            user.Email = view.TbEmailAddress.Text;
            user.LicensePlate = view.TbLicensePlate.Text;
            user.OtherInformation = view.TbOtherInformation.Text;
            user.Phone = view.TbTelephoneNumber.Text;
            user.Image = ImageConverter.ImageToByteArray(view.PbPicture.Image, ImageFormat.Bmp);
        }

        public void SelectProfilePicture()
        {
            throw new NotImplementedException();
        }
    }
}
