using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class ControlCenterPresenter
    {
        private readonly IControlCenterView controlCenterView;
        private readonly IDisplayRepository displayRepository;
        private readonly ICameraRepository cameraRepository;

        public ControlCenterPresenter(IControlCenterView controlCenterView, IDisplayRepository displayRepository, ICameraRepository cameraRepository)
        {
            this.controlCenterView = controlCenterView;
            this.displayRepository = displayRepository;
            this.cameraRepository = cameraRepository;
        }
    }
}
