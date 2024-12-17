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
        private readonly IIOPortEditorView view;
        private readonly IIOPortRepository<IOPort> ioPortRepository;
        private readonly ILogger<IOPortEditor> logger;

        public IOPortEditorPresenter(IIOPortEditorView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IIOPortRepository<IOPort> ioPortRepository, ILogger<IOPortEditor> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.ioPortRepository = ioPortRepository;
            this.logger = logger;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
