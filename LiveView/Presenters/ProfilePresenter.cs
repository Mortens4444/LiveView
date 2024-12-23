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
        private IProfileView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<Profile> logger;

        public ProfilePresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<Profile> logger)
            : base(generalOptionsRepository)
        {
            this.userRepository = userRepository;
            this.logger = logger;
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
