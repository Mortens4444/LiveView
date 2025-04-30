using CameraForms.Dto;
using CameraForms.Forms;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.Network;
using Mtf.Permissions.Services;
using Sequence.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Sequence.Services
{
    public class CameraWindowBuilder
    {
        private readonly ILogger<GridSequenceManager> logger;
        private readonly PermissionManager<User> permissionManager;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IAgentRepository agentRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;

        public CameraWindowBuilder(PermissionManager<User> permissionManager, ILogger<GridSequenceManager> logger,
            IServerRepository serverRepository, ICameraRepository cameraRepository, IAgentRepository agentRepository,
            ICameraFunctionRepository cameraFunctionRepository, IPersonalOptionsRepository personalOptionsRepository,
            IVideoSourceRepository videoSourceRepository)
        {
            this.permissionManager = permissionManager;
            this.logger = logger;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
            this.agentRepository = agentRepository;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            this.videoSourceRepository = videoSourceRepository;
        }

        public void ShowVideoWindow(Client client, DisplayDto display, Form parentForm, List<Form> result, CameraInfo camera, (Grid grid, GridInSequence gridInSequence) gridInSequence, CancellationTokenSource cancellationTokenSource)
        {
            try
            {
                Form videoForm = null;

                if (camera is AxVideoPictureCameraInfo videoPictureCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new AxVideoCameraWindow(permissionManager, serverRepository, cameraRepository, personalOptionsRepository, videoPictureCameraInfo.Camera, videoPictureCameraInfo.Server, rectangle, camera.GridCamera, cancellationTokenSource.Token)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new VideoSourceCameraWindow(client, permissionManager, cameraFunctionRepository, personalOptionsRepository, videoCaptureSourceCameraInfo, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is FFMpegCameraInfo fFMpegCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new FFMpegCameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, fFMpegCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is MortoGraphyCameraInfo mortoGraphyCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new MortoGraphyCameraWindow(permissionManager, agentRepository, cameraRepository, cameraFunctionRepository, personalOptionsRepository, videoSourceRepository, mortoGraphyCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is VlcCameraInfo vlcCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new VlcCameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, vlcCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is OpenCvSharpCameraInfo openCvSharpCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new OpenCvSharpCameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, openCvSharpCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is OpenCvSharp4CameraInfo openCvSharp4CameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new OpenCvSharp4CameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, openCvSharp4CameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is SunellCameraInfo sunellCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                    videoForm = new SunellCameraWindow(permissionManager, personalOptionsRepository, sunellCameraInfo, rectangle, camera.GridCamera)
                    {
                        TopMost = true
                    };
                }
                else if (camera is SunellLegacyCameraInfo sunellLegacyCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                    videoForm = new SunellLegacyCameraWindow(permissionManager, personalOptionsRepository, sunellLegacyCameraInfo, rectangle, camera.GridCamera)
                    {
                        TopMost = true
                    };
                }

                if (videoForm != null)
                {
                    videoForm.Show();
                    result.Add(videoForm);
                }
            }
            catch (Exception ex)
            {
#if NET6_0_OR_GREATER
                logger.LogError(ex, "Cannot open video window.");
#else
                logger.LogError($"Cannot open video window: {ex}");
#endif
            }
        }
    }
}
