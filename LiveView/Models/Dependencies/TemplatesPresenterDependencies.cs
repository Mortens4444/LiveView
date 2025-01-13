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
            ITemplateProcessRepository templateProcessRepository,
            ILogger<Templates> logger)
            : base(generalOptionsRepository)
        {
            TemplateProcessRepository = templateProcessRepository;
            TemplateRepository = templateRepository;
            Logger = logger;
        }

        public ITemplateProcessRepository TemplateProcessRepository { get; private set; }

        public ITemplateRepository TemplateRepository { get; private set; }
        
        public ILogger<Templates> Logger { get; private set; }
    }
}
