using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class MotionPopupPresenterDependencies : BasePresenterDependencies
    {
        public MotionPopupPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ILogger<MotionPopup> logger)
            : base(generalOptionsRepository)
        {
            Logger = logger;
        }

        public ILogger<MotionPopup> Logger { get; private set; }
    }
}
