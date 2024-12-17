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
        private readonly IProfileView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<Profile> logger;

        public ProfilePresenter(IProfileView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<Profile> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
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
