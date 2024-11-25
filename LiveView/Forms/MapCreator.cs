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
    public partial class MapCreator : Form, IMapCreatorView
    {
        private readonly MapCreatorPresenter mapCreatorPresenter;

        public MapCreator(PermissionManager permissionManager, ILogger<MapCreator> logger, IMapRepository<Map> mapRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            mapCreatorPresenter = new MapCreatorPresenter(this, mapRepository, logger);

            Translator.Translate(this);
        }
    }
}
