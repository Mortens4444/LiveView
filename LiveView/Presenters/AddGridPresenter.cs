using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class AddGridPresenter
    {
        private readonly IAddGridView addGridView;
        private readonly IGridRepository gridRepository;

        public AddGridPresenter(IAddGridView addGridView, IGridRepository gridRepository)
        {
            this.addGridView = addGridView;
            this.gridRepository = gridRepository;
        }
    }
}
