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
        private IEnterPassView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<EnterPass> logger;

        public EnterPassPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<EnterPass> logger)
            : base(generalOptionsRepository)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IEnterPassView;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}
