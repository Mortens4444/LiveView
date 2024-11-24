using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class GridManagerPresenter
    {
        private readonly IGridManagerView gridManagerView;
        private readonly IGridRepository gridRepository;

        public GridManagerPresenter(IGridManagerView gridManagerView, IGridRepository gridRepository)
        {
            this.gridManagerView = gridManagerView;
            this.gridRepository = gridRepository;
        }
    }
}
