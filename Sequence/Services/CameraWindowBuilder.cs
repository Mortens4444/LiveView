using CameraForms.Dto;
using CameraForms.Forms;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using Sequence.Dto;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Sequence.Services
{
    public class CameraWindowBuilder
    {
        private readonly ILogger<GridSequenceManager> logger;
        private readonly PermissionManager<User> permissionManager;
        private readonly IAgentRepository agentRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly IGeneralOptionsRepository generalOptionsRepository;

        public CameraWindowBuilder(PermissionManager<User> permissionManager, ILogger<GridSequenceManager> logger,
            IAgentRepository agentRepository, IServerRepository serverRepository, ICameraRepository cameraRepository,
            ICameraFunctionRepository cameraFunctionRepository, IPersonalOptionsRepository personalOptionsRepository,
            IVideoSourceRepository videoSourceRepository, IGeneralOptionsRepository generalOptionsRepository)
        {
            this.permissionManager = permissionManager;
            this.logger = logger;
            this.agentRepository = agentRepository;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            this.videoSourceRepository = videoSourceRepository;
            this.generalOptionsRepository = generalOptionsRepository;
        }

        public Form ShowVideoWindow(DisplayDto display, Form parentForm, CameraInfo camera, (Grid grid, GridInSequence gridInSequence) gridInSequence, CancellationTokenSource cancellationTokenSource)
        {
            Form result = null;
            
            try
            {
                if (camera is AxVideoPictureCameraInfo videoPictureCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    result = new AxVideoCameraWindow(permissionManager, personalOptionsRepository, generalOptionsRepository, videoPictureCameraInfo.Camera, videoPictureCameraInfo.Server, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    result = new VideoSourceCameraWindow(permissionManager, agentRepository, videoSourceRepository, cameraRepository, cameraFunctionRepository, personalOptionsRepository, videoCaptureSourceCameraInfo, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is FFMpegCameraInfo fFMpegCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    result = new FFMpegCameraWindow(permissionManager, cameraRepository, cameraFunctionRepository, personalOptionsRepository, fFMpegCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is MortoGraphyCameraInfo mortoGraphyCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    result = new MortoGraphyCameraWindow(permissionManager, cameraRepository, cameraFunctionRepository, personalOptionsRepository, videoSourceRepository, mortoGraphyCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is VlcCameraInfo vlcCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    result = new VlcCameraWindow(permissionManager, cameraRepository, cameraFunctionRepository, personalOptionsRepository, vlcCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is OpenCvSharpCameraInfo openCvSharpCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    result = new OpenCvSharpCameraWindow(permissionManager, cameraRepository, cameraFunctionRepository, personalOptionsRepository, openCvSharpCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is OpenCvSharp4CameraInfo openCvSharp4CameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    result = new OpenCvSharp4CameraWindow(permissionManager, cameraRepository, cameraFunctionRepository, personalOptionsRepository, openCvSharp4CameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is SunellCameraInfo sunellCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                    result = new SunellCameraWindow(permissionManager, cameraRepository, personalOptionsRepository, sunellCameraInfo, rectangle, camera.GridCamera)
                    {
                        TopMost = true
                    };
                }
                else if (camera is SunellLegacyCameraInfo sunellLegacyCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                    result = new SunellLegacyCameraWindow(permissionManager, cameraRepository, personalOptionsRepository, sunellLegacyCameraInfo, rectangle, camera.GridCamera)
                    {
                        TopMost = true
                    };
                }

                if (result != null)
                {
                    result.Show();
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex, "Cannot open video window.");
            }

            return result;
        }
    }
}
