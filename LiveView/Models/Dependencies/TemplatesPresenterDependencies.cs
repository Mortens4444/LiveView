using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class TemplatesPresenterDependencies : BasePresenterDependencies
    {
        public TemplatesPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ITemplateRepository templateRepository,
            ILogger<Templates> logger)
            : base(generalOptionsRepository)
        {
            TemplateRepository = templateRepository;
            Logger = logger;
        }

        public ITemplateRepository TemplateRepository { get; private set; }
        
        public ILogger<Templates> Logger { get; private set; }
    }
}
