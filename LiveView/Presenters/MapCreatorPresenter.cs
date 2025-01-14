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
        private const string MapHasBeenCreated = "Map {0} has been created.";
        private const string MapHasBeenUpdated = "Map {0} has been updated.";
        private const string MapHasBeenDeleted = "Map {0} has been deleted.";
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
            view.TsmiOpenMap.DropDownItems.Clear();
            foreach (var map in maps)
            {
                var mapItem = new ToolStripMenuItem(map.ToString())
                {
                    Tag = map
                };
                mapItem.Click += MapObjectMenuItem_Click;
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
                var contextMenu = dropDownMenu?.OwnerItem?.OwnerItem?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    movableSizablePanel.Tag = menuItem.Tag;
                }
            }
            else if (sender is ToolStripMenuItem mapMenuItem && mapMenuItem.Tag is Map)
            {
                var dropDownMenu = mapMenuItem.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.OwnerItem?.Owner as ContextMenuStrip;
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
                var mapObjects = mapObjectRepository.SelectWhere(new { map.Id });
                Load(map, mapObjects);
            }
        }

        private void Load(Map map, ReadOnlyCollection<MapObject> mapObjects)
        {
            view.PCanvas.Controls.Clear();
            view.PCanvas.BackgroundImage = Services.ImageConverter.ByteArrayToImage(map.MapImage);
            foreach (MapObject mapObject in mapObjects)
            {
                var panel = new MovableSizablePanel
                {
                    Name = mapObject.Id.ToString(),
                    Size = new Size(mapObject.Width, mapObject.Height),
                    BackColor = Color.Gold,
                    BorderStyle = BorderStyle.None,
                    CanMove = true,
                    CanSize = true,
                    Location = new Point(mapObject.X, mapObject.Y),
                    ContextMenuStrip = view.CmsObjectMenu,
                    Text = mapObject.Comment,
                    BackgroundImage = Services.ImageConverter.ByteArrayToImage(mapObject.Image),
                    BackgroundImageLayout = ImageLayout.Zoom
                };
                switch (mapObject.ActionType)
                {
                    case MapActionType.OpenMap:
                        panel.Tag = mapRepository.Select(mapObject.ActionReferencedId);
                        break;
                    case MapActionType.OpenCamera:
                        panel.Tag = cameraRepository.Select(mapObject.ActionReferencedId);
                        break;
                }
                view.PCanvas.Controls.Add(panel);
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
                logger.LogInfo(MapHasBeenDeleted, map);
                CreateNewMap();
                Load();
            }
        }

        public void LoadMapImage()
        {
            if (view.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(view.OpenFileDialog.FileName);
                view.PCanvas.BackgroundImage = image;
                view.PCanvas.Controls.Clear();
            }
        }

        public void CreateNewMap()
        {
            view.CbMap.SelectedIndex = -1;
            view.CbMap.Text = String.Empty;
            view.RtbComment.Text = String.Empty;
            view.PCanvas.Controls.Clear();
            view.PCanvas.BackgroundImage = null;
        }

        public void SaveMap()
        {
            long mapId;
            var map = GetMap();
            if (view.CbMap.SelectedItem is Map existingMap)
            {
                map.Id = existingMap.Id;
                mapId = map.Id;
                mapRepository.Update(map);
                logger.LogInfo(MapHasBeenUpdated, map);
            }
            else
            {
                mapId = mapRepository.InsertAndReturnId<int>(map);
                logger.LogInfo(MapHasBeenCreated, map);
            }

            foreach (Control control in view.PCanvas.Controls)
            {
                var mapObject = GetMapObject(control);

                if (Int32.TryParse(control.Name, out var id))
                {
                    mapObject.Id = id;
                    mapObjectRepository.Update(mapObject);
                }
                else
                {
                    var mapObjectId = mapObjectRepository.InsertAndReturnId<int>(mapObject);
                    objectInMapRepository.Insert(new ObjectInMap
                    {
                        MapId = (int)mapId,
                        MapObjectId = mapObjectId
                    });
                }
            }
        }

        private static MapObject GetMapObject(Control control)
        {
            var mapObject = new MapObject
            {
                Comment = control.Text,
                X = control.Location.X,
                Y = control.Location.Y,
                Width = control.Size.Width,
                Height = control.Size.Height,
                Image = Services.ImageConverter.ImageToByteArray(control.BackgroundImage)
            };
            if (control.Tag is Camera camera)
            {
                mapObject.ActionType = MapActionType.OpenCamera;
                mapObject.ActionReferencedId = camera.Id;
            }
            else if (control.Tag is Map actualMap)
            {
                mapObject.ActionType = MapActionType.OpenMap;
                mapObject.ActionReferencedId = actualMap.Id;
            }
            else
            {
                mapObject.ActionType = MapActionType.NoAction;
            }

            return mapObject;
        }

        private Map GetMap()
        {
            return new Map
            {
                Name = view.CbMap.Text,
                Comment = view.RtbComment.Text,
                MapImage = Services.ImageConverter.ImageToByteArray(view.PCanvas.BackgroundImage),
                OriginalHeight = image?.Height ?? 0,
                OriginalWidth = image?.Width ?? 0
            };
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

        public void DeleteMapObject(object sender)
        {
            if (sender is ToolStripMenuItem menuitem)
            {
                var contextMenu = menuitem.GetCurrentParent() as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    if (movableSizablePanel.Tag is MapObject mapObject)
                    {
                        objectInMapRepository.DeleteWhere(new { mapObject.Id });
                        mapObjectRepository.Delete(mapObject.Id);
                    }
                    movableSizablePanel.Parent.Controls.Remove(movableSizablePanel);
                }
            }
        }

        public void SetMapIcon(object sender)
        {
            if (sender is ToolStripMenuItem menuitem)
            {
                var dropDownMenu = menuitem.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    movableSizablePanel.BackgroundImage = view.IlImages.Images[1];
                    movableSizablePanel.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        public void SetCameraIcon(object sender)
        {
            if (sender is ToolStripMenuItem menuitem)
            {
                var dropDownMenu = menuitem.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    movableSizablePanel.BackgroundImage = view.IlImages.Images[0];
                    movableSizablePanel.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        public void SetCustomImage(object sender)
        {
            if (sender is ToolStripMenuItem menuitem)
            {
                var dropDownMenu = menuitem.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is MovableSizablePanel movableSizablePanel)
                {
                    if (view.OpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        image = Image.FromFile(view.OpenFileDialog.FileName);
                        movableSizablePanel.BackgroundImage = image;
                        movableSizablePanel.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }
        }
    }
}
