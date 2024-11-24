using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class TemplatesPresenter
    {
        private readonly ITemplatesView templatesView;
        private readonly ITemplateRepository templateRepository;

        public TemplatesPresenter(ITemplatesView templatesView, ITemplateRepository templateRepository)
        {
            this.templatesView = templatesView;
            this.templateRepository = templateRepository;
        }
    }
}
