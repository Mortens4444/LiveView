using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class SequentialChainsPresenter
    {
        private readonly ISequentialChainsView sequentialChainsView;
        private readonly ICameraRepository cameraRepository;

        public SequentialChainsPresenter(ISequentialChainsView sequentialChainsView, ICameraRepository cameraRepository)
        {
            this.sequentialChainsView = sequentialChainsView;
            this.cameraRepository = cameraRepository;
        }
    }
}
