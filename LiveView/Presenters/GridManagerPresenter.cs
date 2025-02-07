using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class GridManagerPresenter : BasePresenter
    {
        private IGridManagerView view;
        private readonly IGridRepository gridRepository;
        private readonly IGridCameraRepository gridCameraRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly IServerRepository serverRepository;
        private readonly ILogger<GridManager> logger;

        public GridManagerPresenter(GridManagerPresenterDependencies dependencies)
            : base(dependencies)
        {
            gridRepository = dependencies.GridRepository;
            gridCameraRepository = dependencies.GridCameraRepository;
            cameraRepository = dependencies.CameraRepository;
            serverRepository = dependencies.ServerRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IGridManagerView;
        }

        public override void Load()
        {
            var grids = gridRepository.SelectAll();
            view.CbGrids.AddItemsAndSelectFirst(grids);

            FillChangeCameraMenuItem();
        }

        private void FillChangeCameraMenuItem()
        {
            if (view.TsmiChangeCameraTo.DropDownItems.Count > 0)
            {
                return;
            }

            var cameras = cameraRepository.SelectAll();
            var servers = serverRepository.SelectAll();
            foreach (var server in servers)
            {
                var serverToolStripMenuItem = new ToolStripMenuItem(server.Hostname)
                {
                    Tag = server
                };
                foreach (var camera in cameras.Where(c => c.ServerId == server.Id))
                {
                    var cameraToolStripMenuItem = new ToolStripMenuItem(camera.CameraName)
                    {
                        Tag = camera
                    };
                    cameraToolStripMenuItem.Click += CameraToolStripMenuItem_Click;
                    serverToolStripMenuItem.DropDownItems.Add(cameraToolStripMenuItem);
                }
                view.TsmiChangeCameraTo.DropDownItems.Add(serverToolStripMenuItem);
            }
        }

        private void CameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem toolStripMenuItem && toolStripMenuItem.Tag is Camera camera)
            {
                foreach (ListViewItem item in view.LvGridCameras.SelectedItems)
                {
                    var serverToolStripMenuItem = toolStripMenuItem.OwnerItem as ToolStripMenuItem;
                    if (serverToolStripMenuItem.Tag is Server server)
                    {
                        var gridCamera = item.Tag as GridCamera;
                        gridCamera.CameraId = camera.Id;
                        var lvItem = CreateListViewItem(gridCamera, camera, server);
                        var index = view.LvGridCameras.Items.IndexOf(item);
                        if (index >= 0)
                        {
                            view.LvGridCameras.Items[index] = lvItem;
                        }
                    }
                }
            }
        }

        public void DeleteGrid()
        {
            if (!ShowConfirm("Are you sure you want to delete this item?", Decide.No))
            {
                return;
            }

            if (view.CbGrids.SelectedItem is Grid grid)
            {
                gridRepository.Delete(grid.Id);
                Load();
            }
        }

        public void ModifyGrid()
        {
            var selectedGrid = view.CbGrids.SelectedItem;
            if (selectedGrid is Grid grid)
            {
                grid.Name = view.TbGridName.Text;
                gridRepository.Update(grid);
                gridCameraRepository.DeleteCamerasOfGrid(grid.Id);
                logger.LogInfo(GridManagementPermissions.Delete, "All cameras of grid '{0}' has been deleted.", grid.Name);
                foreach (ListViewItem item in view.LvGridCameras.Items)
                {
                    if (item.Tag is GridCamera gridCamera)
                    {
                        gridCameraRepository.Insert(gridCamera);
                        logger.LogInfo(GridManagementPermissions.Update, "Camera '{0}' has been added to the grid.", gridCamera);
                    }
                }

                //var server = view.GetSelectedItem<Server>(view.Servers);
                //cameraRepository.DeleteCamerasOfServer(server.Id);
                //var cameras = view.GetItems(view.CamerasToView);
                //var orderedCameras = cameras.Cast<ListViewItem>().OrderBy(camera => camera.Text).ToList();

                //var items = view.GetItems(view.ServerCameras);
                //foreach (ListViewItem camera in orderedCameras)
                //{
                //    var videoServerCamera = (VideoServerCamera)camera.Tag;
                //    var newCamera = new Camera
                //    {
                //        CameraName = videoServerCamera.Name,
                //        ServerId = server.Id,
                //        Guid = videoServerCamera.Guid,
                //        RecorderIndex = GetRecorderIndex(items, videoServerCamera.Name)
                //    };
                //    cameraRepository.Insert(newCamera);
                //    logger.LogInfo("Camera '{0}' has been added.", newCamera);
                //}
                //view.Close();

            }
        }

        public void MoveCamerasDown()
        {
            BaseView.MoveSelectedItems(view.LvGridCameras, true);
        }

        public void MoveCamerasUp()
        {
            BaseView.MoveSelectedItems(view.LvGridCameras, false);
        }

        public void SelectGrid()
        {
            var selectedGrid = view.CbGrids.SelectedItem;
            if (selectedGrid is Grid grid)
            {
                view.TbGridName.Text = grid.Name;
                var gridCameras = gridCameraRepository.SelectWhere(new { GridId = grid.Id });
                view.LvGridCameras.Items.Clear();
                foreach (var gridCamera in gridCameras)
                {
                    ListViewItem item = null;
                    if (gridCamera.CameraId.HasValue)
                    {
                        var camera = cameraRepository.Select(gridCamera.CameraId.Value);
                        var server = serverRepository.Select(camera.ServerId);
                        item = CreateListViewItem(gridCamera, camera, server);
                    }
                    else
                    {
                        item = CreateListViewItem(gridCamera, gridCamera.ServerIp, gridCamera.VideoSourceName);

                    }

                    if (item != null)
                    {
                        view.LvGridCameras.Items.Add(item);
                    }
                }
            }
        }

        private ListViewItem CreateListViewItem(GridCamera gridCamera, Camera camera, Server server)
        {
            var item = new ListViewItem((view.LvGridCameras.Items.Count + 1).ToString())
            {
                Tag = gridCamera
            };
            item.SubItems.Add(camera.CameraName);
            item.SubItems.Add(server.Hostname);
            item.SubItems.Add(camera.Guid);
            return item;
        }

        private ListViewItem CreateListViewItem(GridCamera gridCamera, string serverIp, string videoSourceName)
        {
            var item = new ListViewItem((view.LvGridCameras.Items.Count + 1).ToString())
            {
                Tag = gridCamera
            };
            item.SubItems.Add(videoSourceName);
            item.SubItems.Add(serverIp);
            item.SubItems.Add(Lng.Elem("N/A"));
            return item;
        }
    }
}
