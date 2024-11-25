using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class EnterPassPresenter : BasePresenter
    {
        private readonly IEnterPassView enterPassView;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<EnterPass> logger;

        public EnterPassPresenter(IEnterPassView enterPassView, IUserRepository<User> userRepository, ILogger<EnterPass> logger)
            : base(enterPassView)
        {
            this.enterPassView = enterPassView;
            this.userRepository = userRepository;
            this.logger = logger;
        }
    }
}
