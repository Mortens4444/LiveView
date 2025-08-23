using CameraForms.Dto;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using Database.Services;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using NUnit.Framework;
using Sequence.Dto;
using Sequence.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
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
        private IAgentRepository agentRepository;
        private ICameraRepository cameraRepository;
        private ICameraFunctionRepository cameraFunctionRepository;
        private IPersonalOptionsRepository personalOptionsRepository;
        private IVideoSourceRepository videoSourceRepository;
        private IGeneralOptionsRepository generalOptionsRepository;
        
        private const int CameraId = 3; // // This must be an existing Camera in the database.
        private const int VideoServerId = 1; // // This must be an existing VideoServer in the database.
        private const int GridCameraId = 2; // This must be an existing GridCamera in the database.

        [SetUp]
        public void SetUp()
        {
            DatabaseInitializer.Initialize("LiveViewConnectionString");

            permissionManager = new PermissionManager<User>();
            permissionManager.Login(new Mtf.Permissions.Models.User<User>
            {
                Tag = new User
                {
                    Id = 2
                },
                Groups = new System.Collections.Generic.List<Mtf.Permissions.Models.Group>
                {
                    new Mtf.Permissions.Models.Group
                    {
                        Id = 2,
                        Permissions = new System.Collections.Generic.List<Mtf.Permissions.Models.Permission>
                        {
                            new Mtf.Permissions.Models.Permission
                            {
                                PermissionGroup = typeof(CameraGroupPermissions_001_060),
                                PermissionValue = (long)CameraGroupPermissions_001_060.Camera_001
                            }
                        }
                    }
                }
            });
            logger = new Mock<ILogger<GridSequenceManager>>().Object;
            agentRepository = new AgentRepository();
            cameraRepository = new CameraRepository();
            cameraFunctionRepository = new CameraFunctionRepository();
            personalOptionsRepository = new PersonalOptionsRepository();
            videoSourceRepository = new VideoSourceRepository();
            generalOptionsRepository = new GeneralOptionsRepository();

            builder = new CameraWindowBuilder(permissionManager, logger, agentRepository, cameraRepository,
                new CameraPermissionRepository(), new PermissionRepository(), new OperationRepository(), cameraFunctionRepository,
                personalOptionsRepository, new GroupMembersRepository(), videoSourceRepository, generalOptionsRepository);
        }

        [Test]
        public void ShowVideoWindow_WithAxVideoPictureCameraInfo_ShouldAddFormToResult()
        {
            var camera = new AxVideoPictureCameraInfo
            {
                Camera = new Camera
                {
                    Id = CameraId,
                    VideoServerId = VideoServerId
                },
                Server = new VideoServer
                {
                    Id = VideoServerId
                },
                GridCamera = GetGridCamera()
            };
           RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithFFMpegCameraInfo_ShouldAddFormToResult()
        {
            var camera = new FFMpegCameraInfo
            {
                Url = "",
                GridCamera = GetGridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithVideoCaptureSourceCameraInfo_ShouldAddFormToResult()
        {
            var camera = new VideoCaptureSourceCameraInfo
            {
                ServerIp = "192.168.0.58",
                VideoSourceName = "0",
                GridCamera = GetGridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithMortoGraphyCameraInfo_ShouldAddFormToResult()
        {
            var camera = new MortoGraphyCameraInfo
            {
                Url = "",
                GridCamera = GetGridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithVlcCameraInfo_ShouldAddFormToResult()
        {
            var camera = new VlcCameraInfo
            {
                Url = "",
                GridCamera = GetGridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithOpenCvSharpCameraInfo_ShouldAddFormToResult()
        {
            var camera = new OpenCvSharpCameraInfo
            {
                Url = "",
                GridCamera = GetGridCamera()
            };
            RunTest(camera);
        }

        [Test]
        public void ShowVideoWindow_WithOpenCvSharp4CameraInfo_ShouldAddFormToResult()
        {
            var camera = new OpenCvSharp4CameraInfo
            {
                Url = "",
                GridCamera = GetGridCamera()
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
                GridCamera = GetGridCamera()
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
                GridCamera = GetGridCamera()
            };
            RunTest(camera);
        }

        private GridCamera GetGridCamera()
        {
            return new GridCamera
            {
                CameraId = CameraId,
                Id = GridCameraId
            };
        }

        private void RunTest(CameraInfo camera)
        {
            const int cameraCount = 16;

            using (var client = new Mtf.Network.Client("127.0.0.1", 4444))
            {
                var displayManager = new DisplayManager();
                var displays = displayManager.GetAll();
                var display = displays[0];

                using (var parentForm = new Form { IsMdiContainer = true })
                {
                    var numberOfCameras = 0;
                    var shownCount = 0;
                    var doneEvent = new ManualResetEventSlim(false);

                    parentForm.Load += (s, e) =>
                    {
                        var grid = new Grid { Columns = 4, Rows = 2 };
                        var gridInSequence = new SequenceGrid();
                        var tuple = (grid, gridInSequence);
                        var tokenSource = new CancellationTokenSource();

                        for (int i = 0; i < cameraCount; i++)
                        {
                            var form = builder.ShowVideoWindow(display, parentForm, camera, tuple, tokenSource);
                            form.Shown += (_, __) =>
                            {
                                Interlocked.Increment(ref numberOfCameras);
                                Interlocked.Increment(ref shownCount);
                                form.Close();
                                if (shownCount == cameraCount)
                                {
                                    doneEvent.Set();
                                }
                            };
                        }
                    };

                    parentForm.Shown += (s, e) =>
                    {
                        Task.Run(() =>
                        {
                            if (!doneEvent.Wait(TimeSpan.FromSeconds(10)))
                            {
                                throw new TimeoutException("Test failed with a timeout.");
                            }

                            parentForm.Invoke(new Action(() => parentForm.Close()));
                        });
                    };

                    parentForm.Show();

                    while (parentForm.Visible)
                    {
                        Application.DoEvents();
                    }

                    Assert.That(numberOfCameras, Is.EqualTo(cameraCount));
                }
            }
        }
    }
}
