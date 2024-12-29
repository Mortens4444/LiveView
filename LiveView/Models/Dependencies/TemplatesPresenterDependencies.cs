using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class TemplatesPresenterDependencies : BasePresenterDependencies
    {
        public TemplatesPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            ITemplateRepository<Template> templateRepository,
            ILogger<Templates> logger)
            : base(generalOptionsRepository)
        {
            TemplateRepository = templateRepository;
            Logger = logger;
        }

        public ITemplateRepository<Template> TemplateRepository { get; private set; }
        
        public ILogger<Templates> Logger { get; private set; }
    }
}
