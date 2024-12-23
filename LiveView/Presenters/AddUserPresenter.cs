using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class AddUserPresenter : BasePresenter
    {
        private IAddUserView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<AddUser> logger;

        public AddUserPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<AddUser> logger)
            : base(generalOptionsRepository)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddUserView;
        }

        public void CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}
