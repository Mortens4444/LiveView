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
    public partial class IOPortEditor : Form, IIOPortEditorView
    {
        private readonly IOPortEditorPresenter ioPortEditorPresenter;

        public IOPortEditor(PermissionManager permissionManager, ILogger<IOPortEditor> logger, IIOPortRepository<IOPort> ioPortRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            ioPortEditorPresenter = new IOPortEditorPresenter(this, ioPortRepository, logger);

            Translator.Translate(this);
        }
    }
}
