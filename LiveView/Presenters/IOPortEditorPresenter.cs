using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class IOPortEditorPresenter : BasePresenter
    {
        private IIOPortEditorView view;
        private readonly IIOPortRepository<IOPort> ioPortRepository;
        private readonly ILogger<IOPortEditor> logger;

        public IOPortEditorPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IIOPortRepository<IOPort> ioPortRepository, ILogger<IOPortEditor> logger)
            : base(generalOptionsRepository)
        {
            this.ioPortRepository = ioPortRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IIOPortEditorView;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
