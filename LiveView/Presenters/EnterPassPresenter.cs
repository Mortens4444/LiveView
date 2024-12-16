using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class EnterPassPresenter : BasePresenter
    {
        private readonly IEnterPassView enterPassView;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<EnterPass> logger;

        public EnterPassPresenter(IEnterPassView enterPassView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<EnterPass> logger)
            : base(enterPassView, generalOptionsRepository)
        {
            this.enterPassView = enterPassView;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}
