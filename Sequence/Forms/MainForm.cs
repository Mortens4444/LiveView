using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using LiveView.Core.Enums.Window;
using LiveView.Core.Services;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using Sequence.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sequence.Forms
{
    public partial class MainForm : Form
    {
        private readonly DisplayDto display;
        private bool running = true;
        private readonly bool isMdi;
        private readonly long sequenceId;
        private readonly PermissionManager permissionManager;
        private readonly ReadOnlyCollection<Server> servers;
        private readonly ReadOnlyCollection<Database.Models.Camera> allCameras;
        private readonly ReadOnlyCollection<GridCamera> gridCameras;

        private readonly Dictionary<long, List<Form>> cameraForms = new Dictionary<long, List<Form>>();
        private readonly Dictionary<long, List<Process>> processes = new Dictionary<long, List<Process>>();

        public MainForm(long userId, long sequenceId, long displayId, bool isMdi)
        {
            Application.ApplicationExit += OnExit;
            AppDomain.CurrentDomain.ProcessExit += OnExit;
            FormClosing += OnExit;
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                DisposeCameraWindows();
                Application.Exit();
            };
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

            display = displays.FirstOrDefault(d => d.GetId() == sequenceDisplay.Id);
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
                .OrderBy(gridInSequence => gridInSequence.gridInSequence.Number)
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

        private void OnExit(object sender, EventArgs e)
        {
            DisposeCameraWindows();
        }

        private List<Form> ShowGridInWindow(List<(Grid grid, GridInSequence gridInSequence)> grids, (Grid grid, GridInSequence gridInSequence) gridInSequence)
        {
            var result = new List<Form>();
            var cameras = GetCameras(gridInSequence);

            foreach (var camera in cameras)
            {
                var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);

                Camera cameraForm = null;
                Invoke((Action)(() =>
                {
                    cameraForm = new Camera(permissionManager, camera.Camera, camera.Server, rectangle)
                    {
                        MdiParent = this
                    };
                    cameraForm.Show();
                }));
                result.Add(cameraForm);
            }
            return result;
        }

        private List<Process> ShowGridOnScreen(List<(Grid grid, GridInSequence gridInSequence)> grids, (Grid grid, GridInSequence gridInSequence) gridInSequence)
        {
            var result = new List<Process>();
            var cameras = GetCameras(gridInSequence);

            foreach (var camera in cameras)
            {
                var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                result.Add(AppStarter.Start("Camera.exe", $"{permissionManager.CurrentUser.Id} {camera.Camera.Id} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height}"));
            }
            return result;
        }

        private List<CameraInfo> GetCameras((Grid grid, GridInSequence gridInSequence) grid)
        {
            return gridCameras
                .Where(gc => gc.GridId == grid.grid.Id)
                .Join(allCameras,
                    gridCamera => gridCamera.CameraId,
                    camera => camera.Id,
                    (gridCamera, camera) => new CameraInfo
                    {
                        GridCamera = gridCamera,
                        Camera = camera,
                        Server = servers.First(s => s.Id == camera.ServerId)
                    })
                .ToList();
        }

        private async Task ShowGridsAsync(List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids)
        {
            while (running)
            {
                foreach (var grid in sequenceGrids)
                {
                    ShowGrid(sequenceGrids, grid);
                    await Task.Delay(grid.gridInSequence.TimeToShow * 1000).ConfigureAwait(false);
                    HideCameraWindows(grid.grid.Id);
                }
            }
        }

        private void HideCameraWindows(long gridId)
        {
            if (isMdi)
            {
                FormUtils.HideMdiChildForms(this, cameraForms[gridId]);
            }
            else
            {
                ProcessUtils.ChangeExternalProcessesVisibility(processes[gridId], CmdShow.Hide);
            }
        }

        int disposed;

        private void DisposeCameraWindows()
        {
            if (Interlocked.Exchange(ref disposed, 1) == 0)
            {
                if (isMdi)
                {
                    FormUtils.DisposeMdiChildForms(this, cameraForms.Values.SelectMany(forms => forms).ToList());
                }
                else
                {
                    ProcessUtils.KillExternalProcesses(processes.Values.SelectMany(windows => windows).ToList());
                }
            }
        }

        private void ShowGrid(List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids, (Grid grid, GridInSequence gridInSequence) grid)
        {
            if (isMdi)
            {
                if (cameraForms.TryGetValue(grid.grid.Id, out var value))
                {
                    FormUtils.ShowMdiChildForms(this, value);
                }
                else
                {
                    cameraForms[grid.grid.Id] = ShowGridInWindow(sequenceGrids, grid);
                }
            }
            else
            {
                if (processes.TryGetValue(grid.grid.Id, out var value))
                {
                    ProcessUtils.ChangeExternalProcessesVisibility(value, CmdShow.Show);
                }
                else
                {
                    processes[grid.grid.Id] = ShowGridOnScreen(sequenceGrids, grid);
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            running = false;
            Application.Exit();
        }
    }
}
