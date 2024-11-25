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
    public partial class GridManager : Form, IGridManagerView
    {
        private readonly GridManagerPresenter gridManagerPresenter;

        public GridManager(PermissionManager permissionManager, ILogger<GridManager> logger, IGridRepository<Grid> gridRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            gridManagerPresenter = new GridManagerPresenter(this, gridRepository, logger);

            Translator.Translate(this);
        }
    }
}
