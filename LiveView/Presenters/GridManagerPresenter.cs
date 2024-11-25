using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class GridManagerPresenter : BasePresenter
    {
        private readonly IGridManagerView gridManagerView;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<GridManager> logger;

        public GridManagerPresenter(IGridManagerView gridManagerView, IGridRepository<Grid> gridRepository, ILogger<GridManager> logger)
            : base(gridManagerView)
        {
            this.gridManagerView = gridManagerView;
            this.gridRepository = gridRepository;
            this.logger = logger;
        }
    }
}
