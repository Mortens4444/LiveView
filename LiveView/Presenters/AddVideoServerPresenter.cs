using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class AddVideoServerPresenter
    {
        private readonly IAddVideoServerView addVideoServerView;
        private readonly IServerRepository serverRepository;

        public AddVideoServerPresenter(IAddVideoServerView addVideoServerView, IServerRepository serverRepository)
        {
            this.addVideoServerView = addVideoServerView;
            this.serverRepository = serverRepository;
        }
    }
}
