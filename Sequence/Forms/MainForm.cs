using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sequence.Forms
{
    public partial class MainForm : Form
    {
        private readonly DisplayDto display;
        private readonly bool isMdi;
        private readonly long sequenceId;
        private readonly PermissionManager permissionManager;
        private readonly ReadOnlyCollection<Server> servers;
        private readonly ReadOnlyCollection<Database.Models.Camera> allCameras;
        private readonly ReadOnlyCollection<GridCamera> gridCameras;

        public MainForm(long userId, long sequenceId, long displayId, bool isMdi)
        {
            InitializeComponent();
            //closeToolStripMenuItem.Text = Lng.Elem("Close");
            this.isMdi = isMdi;
            this.sequenceId = sequenceId;

            var userRepository = new UserRepository();
            var user = userRepository.Select(userId);

            permissionManager = new PermissionManager();
            permissionManager.SetUser(this, new Mtf.Permissions.Models.User
            {

            });
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);

            var displayRepository = new DisplayRepository();
            var sequenceDisplay = displayRepository.Select(displayId);
            if (sequenceDisplay == null)
            {
                throw new InvalidOperationException($"Display does not found in repository with Id '{displayId}'.");
            }
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.Id == sequenceDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException($"Display does not found with Id '{displayId}'.");
            }

            var serverRepository = new ServerRepository();
            servers = serverRepository.SelectAll();
            var gridCameraRepository = new GridCameraRepository();
            gridCameras = gridCameraRepository.SelectAll();
            var cameraRepository = new CameraRepository();
            allCameras = cameraRepository.SelectAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Location = new Point(display.X, display.Y);
            Size = new Size(display.MaxWidth, display.MaxHeight);
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            var sequenceRepository = new SequenceRepository();
            var gridInSequeneRepository = new GridInSequenceRepository();
            var gridRepository = new GridRepository();
            var sequence = sequenceRepository.Select(sequenceId);
            var gridsInSequene = gridInSequeneRepository.SelectWhere(new { SequenceId = sequenceId });
            var grids = gridRepository.SelectAll()
                .SelectMany(grid => gridsInSequene
                .Where(gridInSequence => gridInSequence.GridId == grid.Id)
                .Select(gridInSequence => (grid, gridInSequence)))
                .ToList();

            if (grids.Count > 1)
            {
                await ShowGridsAsync(grids).ConfigureAwait(false);
            }
            else if (grids.Count == 1)
            {
                ShowGrid(grids, grids[0]);
            }
            else
            {
                ErrorBox.Show(Lng.Elem("General error"), Lng.Elem("No grids in sequence."));
            }
        }

        private void ShowGrid(List<(Grid grid, GridInSequence)> grids, (Grid, GridInSequence) gridInSequence)
        {
            var cameras = gridCameras
                .Where(gridCamera => grids.Any(g => g.grid.Id == gridCamera.GridId))
                .Join(allCameras,
                    gridCamera => gridCamera.CameraId,
                    camera => camera.Id,
                    (gridCamera, camera) => new { GridCamera = gridCamera, Camera = camera, Server = servers.First(s => s.Id == camera.ServerId ) })
                .ToList();
            throw new NotImplementedException();

            foreach (var camera in cameras)
            {
                if (isMdi)
                {
                    var location = new Point();
                    var size = new Size();
                    var cameraForm = new Camera(permissionManager, camera.Camera, camera.Server, location, size)
                    {
                        MdiParent = this
                    };
                    cameraForm.Show();
                }
                else
                {
                    //cameraProcess = AppStarter.Start("Camera.exe", $"{permissionManager.CurrentUser.Id} {camera.Id} {selectedDisplay.Id}");
                }
            }
        }
        
        private async Task ShowGridsAsync(List<(Grid, GridInSequence gridInSequence)> sequenceGrids)
        {
            foreach (var grid in sequenceGrids)
            {
                ShowGrid(sequenceGrids, grid);
                await Task.Delay(grid.gridInSequence.TimeToShow * 1000).ConfigureAwait(false);
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
