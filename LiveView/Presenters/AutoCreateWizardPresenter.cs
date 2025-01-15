using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class AutoCreateWizardPresenter : BasePresenter
    {
        private const int CameraIndex = 0;
        private const string GridHasBeenCreated = "Grid {0} has been created.";
        private const string SequenceHasBeenCreated = "Sequence {0} has been created.";

        private IAutoCreateWizardView view;
        private readonly ICameraRepository cameraRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly IGridRepository gridRepository;
        private readonly IGridInSequenceRepository gridInSequenceRepository;
        private readonly IGridCameraRepository gridCameraRepository;
        private readonly ILogger<AutoCreateWizard> logger;

        public AutoCreateWizardPresenter(AutoCreateWizardPresenterDependencies autoCreateWizardPresenterDependencies)
            : base(autoCreateWizardPresenterDependencies)
        {
            sequenceRepository = autoCreateWizardPresenterDependencies.SequenceRepository;
            gridRepository = autoCreateWizardPresenterDependencies.GridRepository;
            gridInSequenceRepository = autoCreateWizardPresenterDependencies.GridInSequenceRepository;
            cameraRepository = autoCreateWizardPresenterDependencies.CameraRepository;
            gridCameraRepository = autoCreateWizardPresenterDependencies.GridCameraRepository;
            logger = autoCreateWizardPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAutoCreateWizardView;
        }

        public void AddAll()
        {
            AddAllItemsFromListViewToAnother(view.LeftSide, view.RightSide, (item) => view.HasItemWithId(view.RightSide, ((IHaveId<long>)item.Tag).Id));
            AfterItemCountChange();
        }

        public void AfterItemCountChange()
        {
            GetDividers();
            SetTickState();
        }

        public void AddSelected()
        {
            AddSelectedItemsFromListViewToAnother(view.LeftSide, view.RightSide, (item) => view.HasItemWithId(view.RightSide, ((IHaveId<long>)item.Tag).Id));
            AfterItemCountChange();
        }

        private void SetTickState()
        {
            var isCompatible = IsCameraNumbnerCompatibleWithGrid();
            view.PbCheck.Image = isCompatible ? view.ImageList.Images[1] : view.ImageList.Images[2];
        }

        private bool IsCameraNumbnerCompatibleWithGrid()
        {
            if (view.CbGrids.SelectedItem is Grid grid)
            {
                var cameraCountInGrid = gridCameraRepository.SelectWhere(new { GridId = grid.Id }).Count; // ToDo: Select count script
                return view.RightSide.Items.Count % cameraCountInGrid == 0 ? true : false;
            }

            return false;
        }

        private void GetDividers()
        {
            int cameraCount = view.RightSide.Items.Count;
            view.CbX.Items.Clear();
            view.CbX.Items.Add("1");

            for (int i = 2; i <= cameraCount; i++)
            {
                if (cameraCount % i == 0)
                {
                    view.CbX.Items.Add(i.ToString());
                }
            }

            view.CbX.SelectedIndex = 0;
        }

        public void AutoCreate()
        {
            if (!IsCameraNumbnerCompatibleWithGrid())
            {
                ShowError("Try to change the grid or the number of cameras in the right side list.");
            }

            int cameraCount = 0, gridCount = 0;
            if (view.CbGrids.SelectedItem is Grid grid)
            {
                var templateGridCameras = gridCameraRepository.SelectWhere(new { GridId = grid.Id });
                var cameraCountInGrid = templateGridCameras.Count;
                var numberOfGridsInSequence = Convert.ToInt32(view.CbX.Text);

                var gridCameras = new List<Camera>();
                var grids = new List<Grid>();
                var gridIds = new List<long>();

                foreach (ListViewItem item in view.RightSide.Items)
                {
                    if (item.Tag is Camera camera)
                    {
                        gridCameras.Add(camera);
                        cameraCount++;

                        if (cameraCount % cameraCountInGrid == 0)
                        {
                            var gridName = gridCameras.Count > 1 ? String.Concat(gridCameras.First().CameraName, " - ", gridCameras.Last().CameraName) : gridCameras.First().CameraName;
                            var actualGrid = new Grid
                            {
                                Name = $"{view.TbGridNamePrefix.Text}{gridName}{view.TbGridNamePostfix.Text}",
                                Columns = grid.Columns,
                                Rows = grid.Columns,
                                PixelsFromBottom = grid.PixelsFromBottom,
                                PixelsFromRight = grid.PixelsFromRight,
                                Priority = grid.Priority
                            };
                            actualGrid.Id = gridRepository.InsertAndReturnId<long>(actualGrid);
                            gridIds.Add(actualGrid.Id);
                            grids.Add(actualGrid);
                            logger.LogInfo(GridHasBeenCreated, actualGrid.Name);
                            gridCount++;

                            var gridCameraIndex = 0;
                            foreach (var gridCamera in gridCameras)
                            {
                                var templateCamera = templateGridCameras[gridCameraIndex];
                                gridCameraRepository.Insert(new GridCamera
                                {
                                    GridId = actualGrid.Id,
                                    CameraId = gridCamera.Id,
                                    InitRow = templateCamera.InitRow,
                                    InitCol = templateCamera.InitCol,
                                    EndRow = templateCamera.EndRow,
                                    EndCol = templateCamera.EndCol,
                                    Left = templateCamera.Left,
                                    Width = templateCamera.Width,
                                    Top = templateCamera.Top,
                                    Height = templateCamera.Height,
                                    CsrNumberOfPhotos = templateCamera.CsrNumberOfPhotos,
                                    CsrSaveImages = templateCamera.CsrSaveImages,
                                    CsrValue = templateCamera.CsrValue,
                                    Frame = templateCamera.Frame,
                                    MotionNumberOfPhotos = templateCamera.MotionNumberOfPhotos,
                                    MotionSaveImages = templateCamera.MotionSaveImages,
                                    MotionValue = templateCamera.MotionValue,
                                    Osd = templateCamera.Osd,
                                    Ptz = templateCamera.Ptz,
                                    ShowDateTime = templateCamera.ShowDateTime
                                });
                                gridCameraIndex++;
                            }
                            gridCameras.Clear();
                        }

                        if (view.ChkCreateSequences.Checked && (gridCount % numberOfGridsInSequence == 0))
                        {
                            var sequenceName = grids.Count > 1 ? String.Concat(grids.First().Name, " - ", grids.Last().Name) : grids.First().Name;
                            var actualSequence = new Database.Models.Sequence
                            {
                                Name = $"{view.TbSequenceNamePrefix.Text}{sequenceName}{view.TbSequenceNamePostfix.Text}",
                                Active = true
                            };
                            var sequenceId = sequenceRepository.InsertAndReturnId<long>(actualSequence);

                            int number = 1; 
                            foreach (var gridId in gridIds)
                            {
                                gridInSequenceRepository.Insert(new GridInSequence
                                {
                                    SequenceId = sequenceId,
                                    GridId = gridId,
                                    Number = number++,
                                    TimeToShow = (int)view.NudSecondsToShow.Value
                                });
                            }
                            gridIds.Clear();
                            grids.Clear();
                            logger.LogInfo(SequenceHasBeenCreated, actualSequence.Name);
                        }
                    }
                }
            }
        }

        public void RemoveAll()
        {
            view.RemoveAllItem(view.RightSide);
            AfterItemCountChange();
        }

        public void RemoveSelected()
        {
            view.RemoveSelectedItems(view.RightSide);
            AfterItemCountChange();
        }

        public override void Load()
        {
            view.LeftSide.AddItems(cameraRepository.SelectAll(), camera => new ListViewItem(camera.CameraName, CameraIndex) { Tag = camera });

            var grids = gridRepository.SelectAll();
            view.AddItems(view.CbGrids, grids);
            view.SelectByIndex(view.CbGrids);
        }
    }
}
