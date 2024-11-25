using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private readonly IMainView mainView;
        private readonly ILogger<MainForm> logger;

        public MainPresenter(FormFactory formFactory, IMainView mainView, ILogger<MainForm> logger)
            : base(mainView, formFactory)
        {
            this.mainView = mainView;
            this.logger = logger;
        }
    }
}
