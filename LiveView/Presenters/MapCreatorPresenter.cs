using AxVIDEOCONTROL4Lib;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Controls;
using Mtf.Controls.x86;
using Mtf.MessageBoxes.Enums;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class MapCreatorPresenter : BasePresenter
    {
        private IMapCreatorView view;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly IObjectInMapRepository objectInMapRepository;
        private readonly ILogger<MapCreator> logger;
        private Image image;

        public MapCreatorPresenter(MapCreatorPresenterDependencies mapCreatorPresenterDependencies)
            : base(mapCreatorPresenterDependencies)
        {
            serverRepository = mapCreatorPresenterDependencies.ServerRepository;
            cameraRepository = mapCreatorPresenterDependencies.CameraRepository;
            mapRepository = mapCreatorPresenterDependencies.MapRepository;
            mapObjectRepository = mapCreatorPresenterDependencies.MapObjectRepository;
            objectInMapRepository = mapCreatorPresenterDependencies.ObjectInMapRepository;
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
            foreach (var map in maps)
            {
                var mapItem = new ToolStripMenuItem(map.ToString())
                {
                    Tag = map
                };
                view.TsmiOpenMap.DropDownItems.Add(mapItem);
            }

            var cameras = cameraRepository.SelectAll();
            var servers = serverRepository.SelectAll();
            ParentChildToolStripMenuItemBuilder.PopulateMenuItems(
                view.TsmiOpenCamera,
                servers,
                server => server.ToString(),
                server => cameras.Where(c => c.ServerId == server.Id),
                camera => camera.ToString(),
                MapObjectMenuItem_Click
            );
        }

        private void MapObjectMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is Camera)
            {
                var dropDownMenu = menuItem.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    movableSizablePanel.Tag = menuItem.Tag;
                }
            }
            else if (sender is ToolStripMenuItem mapMenuItem && mapMenuItem.Tag is Map)
            {
                var dropDownMenu = mapMenuItem.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    movableSizablePanel.Tag = mapMenuItem.Tag;
                }
            }
        }

        public void SelectMap()
        {
            if (view.CbMap.SelectedItem is Map map)
            {
                //var objectInMaps = objectInMapRepository.SelectWhere(new { map.Id });
                var mapObjects = mapObjectRepository.SelectWhere(new { map.Id }/*objectInMaps.Select(o => o.MapObjectId)*/);

                Load(map, mapObjects);
            }
        }

        private void Load(Map map, ReadOnlyCollection<MapObject> mapObjects)
        {
            view.PCanvas.BackgroundImage = Services.ImageConverter.ByteArrayToImage(map.MapImage);
            foreach (MapObject mapObject in mapObjects)
            {
                view.PCanvas.Controls.Add(new MovableSizablePanel
                {
                    Size = new Size(mapObject.Width, mapObject.Height),
                    BackColor = Color.Gold,
                    BorderStyle = BorderStyle.None,
                    CanMove = true,
                    CanSize = true,
                    Location = new Point(mapObject.X, mapObject.Y)
                });
            }
        }

        public void DeleteMap()
        {
            if (!ShowConfirm("Are you sure you want to delete this item?", Decide.No))
            {
                return;
            }

            if (view.CbMap.SelectedItem is Map map)
            {
                mapRepository.Delete(map.Id);
                Load();
            }
        }

        public void LoadMapImage()
        {
            if (view.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(view.OpenFileDialog.FileName);
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
            var mapId = mapRepository.InsertAndReturnId<int>(map);

            foreach (Control control in view.PCanvas.Controls)
            {
                var mapObject = new MapObject
                {
                    Comment = control.Text,
                    X = control.Location.X,
                    Y = control.Location.Y,
                    Width = control.Size.Width,
                    Height = control.Size.Height,
                    Image = Services.ImageConverter.ImageToByteArray(control.BackgroundImage, ImageFormat.Bmp),
                    ActionType = control.Tag is Camera ? MapActionType.OpenCamera : control.Tag is Map ? MapActionType.OpenMap : MapActionType.NoAction,
                    ActionReferencedId = ((IHaveId<long>)control.Tag)?.Id ?? 0
                };
                var mapObjectId = mapObjectRepository.InsertAndReturnId<int>(mapObject);
                objectInMapRepository.Insert(new ObjectInMap
                {
                    MapId = mapId,
                    MapObjectId = mapObjectId
                });
            }
        }

        public static void SetDragEffect(DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(MovableSizablePanel)) ? DragDropEffects.Move : DragDropEffects.None;
        }

        public void AddCommentToPanel(object sender)
        {
            if (sender is ToolStripTextBox menuTextBox)
            {
                var dropDownMenu = menuTextBox.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    movableSizablePanel.Text = menuTextBox.Text;
                }
            }
        }

        public void LoadCommentFromPanel(object sender)
        {
            if (sender is ToolStripMenuItem menuitem)
            {
                var contextMenu = menuitem.GetCurrentParent() as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    menuitem.DropDownItems[0].Text = movableSizablePanel.Text;
                }
            }
        }
    }
}
