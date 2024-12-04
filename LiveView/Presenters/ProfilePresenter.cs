using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class ProfilePresenter : BasePresenter
    {
        private readonly IProfileView profileView;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<Profile> logger;

        public ProfilePresenter(IProfileView profileView, IUserRepository<User> userRepository, ILogger<Profile> logger)
            : base(profileView)
        {
            this.profileView = profileView;
            this.userRepository = userRepository;
            this.logger = logger;
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
