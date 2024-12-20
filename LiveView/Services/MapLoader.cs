using Database.Interfaces;
using Database.Models;
using LiveView.CustomEventArgs;
using LiveView.Dto;
using Mtf.Controls;
using Mtf.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Services
{
    public class MapLoader
    {
        private readonly MtfPictureBox mapContainer;
        private readonly ToolTip toolTip;

        public delegate void CameraObjectClickedEventHandler(CameraObjectClickedEventArgs e);
        public event CameraObjectClickedEventHandler CameraObjectClicked;

        private readonly IMapRepository<Map> mapRepository;
        private readonly ICameraRepository<Camera> cameraRepository;

        public MapLoader(MtfPictureBox mapContainer, ToolTip toolTip, IMapRepository<Map> mapRepository, ICameraRepository<Camera> cameraRepository)
        {
            this.mapContainer = mapContainer;
            this.toolTip = toolTip;
            this.mapRepository = mapRepository;
            this.cameraRepository = cameraRepository;
        }

        public void LoadMap(MapDto map)
        {
            if (map == null)
            {
                return;
            }

            mapContainer.Controls.Clear();
            mapContainer.Image = map.MapImage;
            mapContainer.OriginalSize = new Size(map.OriginalWidth, map.OriginalHeight);

            foreach (var mapObject in map.MapObjects)
            {
                var mapObjectPanel = new TransparentPanel
                {
                    Location = new Point(mapObject.Location.X, mapObject.Location.Y),
                    Size = new Size(mapObject.Size.Width, mapObject.Size.Height),
                    BackColor = Color.Black
                };

                var image = (Bitmap)mapObject.Image;
                if (image != null)
                {
                    mapObjectPanel.BackgroundImage = image;
                }

                mapObjectPanel.BackgroundImageLayout = ImageLayout.Zoom;
                mapObjectPanel.MouseEnter += MapObjectPanel_MouseEnter;
                mapObjectPanel.MouseClick += MapObjectPanel_MouseClick;
                mapObjectPanel.Tag = mapObject;

                mapContainer.Controls.Add(mapObjectPanel);
            }
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

        private void MapObjectPanel_MouseClick(Object sender, MouseEventArgs e)
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
                    var camera = cameraRepository.Get(mapObject.ActionReferencedId);
                    OnCameraObjectClicked(new CameraObjectClickedEventArgs(CameraDto.FromModel(camera)));
                    break;
                case MapActionType.OpenMap:
                    var map = mapRepository.Get(mapObject.ActionReferencedId);
                    LoadMap(MapDto.FromModel(map));
                    break;
            }
        }
    }
}
