using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class KBD300ASimulatorPresenter : BasePresenter
    {
        private IKBD300ASimulatorView view;
        private readonly ILogger<KBD300ASimulator> logger;

        public KBD300ASimulatorPresenter(KBD300ASimulatorPresenterDependencies kBD300ASimulatorPresenterDependencies)
            : base(kBD300ASimulatorPresenterDependencies)
        {
            logger = kBD300ASimulatorPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IKBD300ASimulatorView;
        }
    }
}
