using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddGrid : Form, IAddGridView
    {
        private readonly AddGridPresenter addGridPresenter;

        public AddGrid(PermissionManager permissionManager, ILogger<AddGrid> logger, IGridRepository<Grid> gridRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            addGridPresenter = new AddGridPresenter(this, gridRepository, logger);

            Translator.Translate(this);
        }
    }
}
