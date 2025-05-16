using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using Microsoft.Extensions.Logging;
using Moq;
using Mtf.Network;
using Mtf.Permissions.Services;
using NUnit.Framework;
using Sequence.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sequence.Tests.Services
{
    [TestFixture]
    [Apartment(System.Threading.ApartmentState.STA)]
    public class GridSequenceManagerTests
    {
        private Mock<ISequenceRepository> sequenceRepositoryMock;
        private Mock<IGridInSequenceRepository> gridInSequenceRepositoryMock;
        private Mock<IAgentRepository> agentRepositoryMock;
        private Mock<IGridRepository> gridRepositoryMock;
        private Mock<IServerRepository> serverRepositoryMock;
        private Mock<ICameraRepository> cameraRepositoryMock;
        private Mock<IGridCameraRepository> gridCameraRepositoryMock;
        private Mock<IVideoSourceRepository> videoSourceRepositoryMock;

        private GridSequenceManager manager;

        [SetUp]
        public void Setup()
        {
            sequenceRepositoryMock = new Mock<ISequenceRepository>();
            gridInSequenceRepositoryMock = new Mock<IGridInSequenceRepository>();
            agentRepositoryMock = new Mock<IAgentRepository>();
            gridRepositoryMock = new Mock<IGridRepository>();
            serverRepositoryMock = new Mock<IServerRepository>();
            cameraRepositoryMock = new Mock<ICameraRepository>();
            gridCameraRepositoryMock = new Mock<IGridCameraRepository>();
            videoSourceRepositoryMock = new Mock<IVideoSourceRepository>();

            sequenceRepositoryMock.Setup(r => r.Select(It.Is<long>(id => id == 1)))
                .Returns(new Database.Models.Sequence
                {
                    Id = 1,
                    Name = "Sequence"
                });

            gridInSequenceRepositoryMock.Setup(r => r.SelectWhere(It.IsAny<object>()))
                .Returns(new ReadOnlyCollection<GridInSequence>(
                    new List<GridInSequence>
                    {
                        new GridInSequence
                        {
                            Id = 1,
                            SequenceId = 1,
                            GridId = 1
                        }
                    }));

            serverRepositoryMock.Setup(r => r.SelectAll())
                .Returns(new ReadOnlyCollection<Database.Models.Server>(
                    new List<Database.Models.Server>
                    {
                        new Database.Models.Server
                        {
                            Id = 1,
                            IpAddress = "127.0.0.1",
                            Username = "u",
                            Password = "p"
                        }
                    }));

            cameraRepositoryMock.Setup(r => r.SelectAll())
                .Returns(new ReadOnlyCollection<Camera>(
                    new List<Camera>
                    {
                        new Camera
                        {
                            Id = 1,
                            CameraId = 1,
                            CameraName = "Cam 1",
                            ServerId = 1,
                            FullscreenMode = CameraMode.AxVideoPlayer,
                        },
                        new Camera
                        {
                            Id = 2,
                            CameraId = 2,
                            CameraName = "Cam 2",
                            ServerId = 1,
                            FullscreenMode = CameraMode.FFMpeg,
                        },
                        new Camera
                        {
                            Id = 3,
                            CameraId = 3,
                            CameraName = "Cam 3",
                            ServerId = 1,
                            FullscreenMode = CameraMode.MortoGraphy,
                        },
                        new Camera
                        {
                            Id = 4,
                            CameraId = 4,
                            CameraName = "Cam 4",
                            ServerId = 1,
                            FullscreenMode = CameraMode.OpenCvSharp,
                        },
                        new Camera
                        {
                            Id = 5,
                            CameraId = 5,
                            CameraName = "Cam 5",
                            ServerId = 1,
                            FullscreenMode = CameraMode.OpenCvSharp4,
                        },
                        new Camera
                        {
                            Id = 6,
                            CameraId = 6,
                            CameraName = "Cam 6",
                            ServerId = 1,
                            FullscreenMode = CameraMode.SunellCamera,
                        },
                        new Camera
                        {
                            Id = 7,
                            CameraId = 7,
                            CameraName = "Cam 7",
                            ServerId = 1,
                            FullscreenMode = CameraMode.SunellLegacyCamera,
                        },
                        new Camera
                        {
                            Id = 8,
                            CameraId = 8,
                            CameraName = "Cam 8",
                            ServerId = 1,
                            FullscreenMode = CameraMode.VideoSource,
                            VideoSourceId = 1
                        },
                        new Camera
                        {
                            Id = 9,
                            CameraId = 9,
                            CameraName = "Cam 9",
                            ServerId = 1,
                            FullscreenMode = CameraMode.Vlc,
                        },
                    }));

            videoSourceRepositoryMock.Setup(r => r.SelectAll())
                .Returns(new ReadOnlyCollection<VideoSource>(
                    new List<VideoSource>
                    {
                        new VideoSource
                        {
                            Id = 1,
                            AgentId = 1,
                            Port = 1
                        }
                    }));

            gridRepositoryMock.Setup(r => r.SelectAll())
                .Returns(new ReadOnlyCollection<Grid>(
                    new List<Grid>
                    {
                        new Grid
                        {
                            Id = 1,
                            Name = "Grid",
                            Rows = 5,
                            Columns = 2
                        }
                    }));

            gridCameraRepositoryMock.Setup(r => r.SelectAll())
                .Returns(new ReadOnlyCollection<GridCamera>(
                    new List<GridCamera>
                    {
                        new GridCamera
                        {
                            Id = 1,
                            CameraId = 1,
                            CameraMode = CameraMode.AxVideoPlayer,
                            GridId = 1,
                            InitRow = 0,
                            EndRow = 1,
                            InitCol = 0,
                            EndCol = 1
                        },
                        new GridCamera
                        {
                            Id = 2,
                            CameraId = 2,
                            CameraMode = CameraMode.FFMpeg,
                            GridId = 1,
                            InitRow = 0,
                            EndRow = 1,
                            InitCol = 1,
                            EndCol = 2
                        },
                        new GridCamera
                        {
                            Id = 3,
                            CameraId = 3,
                            CameraMode = CameraMode.MortoGraphy,
                            GridId = 1,
                            InitRow = 1,
                            EndRow = 2,
                            InitCol = 0,
                            EndCol = 1
                        },
                        new GridCamera
                        {
                            Id = 4,
                            CameraId = 4,
                            CameraMode = CameraMode.OpenCvSharp,
                            GridId = 1,
                            InitRow = 1,
                            EndRow = 2,
                            InitCol = 1,
                            EndCol = 2
                        },
                        new GridCamera
                        {
                            Id = 5,
                            CameraId = 5,
                            CameraMode = CameraMode.OpenCvSharp4,
                            GridId = 1,
                            InitRow = 2,
                            EndRow = 3,
                            InitCol = 0,
                            EndCol = 1
                        },
                        new GridCamera
                        {
                            Id = 6,
                            CameraId = 6,
                            CameraMode = CameraMode.SunellCamera,
                            GridId = 1,
                            InitRow = 2,
                            EndRow = 3,
                            InitCol = 1,
                            EndCol = 2
                        },
                        new GridCamera
                        {
                            Id = 7,
                            CameraId = 7,
                            CameraMode = CameraMode.SunellLegacyCamera,
                            GridId = 1,
                            InitRow = 3,
                            EndRow = 4,
                            InitCol = 0,
                            EndCol = 1
                        },
                        new GridCamera
                        {
                            Id = 8,
                            CameraId = 8,
                            CameraMode = CameraMode.VideoSource,
                            GridId = 1,
                            InitRow = 3,
                            EndRow = 4,
                            InitCol = 1,
                            EndCol = 2
                        },
                        new GridCamera
                        {
                            Id = 9,
                            CameraId = 9,
                            CameraMode = CameraMode.Vlc,
                            GridId = 1,
                            InitRow = 4,
                            EndRow = 5,
                            InitCol = 0,
                            EndCol = 1
                        },
                    }));

            using (var parentForm = new Form() { IsMdiContainer = true })
            {
                using (var client = new Client("", 0))
                {
                    manager = new GridSequenceManager(
                    new Mock<PermissionManager<User>>().Object,
                    sequenceRepositoryMock.Object,
                    gridInSequenceRepositoryMock.Object,
                    gridRepositoryMock.Object,
                    agentRepositoryMock.Object,
                    videoSourceRepositoryMock.Object,
                    serverRepositoryMock.Object,
                    cameraRepositoryMock.Object,
                    new Mock<ICameraFunctionRepository>().Object,
                    gridCameraRepositoryMock.Object,
                    new Mock<IPersonalOptionsRepository>().Object,
                    new Mock<IGeneralOptionsRepository>().Object,
                    new Mock<ILogger<GridSequenceManager>>().Object,
                    client,
                    parentForm,
                    new DisplayDto(),
                    true);
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            manager.Dispose();
        }

        [Test]
        public async Task StartSequenceAsync()
        {
            // Act
            await manager.StartSequenceAsync(1).ConfigureAwait(false);

            // Assert
            Assert.That(manager.Invalid, Is.False);
        }

        [Test]
        public async Task StartSequenceAsync_NoGrids()
        {
            // Arrange

            // Act
            await manager.StartSequenceAsync(2).ConfigureAwait(false);

            // Assert
            Assert.That(manager.Invalid, Is.True);
        }
    }
}