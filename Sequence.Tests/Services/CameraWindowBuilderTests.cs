using CameraForms.Dto;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Mtf.Permissions.Services;
using NUnit.Framework;
using Sequence.Dto;
using Sequence.Services;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Sequence.Tests.Services
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class CameraWindowBuilderTests
    {
        private CameraWindowBuilder builder;
        private PermissionManager<User> permissionManager;
        private ILogger<GridSequenceManager> logger;
        private IServerRepository serverRepository;
        private ICameraRepository cameraRepository;
        private ICameraFunctionRepository cameraFunctionRepository;
        private IPersonalOptionsRepository personalOptionsRepository;
        private IVideoSourceRepository videoSourceRepository;
        private IGeneralOptionsRepository generalOptionsRepository;

        [SetUp]
        public void SetUp()
        {
            DatabaseInitializer.Initialize("LiveViewConnectionString");

            permissionManager = new PermissionManager<User>();
            logger = new Mock<ILogger<GridSequenceManager>>().Object;
            serverRepository = new ServerRepository();
            cameraRepository = new CameraRepository();
            cameraFunctionRepository = new CameraFunctionRepository();
            personalOptionsRepository = new PersonalOptionsRepository();
            videoSourceRepository = new VideoSourceRepository();
            generalOptionsRepository = new GeneralOptionsRepository();

            builder = new CameraWindowBuilder(permissionManager, logger, serverRepository, cameraRepository,
                cameraFunctionRepository, personalOptionsRepository, videoSourceRepository, generalOptionsRepository);
        }

        [Test]
        public void ShowVideoWindow_WithAxVideoPictureCameraInfo_ShouldAddFormToResult()
        {
            var camera = new AxVideoPictureCameraInfo
            {
                Camera = new Camera(),
                Server = new Server(),
                GridCamera = new GridCamera()
            };
           RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithFFMpegCameraInfo_ShouldAddFormToResult()
        {
            var camera = new FFMpegCameraInfo
            {
                Url = "",
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithVideoCaptureSourceCameraInfo_ShouldAddFormToResult()
        {
            var camera = new VideoCaptureSourceCameraInfo
            {
                ServerIp = "",
                VideoSourceName = "",
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithMortoGraphyCameraInfo_ShouldAddFormToResult()
        {
            var camera = new MortoGraphyCameraInfo
            {
                Url = "",
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithVlcCameraInfo_ShouldAddFormToResult()
        {
            var camera = new VlcCameraInfo
            {
                Url = "",
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithOpenCvSharpCameraInfo_ShouldAddFormToResult()
        {
            var camera = new OpenCvSharpCameraInfo
            {
                Url = "",
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithOpenCvSharp4CameraInfo_ShouldAddFormToResult()
        {
            var camera = new OpenCvSharp4CameraInfo
            {
                Url = "",
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithSunellCameraInfo_ShouldAddFormToResult()
        {
            var camera = new SunellCameraInfo
            {
                CameraId = 1,
                CameraPort = 100,
                CameraIp = "",
                Password = "p",
                Username = "u",
                StreamId = 4,
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithSunellLegacyCameraInfo_ShouldAddFormToResult()
        {
            var camera = new SunellLegacyCameraInfo
            {
                CameraId = 1,
                CameraPort = 100,
                CameraIp = "",
                Password = "p",
                Username = "u",
                StreamId = 4,
                GridCamera = new GridCamera()
            };
            RunTest(camera);
        }

        private void RunTest(CameraInfo camera)
        {
            // Arrange
            using (var client = new Mtf.Network.Client("127.0.0.1", 4444))
            {
                var displayManager = new DisplayManager();
                var displays = displayManager.GetAll();
                var display = displays[0];
                using (var parentForm = new Form { IsMdiContainer = true })
                {
                    var result = new List<Form>();
                    var grid = new Grid
                    {
                        Columns = 4,
                        Rows = 2,
                    };
                    var gridInSequence = new GridInSequence();
                    var tuple = (grid, gridInSequence);
                
                    using (var tokenSource = new CancellationTokenSource())
                    {
                        // Act
                        builder.ShowVideoWindow(client, display, parentForm, result, camera, tuple, tokenSource);
                    }

                    // Assert
                    Assert.That(result.Count, Is.EqualTo(1));
                    Assert.IsInstanceOf<Form>(result[0]);

                    foreach (var form in result)
                    {
                        form.Close();
                    }
                }
            }
        }
    }
}
