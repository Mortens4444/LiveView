using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class LanguageFileChangedPresenterDependencies : BasePresenterDependencies
    {
        public LanguageFileChangedPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ILogger<LanguageFileChangedForm> logger)
            : base(generalOptionsRepository)
        {
            Logger = logger;
        }

        public ILogger<LanguageFileChangedForm> Logger { get; private set; }
    }
}
