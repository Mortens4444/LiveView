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
    public partial class SequentialChains : Form, ISequentialChainsView
    {
        private readonly SequentialChainsPresenter sequentialChainsPresenter;

        public SequentialChains(PermissionManager permissionManager, ILogger<SequentialChains> logger, ISequenceRepository<Sequence> sequenceRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            sequentialChainsPresenter = new SequentialChainsPresenter(this, sequenceRepository, logger);

            Translator.Translate(this);
        }
    }
}
