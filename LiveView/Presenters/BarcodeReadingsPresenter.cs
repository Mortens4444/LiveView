using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class BarcodeReadingsPresenter
    {
        private readonly IBarcodeReadingsView barcodeReadingsView;
        private readonly ICameraRepository cameraRepository;

        public BarcodeReadingsPresenter(IBarcodeReadingsView barcodeReadingsView, ICameraRepository cameraRepository)
        {
            this.barcodeReadingsView = barcodeReadingsView;
            this.cameraRepository = cameraRepository;
        }
    }
}
