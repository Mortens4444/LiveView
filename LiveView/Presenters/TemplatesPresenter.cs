using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class TemplatesPresenter : BasePresenter
    {
        private readonly ITemplatesView view;
        private readonly ITemplateRepository<Template> templateRepository;
        private readonly ILogger<Templates> logger;

        public TemplatesPresenter(ITemplatesView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ITemplateRepository<Template> templateRepository, ILogger<Templates> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.templateRepository = templateRepository;
            this.logger = logger;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
