using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class EnterPassPresenter
    {
        private readonly IEnterPassView enterPassView;
        private readonly IUserRepository userRepository;

        public EnterPassPresenter(IEnterPassView enterPassView, IUserRepository userRepository)
        {
            this.enterPassView = enterPassView;
            this.userRepository = userRepository;
        }
    }
}
