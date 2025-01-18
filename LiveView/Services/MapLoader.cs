using Database.Enums;
using Database.Interfaces;
using LiveView.CustomEventArgs;
using LiveView.Dto;
using LiveView.Models.Dependencies;
using Mtf.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Services
{
    public class MapLoader
    {
        private readonly MtfPictureBox mapContainer;
        private readonly ToolTip toolTip;

        public delegate void CameraObjectClickedEventHandler(CameraObjectClickedEventArgs e);
        public event CameraObjectClickedEventHandler CameraObjectClicked;

        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly ICameraRepository cameraRepository;

        public MapLoader(MtfPictureBox mapContainer, ToolTip toolTip, MapLoaderDependencies mapLoaderDependencies)
        {
            this.mapContainer = mapContainer;
            this.toolTip = toolTip;
            mapRepository = mapLoaderDependencies.MapRepository;
            mapObjectRepository = mapLoaderDependencies.MapObjectRepository;
            cameraRepository = mapLoaderDependencies.CameraRepository;
        }

        public void LoadMap(MapDto map)
        {
            if (map == null || map.MapImage == null)
            {
                return;
            }
            if (map.OriginalWidth <= 0 || map.OriginalHeight <= 0)
            {
                throw new ArgumentException("Map dimensions must be positive.");
            }
            try
            {
                if (map.MapImage is Bitmap)
                {
                    var testBitmap = new Bitmap(map.MapImage);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid image format or corrupted image.", ex);
            }
            mapContainer.Controls.Clear();
            mapContainer.SuspendLayout();
            try
            {
                mapContainer.Image = map.MapImage;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error setting map image: {ex.Message}");
                throw;
            }
            mapContainer.Paint += (s, e) =>
            {
                if (mapContainer.Image == null || mapContainer.Image.Width <= 0 || mapContainer.Image.Height <= 0)
                {
                    throw new ArgumentException("Invalid image dimensions during Paint.");
                }
            };
            foreach (var mapObject in map.MapObjects)
            {
                if (mapObject.Location.X < 0 || mapObject.Location.Y < 0 || mapObject.Size.Width <= 0 || mapObject.Size.Height <= 0)
                {
                    throw new ArgumentException("Map object panel must have valid position or size.");
                }

                var mapObjectPanel = new TransparentPanel
                {
                    //Location = new Point(mapObject.Location.X, mapObject.Location.Y),
                    Size = new Size(mapObject.Size.Width, mapObject.Size.Height),
                    BackColor = Color.Black
                };
                var validLocation = new Point(
                    Math.Max(0, Math.Min(mapContainer.ClientSize.Width - mapObject.Size.Width, mapObject.Location.X)),
                    Math.Max(0, Math.Min(mapContainer.ClientSize.Height - mapObject.Size.Height, mapObject.Location.Y))
                );
                mapObjectPanel.Location = validLocation;

                var image = (Bitmap)mapObject.Image;
                if (image != null)
                {
                    mapObjectPanel.BackgroundImage = image;
                }

                mapObjectPanel.BackgroundImageLayout = ImageLayout.Zoom;
                mapObjectPanel.MouseEnter += MapObjectPanel_MouseEnter;
                mapObjectPanel.Click += MapObjectPanel_Click;
                mapObjectPanel.Tag = mapObject;

                mapContainer.Controls.Add(mapObjectPanel);
            }
            mapContainer.ResumeLayout();
            mapContainer.Refresh();
        }

        protected virtual void OnCameraObjectClicked(CameraObjectClickedEventArgs e)
        {
            CameraObjectClicked?.Invoke(e);
        }

        private void MapObjectPanel_MouseEnter(Object sender, EventArgs e)
        {
            var mapObjectPanel = (TransparentPanel)sender;
            if (mapObjectPanel == null)
            {
                return;
            }
            var mapObject = (MapObjectDto)mapObjectPanel.Tag;
            if (mapObject == null)
            {
                return;
            }
            if (mapObject.Comment != String.Empty)
            {
                toolTip.SetToolTip(mapObjectPanel, mapObject.Comment);
            }
        }

        private void MapObjectPanel_Click(Object sender, EventArgs e)
        {
            var mapObjectPanel = (TransparentPanel)sender;
            if (mapObjectPanel == null)
            {
                return;
            }
            var mapObject = (MapObjectDto)mapObjectPanel.Tag;
            if (mapObject == null)
            {
                return;
            }
            switch (mapObject.ActionType)
            {
                case MapActionType.OpenCamera:
                    var camera = cameraRepository.Select(mapObject.ActionReferencedId);
                    OnCameraObjectClicked(new CameraObjectClickedEventArgs(camera));
                    break;
                case MapActionType.OpenMap:
                    var map = MapDto.FromModel(mapRepository.Select(mapObject.ActionReferencedId));
                    map.MapObjects = mapObjectRepository.SelectWhere(new { map.Id }).Select(MapObjectDto.FromModel).ToArray();
                    LoadMap(map);
                    break;
            }
        }
    }
}
