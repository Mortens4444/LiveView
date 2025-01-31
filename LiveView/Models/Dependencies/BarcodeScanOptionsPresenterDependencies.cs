using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class BarcodeScanOptionsPresenterDependencies : BasePresenterDependencies
    {
        public BarcodeScanOptionsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IBarcodeCharChangerRepository barcodeCharChangerRepository,
            IBarcodeScanOptionsRepository barcodeScanOptionsRepository)
            //ILogger<BarcodeScanOptions> logger)
            : base(generalOptionsRepository)
        {
            BarcodeCharChangerRepository = barcodeCharChangerRepository;
            BarcodeScanOptionsRepository = barcodeScanOptionsRepository;
            //Logger = logger;
        }

        public IBarcodeCharChangerRepository BarcodeCharChangerRepository { get; private set; }

        public IBarcodeScanOptionsRepository BarcodeScanOptionsRepository { get; private set; }
        
        //public ILogger<BarcodeScanOptions> Logger { get; private set; }
    }
}
