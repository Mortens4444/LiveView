using Database.Interfaces;
using Database.Models;
using LiveView.Core.CustomEventArgs;
using LiveView.Core.Dto;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Net;
using LiveView.Dto;
using LiveView.Enums;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class AddGridPresenter : BasePresenter
    {
        private const int BorderThickness = 5;
        private const int SmallFrame = 3;
        private const string ComboBox = "ComboBox";
        private const string NumericUpDown = "NumericUpDown";

        private GridType gridType = GridType.OneWay;
        private IAddGridView view;
        private readonly IGridRepository gridRepository;
        private readonly IGridCameraRepository gridCameraRepository;
        private readonly ILogger<AddGrid> logger;
        private readonly DisplayManager displayManager;
        private readonly List<CameraDto> cameras;
        private readonly ReadOnlyCollection<Server> servers;

        private Size displaySize;
        private Size menuSize;
        private Size defaultWindowSize;
        private Size defaultMiniWindowSize;

        private bool gridSettingsChanged = true;
        private bool gridSelectionMatrixChanged = true;

        public AddGridPresenter(AddGridPresenterDependencies addGridPresenterDependencies)
            : base(addGridPresenterDependencies)
        {
            displayManager = addGridPresenterDependencies.DisplayManager;
            gridRepository = addGridPresenterDependencies.GridRepository;
            gridCameraRepository = addGridPresenterDependencies.GridCameraRepository;
            logger = addGridPresenterDependencies.Logger;
            servers = addGridPresenterDependencies.ServerRepository.SelectAll();
            cameras = addGridPresenterDependencies.CameraRepository.SelectAll().Select(c => CameraDto.FromModel(c, servers.FirstOrDefault(s => s.Id == c.ServerId))).ToList();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddGridView;
            displaySize = view.Size;
        }

        public override void Load()
        {
            view.NudInitialRow.ValueChanged += (s, e) => HandleNumericUpDownValueChanged(view.NudInitialRow, view.NudClosingRow, view.NudNumberOfRows);
            view.NudClosingRow.ValueChanged += (s, e) => HandleNumericUpDownValueChanged(view.NudInitialRow, view.NudClosingRow, view.NudNumberOfRows);
            view.NudInitialColumn.ValueChanged += (s, e) => HandleNumericUpDownValueChanged(view.NudInitialColumn, view.NudClosingColumn, view.NudNumberOfColumns);
            view.NudClosingColumn.ValueChanged += (s, e) => HandleNumericUpDownValueChanged(view.NudInitialColumn, view.NudClosingColumn, view.NudNumberOfColumns);

            view.CbDisplays.AddItemsAndSelectFirst(displayManager.GetAll());
            view.CbGrids.AddItemsAndSelectFirst(gridRepository.SelectAll());
            CalculateMetrics();
        }

        public void CalculateMetrics()
        {
            gridSettingsChanged = true;
            var rowHeight = CalculateDimension(displaySize.Height, menuSize.Height, view.NudNumberOfRows.Value);
            var columnWidth = CalculateDimension(displaySize.Width, menuSize.Width, view.NudNumberOfColumns.Value);
            defaultWindowSize = new Size(columnWidth, rowHeight);
            var rowHeightSmall = CalculateDimension(view.PMiniDesign.Height, SmallFrame, view.NudNumberOfRows.Value);
            var columnWidthSmall = CalculateDimension(view.PMiniDesign.Width, SmallFrame, view.NudNumberOfColumns.Value);
            defaultMiniWindowSize = new Size(columnWidthSmall, rowHeightSmall);
            view.Invalidate(true);
        }

        private static int CalculateDimension(int totalSize, int frameSize, decimal divisions) => (int)Math.Round((totalSize - frameSize) / divisions);

        public void AdjustLeftEdgeLeftwards() => AdjustEdge(view.NudInitialColumn, -1);

        public void AdjustLeftEdgeRightwards() => AdjustEdge(view.NudInitialColumn, 1);

        public void AdjustLowerEdgeDownwards() => AdjustEdge(view.NudClosingRow, 1);

        public void AdjustLowerEdgeUpwards() => AdjustEdge(view.NudClosingRow, -1);

        public void AdjustRightEdgeLeftwards() => AdjustEdge(view.NudClosingColumn, -1);

        public void AdjustRightEdgeRightwards() => AdjustEdge(view.NudClosingColumn, 1);

        public void AdjustUpperEdgeDownwards() => AdjustEdge(view.NudInitialRow, 1);

        public void AdjustUpperEdgeUpwards() => AdjustEdge(view.NudInitialRow, -1);

        private void AdjustEdge(NumericUpDown nud, int delta)
        {
            var newValue = nud.Value + delta;
            if (newValue >= nud.Minimum && newValue <= nud.Maximum)
            {
                nud.Value = newValue;
                gridSelectionMatrixChanged = true;
            }
        }

        public void CombineOnGrid()
        {
            if (CanCombine())
            {
                Combine();
            }
            else
            {
                //ErrorBox.Show(Lng.Elem("77"), Lng.Elem("78"));
            }
        }

        public void LoadGrid()
        {
            gridSettingsChanged = true;
            if (view.CbGrids.SelectedIndex != -1)
            {
                var grid = view.CbGrids.SelectedItem as Grid;
                view.TbGridName.Text = grid.Name;
                view.NudNumberOfRows.Value = grid.Rows;
                view.NudNumberOfColumns.Value = grid.Columns;
                view.NudPixelsFromRight.Value = grid.PixelsFromRight;
                view.NudPixelsFromBottom.Value = grid.PixelsFromBottom;
                gridType = (GridType)(grid.Rows * grid.Columns);
                view.Invalidate(true);
            }
        }

        public void DrawGrid(Graphics graphics)
        {
            var color = (view.BackColor == Color.Black) ? Color.White : Color.Black;
            var controls = GetControls();

            if (GridSettingsChanged())
            {
                view.Invalidate(true);
                //gridSettingsChanged = false;

                RemoveOldControls(controls);
                AddGridControls();
                var matchingComboBox = view.PMain.Controls.OfType<ComboBox>().FirstOrDefault(cb => cb.Tag is MatrixRegion);
                SetComboboxSelectedIndexes(matchingComboBox);

                gridSettingsChanged = false;
                gridSelectionMatrixChanged = true;
            }
            foreach (Control control in controls)
            {
                if (control is ComboBox && control.Tag is MatrixRegion matrixRegion)
                {
                    DrawBorders(graphics, matrixRegion, defaultWindowSize, color, BorderThickness);
                }
            }
        }

        public void DrawMiniDesign(Graphics graphics)
        {
            try
            {
                if (GridSelectedMatrixChanged())
                {
                    int cameraCount = 0;
                    foreach (Control control in GetControls())
                    {
                        if (control is ComboBox && control.Tag is MatrixRegion matrixRegion)
                        {
                            cameraCount++;
                            DrawBorders(graphics, matrixRegion, defaultMiniWindowSize, Color.Black);
                        }
                    }

                    view.TsslNumberOfCameras.Text = $"{Lng.Elem("Number of cameras")}: {cameraCount}";

                    var borderColor = CanCombine() ? Color.LightGreen : Color.Red;
                    var selectedMatrixRegion = GetSelectedMatrixRegion();
                    DrawBorders(graphics, selectedMatrixRegion, defaultMiniWindowSize, borderColor, SmallFrame);
                    gridSelectionMatrixChanged = false;
                    view.Invalidate(true);
                }
                view.Update();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private MatrixRegion GetSelectedMatrixRegion()
        {
            return new MatrixRegion((int)view.NudInitialRow.Value - 1, (int)view.NudInitialColumn.Value - 1, (int)view.NudClosingRow.Value - 1, (int)view.NudClosingColumn.Value - 1);
        }

        private void Combine()
        {
            var controls = GetControls();
            var selectedMatrixRegion = GetSelectedMatrixRegion();

            RemoveControls(controls, selectedMatrixRegion);

            var comboBox = CreateComboBox(selectedMatrixRegion);
            controls.Add(comboBox);

            var numericUpDown = CreateNumericUpDown(selectedMatrixRegion);
            controls.Add(numericUpDown);

            view.Invalidate(true);
        }

        private void GetCombinedGridCameras(long gridId)
        {
            view.NudInitialRow.Maximum = view.NudNumberOfRows.Value;
            view.NudClosingRow.Maximum = view.NudInitialRow.Maximum;
            view.NudInitialColumn.Maximum = view.NudNumberOfColumns.Value;
            view.NudClosingColumn.Maximum = view.NudInitialColumn.Maximum;

            var gridCameras = gridCameraRepository.GetCombinedGridCameras(gridId);
            for (int i = 0; i < gridCameras.Count; i++)
            {
                view.NudInitialRow.Value = gridCameras[i].InitRow + 1;
                view.NudClosingRow.Value = gridCameras[i].EndRow.Value + 1;
                view.NudInitialColumn.Value = gridCameras[i].InitCol + 1;
                view.NudClosingColumn.Value = gridCameras[i].EndCol.Value + 1;
                if (CanCombine())
                {
                    Combine();
                }
            }
        }

        private void LoadGridCameras(long gridId)
        {
            var gridCameras = gridCameraRepository.SelectWhere(new { GridId = gridId });
            foreach (var gridCamera in gridCameras)
            {
                var index = cameras.IndexOf(cameras.FirstOrDefault(camera => camera.Id == gridCamera.CameraId));
                foreach (Control control in GetControls())
                {
                    if (control is ComboBox comboBox && comboBox.Tag is MatrixRegion matrixRegion)
                    {
                        if (matrixRegion == gridCamera.MatrixRegion)
                        {
                            comboBox.SelectedIndex = index;
                        }
                    }
                }
                break;
            }
        }

        private NumericUpDown CreateNumericUpDown(MatrixRegion matrixRegion)
        {
            var numericUpDown = new NumericUpDown
            {
                Name = $"{NumericUpDown}{matrixRegion}",
                Tag = matrixRegion,
                Value = 0,
                Minimum = 0,
                Maximum = 99,
                Size = GetControlSize(matrixRegion.ColumnSpan),
                Location = GetControlLocation(matrixRegion, 31),
            };
            return numericUpDown;
        }

        private ComboBox CreateComboBox(MatrixRegion matrixRegion)
        {
            var result = new ComboBox
            {
                FormattingEnabled = true,
                Location = GetControlLocation(matrixRegion),
                Name = $"{ComboBox}{matrixRegion}",
                Tag = matrixRegion,
                Size = GetControlSize(matrixRegion.ColumnSpan),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            foreach (var camera in cameras)
            {
                result.Items.Add(camera);
            }

            result.Items.AddRange(
                MainPresenter.VideoCaptureSources
                    .SelectMany(vcs => vcs.Value, (vcs, camera) => new VideoSource
                    {
                        Socket = vcs.Key,
                        Name = camera.Key,
                        EndPoint = camera.Value
                    })
                    .ToArray()
            );

            result.SelectedIndex = result.Items.Count > 0 ? 0 : -1;

            result.LocationChanged += (s, e) => { view.Invalidate(true); };
            result.Leave += (s, e) =>
            {
                if (view.IsVideoConnected)
                {
                    view.AxVideoPlayerWindow.Visible = false;
                    view.AxVideoPlayerWindow.AxVideoPlayer.Stop();
                }
            };
            result.Enter += (sender, e) =>
            {
                if (sender is ComboBox comboBox)
                {
                    Connect(comboBox);
                }
            };
            if (matrixRegion.IsOrigo)
            {
                result.SelectedIndexChanged += CbGrids_SelectedIndexChanged;
            }
            else
            {
                result.SelectedIndexChanged += CbGrids_Connect;
            }
            return result;
        }

        private bool GridSettingsChanged() => gridSettingsChanged;

        private void AddGridControls()
        {
            var controls = GetControls();

            for (int fromRow = 0; fromRow < view.NudNumberOfRows.Value; fromRow++)
            {
                for (int fromColumn = 0; fromColumn < view.NudNumberOfColumns.Value; fromColumn++)
                {
                    switch (gridType)
                    {
                        case GridType.OneWay:
                        case GridType.FourWay:
                        case GridType.NineWay:
                        case GridType.SixteenWay:
                        case GridType.TwentyFiveWay:
                        case GridType.ThirtySixWay:
                        case GridType.FortyNineWay:
                        case GridType.SixtyFourWay:
                            CreateControls(controls, new MatrixRegion(fromRow, fromColumn));
                            break;
                        case GridType.SixWay:
                            if (fromRow == 0 && fromColumn == 0 && view.NudNumberOfColumns.Value > 1 && view.NudNumberOfRows.Value > 1)
                            {
                                CreateControls(controls, new MatrixRegion(0, 0, 1, 1));
                            }
                            else
                            {
                                if (fromRow > 1 || fromColumn > 1 || view.NudNumberOfColumns.Value < 2 || view.NudNumberOfRows.Value < 2)
                                {
                                    CreateControls(controls, new MatrixRegion(fromRow, fromColumn));
                                }
                            }
                            break;
                        case GridType.SevenWay:
                            if (fromRow == 0 && fromColumn == 0 && view.NudNumberOfColumns.Value > 1 && view.NudNumberOfRows.Value > 1)
                            {
                                CreateControls(controls, new MatrixRegion(0, 0, 1, 1));
                            }
                            else if (fromRow == 0 && fromColumn == 2 && view.NudNumberOfRows.Value > 1 && view.NudNumberOfColumns.Value > 3)
                            {
                                CreateControls(controls, new MatrixRegion(0, 2, 1, 3));
                            }
                            else if (fromRow == 2 && fromColumn == 0 && view.NudNumberOfColumns.Value > 1 && view.NudNumberOfRows.Value > 3)
                            {
                                CreateControls(controls, new MatrixRegion(2, 0, 3, 1));
                            }
                            else
                            {
                                //if (fromRow > 2 && fromColumn > 2)
                                if ((fromRow != 0 || fromColumn != 1 || view.NudNumberOfColumns.Value <= 1 || view.NudNumberOfRows.Value <= 1) &&
                                    (fromRow != 1 || fromColumn != 0 || view.NudNumberOfColumns.Value <= 1 || view.NudNumberOfRows.Value <= 1) &&
                                    ((fromRow != 1) || (fromColumn != 1) || (view.NudNumberOfColumns.Value <= 1) || (view.NudNumberOfRows.Value <= 1)) &&

                                    ((fromRow != 2) || (fromColumn != 1) || (view.NudNumberOfColumns.Value <= 1) || (view.NudNumberOfRows.Value <= 3)) &&
                                    ((fromRow != 3) || (fromColumn != 0) || (view.NudNumberOfColumns.Value <= 1) || (view.NudNumberOfRows.Value <= 3)) &&
                                    ((fromRow != 3) || (fromColumn != 1) || (view.NudNumberOfColumns.Value <= 1) || (view.NudNumberOfRows.Value <= 3)) &&

                                    ((fromRow != 0) || (fromColumn != 3) || (view.NudNumberOfColumns.Value <= 3) || (view.NudNumberOfRows.Value <= 1)) &&
                                    ((fromRow != 1) || (fromColumn != 2) || (view.NudNumberOfColumns.Value <= 3) || (view.NudNumberOfRows.Value <= 1)) &&
                                    (fromRow != 1 || fromColumn != 3 || view.NudNumberOfColumns.Value <= 3 || view.NudNumberOfRows.Value <= 1))
                                {
                                    CreateControls(controls, new MatrixRegion(fromRow, fromColumn));
                                }
                            }
                            break;
                        case GridType.EightWay:
                            if (fromRow == 0 && fromColumn == 0 && view.NudNumberOfColumns.Value > 2 && view.NudNumberOfRows.Value > 2)
                            {
                                CreateControls(controls, new MatrixRegion(0, 0, 2, 2));
                            }
                            else
                            {
                                if (fromRow > 2 || fromColumn > 2 || view.NudNumberOfColumns.Value < 3 || view.NudNumberOfRows.Value < 3)
                                {
                                    CreateControls(controls, new MatrixRegion(fromRow, fromColumn));
                                }
                            }
                            break;
                        case GridType.TenWay:
                            if (fromRow == 0 && fromColumn == 0 && view.NudNumberOfColumns.Value > 1 && view.NudNumberOfRows.Value > 1)
                            {
                                CreateControls(controls, new MatrixRegion(0, 0, 1, 1));
                            }
                            else if (fromRow == 0 && fromColumn == 2 && view.NudNumberOfRows.Value > 1 && view.NudNumberOfColumns.Value > 3)
                            {
                                CreateControls(controls, new MatrixRegion(0, 2, 1, 3));
                            }
                            else
                            {
                                //if (fromRow > 2)
                                if ((fromRow != 0 || fromColumn != 1 || view.NudNumberOfColumns.Value <= 1 || view.NudNumberOfRows.Value <= 1) &&
                                    (fromRow != 1 || fromColumn != 0 || view.NudNumberOfColumns.Value <= 1 || view.NudNumberOfRows.Value <= 1) &&
                                    (fromRow != 1 || fromColumn != 1 || view.NudNumberOfColumns.Value <= 1 || view.NudNumberOfRows.Value <= 1) &&
                                    (fromRow != 0 || fromColumn != 3 || view.NudNumberOfColumns.Value <= 3 || view.NudNumberOfRows.Value <= 1) &&
                                    (fromRow != 1 || fromColumn != 2 || view.NudNumberOfColumns.Value <= 3 || view.NudNumberOfRows.Value <= 1) &&
                                    (fromRow != 1 || fromColumn != 3 || view.NudNumberOfColumns.Value <= 3 || view.NudNumberOfRows.Value <= 1))
                                {
                                    CreateControls(controls, new MatrixRegion(fromRow, fromColumn));
                                }
                            }
                            break;
                    }

                }
            }
        }

        private void CreateControls(Control.ControlCollection controls, MatrixRegion matrixRegion)
        {
            var comboBox = CreateComboBox(matrixRegion);
            controls.Add(comboBox);
            var numericUpDown = CreateNumericUpDown(matrixRegion);
            controls.Add(numericUpDown);
        }

        private void CbGrids_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboboxSelectedIndexes(sender as ComboBox);
        }

        private void SetComboboxSelectedIndexes(ComboBox comboBox)
        {
            if (comboBox != null)
            {
                var selectedIndex = comboBox.SelectedIndex;
                Connect(comboBox);

                foreach (Control control in GetControls())
                {
                    if (control is ComboBox cb && !ReferenceEquals(comboBox, cb))
                    {
                        cb.SelectedIndexChanged -= CbGrids_Connect;
                        try
                        {
                            cb.SelectedIndex = (++selectedIndex % cb.Items.Count);
                        }
                        catch (Exception ex)
                        {
                            cb.SelectedIndex = 0;
                            selectedIndex = 0;
                            DebugErrorBox.Show(ex);
                        }
                        cb.SelectedIndexChanged += CbGrids_Connect;
                    }
                }
            }
        }

        private void CbGrids_Connect(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                Connect(comboBox);
            }
        }

        private void Connect(ComboBox comboBox)
        {
            if (view.ChkConnectToCamera.Checked)
            {
                if (comboBox.SelectedItem is CameraDto camera)
                {
                    view.AxVideoPlayerWindow.Visible = true;
                    view.AxVideoPlayerWindow.AxVideoPlayer.Start(camera.Server.IpAddress, camera.Guid, camera.Server.VideoServerCredentials.Username, camera.Server.VideoServerCredentials.Password);
                    var matrixRegion = comboBox.Tag as MatrixRegion;
                    view.AxVideoPlayerWindow.Location = GetControlLocation(matrixRegion, 62);
                    view.AxVideoPlayerWindow.Size = new Size(matrixRegion.ColumnSpan * defaultWindowSize.Width - 10, defaultWindowSize.Height - (2 * comboBox.Height + 10));
                }
                else if (comboBox.SelectedItem is VideoSource videoSource)
                {
                    var videoCaptureClient = new VideoCaptureClient(videoSource.ServerIp, videoSource.ServerPort);
                    videoCaptureClient.Start();
                    videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;
                }
            }
        }
        private Image lastImage = null;

        private void VideoCaptureClient_FrameArrived(object sender, FrameArrivedEventArgs e)
        {
            try
            {
                lastImage?.Dispose();
                view.AxVideoPlayerWindow.Invoke((Action)(() => { view.AxVideoPlayerWindow.Visible = false; }));
                view.PMain.SetImage(e.Frame, true);
                lastImage = e.Frame;

                //view.AxVideoPlayerWindow.SetImage(e.Frame, true);
            }
            catch (InvalidOperationException)
            {
                //view.AxVideoPlayerWindow.SetImage(Properties.Resources.nosignal, false);
            }
            catch (Exception ex)
            {
                //view.AxVideoPlayerWindow.SetImage(Properties.Resources.nosignal, false);
                DebugErrorBox.Show(ex);
            }
        }

        private static void RemoveControls(Control.ControlCollection controls, MatrixRegion matrixRegionToDelete)
        {
            var controlsToRemove = new List<Control>();
            foreach (Control control in controls)
            {
                if (control.Tag is MatrixRegion matrixRegion && matrixRegion.IsInRange(matrixRegionToDelete))
                {
                    controlsToRemove.Add(control);
                }
            }

            foreach (var control in controlsToRemove)
            {
                controls.Remove(control);
            }
        }

        private static void RemoveOldControls(Control.ControlCollection controls)
        {
            for (int i = controls.Count - 1; i >= 0; i--)
            {
                var control = controls[i];
                if (control is ComboBox || control is NumericUpDown)
                {
                    controls.RemoveAt(i);
                }
            }
        }

        public void LoadTemplate10Way()
        {
            gridType = GridType.TenWay;
            SetValueAndMax(4);
        }

        public void LoadTemplate16Way()
        {
            gridType = GridType.SixteenWay;
            SetValueAndMax(4);
        }

        public void LoadTemplate1Way()
        {
            gridType = GridType.OneWay;
            SetValueAndMax(1);
        }

        public void LoadTemplate25Way()
        {
            gridType = GridType.TwentyFiveWay;
            SetValueAndMax(5);
        }

        public void LoadTemplate36Way()
        {
            gridType = GridType.ThirtySixWay;
            SetValueAndMax(6);
        }

        public void LoadTemplate49Way()
        {
            gridType = GridType.FortyNineWay;
            SetValueAndMax(7);
        }

        public void LoadTemplate4Way()
        {
            gridType = GridType.FourWay;
            SetValueAndMax(2);
        }

        public void LoadTemplate64Way()
        {
            gridType = GridType.SixtyFourWay;
            SetValueAndMax(8);
        }

        public void LoadTemplate6Way()
        {
            gridType = GridType.SixWay;
            SetValueAndMax(3);
        }

        public void LoadTemplate7Way()
        {
            gridType = GridType.SevenWay;
            SetValueAndMax(4);
        }

        public void LoadTemplate8Way()
        {
            gridType = GridType.EightWay;
            SetValueAndMax(3);
        }

        public void LoadTemplate9Way()
        {
            gridType = GridType.NineWay;
            SetValueAndMax(3);
        }

        public void SaveGrid()
        {
            var gridId = gridRepository.InsertAndReturnId<long>(new Grid
            {
                Name = view.TbGridName.Text,
                PixelsFromBottom = (int)view.NudPixelsFromBottom.Value,
                PixelsFromRight = (int)view.NudPixelsFromRight.Value,
                Rows = (int)view.NudNumberOfRows.Value,
                Columns = (int)view.NudNumberOfColumns.Value,
            });

            var controls = GetControls();
            foreach (Control control in controls)
            {
                if (control is ComboBox comboBox && control.Tag is MatrixRegion matrixRegion)
                {
                    GridCamera gridCamera = null;
                    if (comboBox.SelectedItem is CameraDto cameraDto)
                    {
                        gridCamera = new GridCamera
                        {
                            InitRow = matrixRegion.FromRow,
                            InitCol = matrixRegion.FromColumn,
                            EndRow = matrixRegion.ToRow,
                            EndCol = matrixRegion.FromColumn,
                            GridId = gridId,
                            CameraId = cameraDto.Id
                        };
                    }
                    else if (comboBox.SelectedItem is VideoSource videoSource)
                    {
                        gridCamera = new GridCamera
                        {
                            InitRow = matrixRegion.FromRow,
                            InitCol = matrixRegion.FromColumn,
                            EndRow = matrixRegion.ToRow,
                            EndCol = matrixRegion.FromColumn,
                            GridId = gridId,
                            ServerIp = videoSource.ServerIp,
                            VideoSourceName = videoSource.Name,
                            CameraId = null
                        };
                    }

                    if (gridCamera != null)
                    {
                        gridCameraRepository.Insert(gridCamera);
                    }
                }
            }

            logger.LogInfo("Grid '{0}' has been saved.", view.TbGridName.Text);
        }

        public void SetHeightForAspect16_10()
        {
            SetAspectRatio(16, 10, false);
        }

        public void SetHeightForAspect16_9()
        {
            SetAspectRatio(16, 9, false);
        }

        public void SetHeightForAspect4_3()
        {
            SetAspectRatio(4, 3, false);
        }

        public void SetWidthForAspect16_10()
        {
            SetAspectRatio(16, 10, true);
        }

        public void SetWidthForAspect16_9()
        {
            SetAspectRatio(16, 9, true);
        }

        public void SetWidthForAspect4_3()
        {
            SetAspectRatio(4, 3, true);
        }

        private void SetValueAndMax(int max)
        {
            gridSettingsChanged = true;
            view.CbGrids.SelectedIndex = -1;

            view.NudNumberOfRows.Value = max;
            view.NudNumberOfColumns.Value = max;
            view.NudInitialRow.Maximum = max;
            view.NudInitialColumn.Maximum = max;
            view.NudClosingRow.Maximum = max;
            view.NudClosingColumn.Maximum = max;

            view.NudInitialRow.Value = 1;
            view.NudInitialColumn.Value = 1;

            if (max > 1)
            {
                view.NudClosingRow.Value = 2;
                view.NudClosingColumn.Value = 2;
            }
            else
            {
                view.NudClosingRow.Value = 1;
                view.NudClosingColumn.Value = 1;
            }

            view.PMain.Invalidate(true);
        }

        private void SetAspectRatio(int widthAspect, int heightAspect, bool fixedBottom)
        {
            try
            {
                CalculateMetrics();

                if (fixedBottom)
                {
                    AdjustRightEdge(widthAspect, heightAspect);
                }
                else
                {
                    AdjustBottomAndRightEdges(widthAspect, heightAspect);
                }

                view.Invalidate(true);
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
                ShowError(ex);
            }
        }

        private void AdjustRightEdge(int widthAspect, int heightAspect)
        {
            int targetRightValue = view.Width - (view.Height - menuSize.Height) * widthAspect / heightAspect;

            if (targetRightValue >= view.NudPixelsFromRight.Minimum && targetRightValue <= view.NudPixelsFromRight.Maximum)
            {
                view.NudPixelsFromRight.Value = targetRightValue;
            }
            else
            {
                view.NudPixelsFromBottom.Value = MathExtensions.Clamp(view.NudPixelsFromBottom.Value + (targetRightValue < view.NudPixelsFromRight.Minimum ? 1 : -1),
                                                            view.NudPixelsFromBottom.Minimum,
                                                            view.NudPixelsFromBottom.Maximum);
            }
        }

        private void AdjustBottomAndRightEdges(int widthAspect, int heightAspect)
        {
            int cellWidth = (view.Width - (int)view.NudPixelsFromRight.Value) / (int)view.NudNumberOfColumns.Value;
            int cellHeight = cellWidth * widthAspect / heightAspect;

            int newRightValue = view.Width - (int)view.NudNumberOfColumns.Value * cellWidth;
            int newBottomValue = view.Height - (int)view.NudNumberOfRows.Value * cellHeight;

            view.NudPixelsFromRight.Value = MathExtensions.Clamp(newRightValue, view.NudPixelsFromRight.Minimum, view.NudPixelsFromRight.Maximum);
            view.NudPixelsFromBottom.Value = MathExtensions.Clamp(newBottomValue, view.NudPixelsFromBottom.Minimum, view.NudPixelsFromBottom.Maximum);
        }

        private void HandleNumericUpDownValueChanged(NumericUpDown initialControl, NumericUpDown closingControl, NumericUpDown numberOfLimits)
        {
            if (closingControl.Value < initialControl.Value)
            {
                closingControl.Value = initialControl.Value;
            }

            initialControl.Maximum = numberOfLimits.Value;
            closingControl.Maximum = numberOfLimits.Value;

            view.Invalidate(true);
        }

        public void DisplaySelected()
        {
            if (view.CbDisplays.SelectedItem is DisplayDto displayDto)
            {
                displaySize = new Size(displayDto.Width, displayDto.Height);
                menuSize = new Size(displayDto.MaxWidth - displayDto.Width, displayDto.MaxHeight - displayDto.Height);
                view.NudPixelsFromRight.Value = menuSize.Width;
                view.NudPixelsFromBottom.Value = menuSize.Height;

                var (widthAspect, heightAspect) = GetNativeAspectRatio(displaySize);
                SetAspectRatio(widthAspect, heightAspect, true);
            }
        }

        private static (int WidthAspect, int HeightAspect) GetNativeAspectRatio(Size displaySize)
        {
            int gcd = GetGreatestCommonDivisor(displaySize.Width, displaySize.Height);
            return (displaySize.Width / gcd, displaySize.Height / gcd);
        }

        public void SetBottomBorder()
        {
            menuSize = new Size(menuSize.Width, (int)view.NudPixelsFromBottom.Value);
            CalculateMetrics();
        }

        public void SetRightBorder()
        {
            menuSize = new Size((int)view.NudPixelsFromRight.Value, menuSize.Height);
            CalculateMetrics();
        }

        public bool CanCombine()
        {
            var selectedMatrixRegion = GetSelectedMatrixRegion();
            foreach (Control control in GetControls())
            {
                if (control.Tag is MatrixRegion matrixRegion && matrixRegion.IsInRange(selectedMatrixRegion) && matrixRegion.IsCombined)
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetGreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private Control.ControlCollection GetControls() => view.Controls[0].Controls;

        private Point GetControlLocation(MatrixRegion matrixRegion, int heightDelta = 0) => new Point(matrixRegion.FromColumn * defaultWindowSize.Width + 5, matrixRegion.FromRow * defaultWindowSize.Height + 5 + heightDelta);

        private Size GetControlSize(int columnSpan) => new Size(columnSpan * defaultWindowSize.Width - 10, 21);

        private bool GridSelectedMatrixChanged()
        {
            return gridSelectionMatrixChanged;
        }

        private static void DrawBorders(Graphics graphics, MatrixRegion matrixRegion, Size size, Color color, int width = 1)
        {
            using (var pen = new Pen(color, width))
            {
                var rectangle = matrixRegion.GetDrawDimensions(size);
                graphics.DrawRectangle(pen, rectangle);
            }
        }
    }
}
