using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class ControlCenterPresenter : BasePresenter
    {
        private readonly IControlCenterView controlCenterView;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ITemplateRepository<Template> templateRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ControlCenter> logger;

        public ControlCenterPresenter(IControlCenterView controlCenterView, ITemplateRepository<Template> templateRepository, IDisplayRepository<Display> displayRepository, ICameraRepository<Camera> cameraRepository, ILogger<ControlCenter> logger)
            : base(controlCenterView)
        {
            this.controlCenterView = controlCenterView;
            this.templateRepository = templateRepository;
            this.displayRepository = displayRepository;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }
    }
}
