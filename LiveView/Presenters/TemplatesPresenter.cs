using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class TemplatesPresenter : BasePresenter
    {
        private ITemplatesView view;
        private readonly ITemplateRepository templateRepository;
        private readonly ILogger<Templates> logger;

        public TemplatesPresenter(TemplatesPresenterDependencies templatesPresenterDependencies)
            : base(templatesPresenterDependencies)
        {
            templateRepository = templatesPresenterDependencies.TemplateRepository;
            logger = templatesPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ITemplatesView;
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
