using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class IOPortEditorPresenter
    {
        private readonly IIOPortEditorView ioPortEditorView;
        private readonly IIOPortRepository ioPortRepository;

        public IOPortEditorPresenter(IIOPortEditorView ioPortEditorView, IIOPortRepository ioPortRepository)
        {
            this.ioPortEditorView = ioPortEditorView;
            this.ioPortRepository = ioPortRepository;
        }
    }
}
