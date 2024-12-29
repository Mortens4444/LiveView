using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class ProfilePresenter : BasePresenter
    {
        private IProfileView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<Profile> logger;

        public ProfilePresenter(ProfilePresenterDependencies profilePresenterDependencies)
            : base(profilePresenterDependencies)
        {
            userRepository = profilePresenterDependencies.UserRepository;
            logger = profilePresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IProfileView;
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SelectProfilePicture()
        {
            throw new NotImplementedException();
        }
    }
}
