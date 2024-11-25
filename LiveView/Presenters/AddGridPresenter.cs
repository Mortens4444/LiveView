using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AddGridPresenter : BasePresenter
    {
        private readonly IAddGridView addGridView;
        private readonly IGridRepository<Grid> gridRepository;
        private readonly ILogger<AddGrid> logger;

        public AddGridPresenter(IAddGridView addGridView, IGridRepository<Grid> gridRepository, ILogger<AddGrid> logger)
            : base(addGridView)
        {
            this.addGridView = addGridView;
            this.gridRepository = gridRepository;
            this.logger = logger;
        }
    }
}
