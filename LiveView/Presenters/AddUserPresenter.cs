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
        private readonly IAddUserView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<AddUser> logger;

        public AddUserPresenter(IAddUserView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<AddUser> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public void CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}
