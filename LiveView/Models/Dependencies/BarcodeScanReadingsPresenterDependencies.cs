using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class BarcodeScanReadingsPresenterDependencies : BasePresenterDependencies
    {
        public BarcodeScanReadingsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IBarcodeScanReadingRepository barcodeScanReadingRepository,
            ILogger<BarcodeReadings> logger)
            : base(generalOptionsRepository)
        {
            BarcodeScanReadingRepository = barcodeScanReadingRepository;
            Logger = logger;
        }

        public IBarcodeScanReadingRepository BarcodeScanReadingRepository { get; private set; }
        
        public ILogger<BarcodeReadings> Logger { get; private set; }
    }
}
