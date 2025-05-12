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
        private readonly Control mapContainer;
        private readonly ToolTip toolTip;

        public delegate void CameraObjectClickedEventHandler(CameraObjectClickedEventArgs e);
        public event CameraObjectClickedEventHandler CameraObjectClicked;

        public delegate void VideoSourceObjectClickedEventHandler(VideoSourceObjectClickedEventArgs e);
        public event VideoSourceObjectClickedEventHandler VideoSourceObjectClicked;

        private readonly IMapRepository mapRepository;
        private readonly IMapObjectRepository mapObjectRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly IGridCameraRepository gridCameraRepository;
        private readonly IAgentRepository agentRepository;
        private readonly IVideoSourceRepository videoSourceRepository;

        public MapLoader(Control mapContainer, ToolTip toolTip, MapLoaderDependencies mapLoaderDependencies)
        {
            this.mapContainer = mapContainer;
            this.toolTip = toolTip;
            agentRepository = mapLoaderDependencies.AgentRepository;
            mapRepository = mapLoaderDependencies.MapRepository;
            mapObjectRepository = mapLoaderDependencies.MapObjectRepository;
            cameraRepository = mapLoaderDependencies.CameraRepository;
            gridCameraRepository = mapLoaderDependencies.GridCameraRepository;
            videoSourceRepository = mapLoaderDependencies.VideoSourceRepository;
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
            var originalSize = new Size(map.OriginalWidth, map.OriginalHeight);
            if (mapContainer is MtfPictureBox pictureBox)
            {
                pictureBox.Image = map.MapImage;
                pictureBox.OriginalSize = originalSize;
            }
            else
            {
                mapContainer.BackgroundImage = map.MapImage;
                // Need Resize event handler
            }

            foreach (var mapObject in map.MapObjects)
            {
                var mapObjectPanel = new TransparentPanel
                {
                    Location = mapObject.Location,
                    Size = mapObject.Size,
                    BackColor = Color.Black
                };

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
            var controlsLocationAndSize = map.MapObjects.Select(mo => new Mtf.Controls.Models.LocationAndSize(mo.Location.X, mo.Location.Y, mo.Size.Width, mo.Size.Height)).ToList();

            if (mapContainer is MtfPictureBox mtfPictureBox)
            {
                MtfPictureBox.RelocateControls(mtfPictureBox, originalSize, controlsLocationAndSize);
            }
            mapContainer.Tag = (map, controlsLocationAndSize);
            mapContainer.ResumeLayout();
            mapContainer.Refresh();
        }

        protected virtual void OnCameraObjectClicked(CameraObjectClickedEventArgs e)
        {
            CameraObjectClicked?.Invoke(e);
        }

        protected virtual void OnVideoSourceObjectClicked(VideoSourceObjectClickedEventArgs e)
        {
            VideoSourceObjectClicked?.Invoke(e);
        }

        private void MapObjectPanel_MouseEnter(object sender, EventArgs e)
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
                case MapActionType.OpenVideoSource:
                    var videoSourceModel = videoSourceRepository.Select(mapObject.ActionReferencedId);
                    var agent = agentRepository.Select(videoSourceModel.AgentId);
                    var videoSource = new VideoSourceDto
                    {
                        EndPoint = $"{agent.ServerIp}:0",
                        Name = videoSourceModel.Name
                    };
                    OnVideoSourceObjectClicked(new VideoSourceObjectClickedEventArgs(videoSource));
                    break;
                case MapActionType.OpenMap:
                    var map = MapDto.FromModel(mapRepository.Select(mapObject.ActionReferencedId), mapObjectRepository);
                    LoadMap(map);
                    break;
            }
        }
    }
}
