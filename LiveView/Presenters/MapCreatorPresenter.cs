using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Controls;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class MapCreatorPresenter : BasePresenter
    {
        private IMapCreatorView view;
        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly IObjectInMapRepository objectInMapRepositoryRepository;
        private readonly ILogger<MapCreator> logger;
        private Image image;

        public MapCreatorPresenter(MapCreatorPresenterDependencies mapCreatorPresenterDependencies)
            : base(mapCreatorPresenterDependencies)
        {
            mapRepository = mapCreatorPresenterDependencies.MapRepository;
            mapObjectRepository = mapCreatorPresenterDependencies.MapObjectRepository;
            objectInMapRepositoryRepository = mapCreatorPresenterDependencies.ObjectInMapRepositoryRepository;
            logger = mapCreatorPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IMapCreatorView;
        }

        public void AddObject(DragEventArgs e = null)
        {
            if (e?.Data.GetData(typeof(MovableSizablePanel)) is MovableSizablePanel sourcePanel)
            {
                var location = view.PCanvas.PointToClient(new Point(e.X, e.Y));
                AddPanel(location, sourcePanel);
            }
            else
            {
                var location = new Point(10, 10);
                AddPanel(location, view.PTemplate);
            }
        }

        private void AddPanel(Point location, MovableSizablePanel sourcePanel)
        {
            var clonedPanel = sourcePanel.Clone(location);
            clonedPanel.ContextMenuStrip = view.CmsObjectMenu;
            view.PCanvas.Controls.Add(clonedPanel);
        }

        public override void Load()
        {
            var maps = mapRepository.SelectAll();
            view.CbMap.AddItemsAndSelectFirst(maps);
        }

        public void SelectMap()
        {
            if (view.CbMap.SelectedItem is Map map)
            {
                var mapObjects = mapObjectRepository.SelectWhere(map.Id);
                var objectInMaps = objectInMapRepositoryRepository.SelectWhere(map.Id);

                Load(map, mapObjects, objectInMaps);
            }
        }

        private void Load(Map map, ReadOnlyCollection<MapObject> mapObjects, ReadOnlyCollection<ObjectInMap> objectInMaps)
        {
            view.PCanvas.BackgroundImage = Services.ImageConverter.ByteArrayToImage(map.MapImage);

            //throw new NotImplementedException();
        }

        public void DeleteMap()
        {
            if (view.CbMap.SelectedItem is Map map)
            {
                mapRepository.Delete(map.Id);
            }
        }

        public void LoadMapImage()
        {
            if (view.FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(view.FolderBrowserDialog.SelectedPath);
                view.PCanvas.BackgroundImage = image;
            }
        }

        public void SaveMap()
        {
            var map = new Map
            {
                Name = view.CbMap.Text,
                Comment = view.RtbComment.Text,
                MapImage = Services.ImageConverter.ImageToByteArray(view.PCanvas.BackgroundImage, ImageFormat.Bmp),
                OriginalHeight = image?.Height ?? 0,
                OriginalWidth = image?.Width ?? 0
            };
            mapRepository.Insert(map);
        }

        public static void SetDragEffect(DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(MovableSizablePanel)) ? DragDropEffects.Move : DragDropEffects.None;
        }
    }
}
