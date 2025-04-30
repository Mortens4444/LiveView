using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using Microsoft.Extensions.Logging;
using Moq;
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
    public class GridSequenceManagerTests
    {
        private Mock<ISequenceRepository> sequenceRepositoryMock;
        private Mock<IGridInSequenceRepository> gridInSequenceRepositoryMock;
        private Mock<IGridRepository> gridRepositoryMock;
        private Mock<IServerRepository> serverRepositoryMock;
        private Mock<ICameraRepository> cameraRepositoryMock;
        private Mock<IGridCameraRepository> gridCameraRepositoryMock;

        private GridSequenceManager manager;

        [SetUp]
        public void Setup()
        {
            sequenceRepositoryMock = new Mock<ISequenceRepository>();
            gridInSequenceRepositoryMock = new Mock<IGridInSequenceRepository>();
            gridRepositoryMock = new Mock<IGridRepository>();
            serverRepositoryMock = new Mock<IServerRepository>();
            cameraRepositoryMock = new Mock<ICameraRepository>();
            gridCameraRepositoryMock = new Mock<IGridCameraRepository>();

            var servers = new ReadOnlyCollection<Server>(new List<Server>());
            var cameras = new ReadOnlyCollection<Camera>(new List<Camera>());
            var gridCameras = new ReadOnlyCollection<GridCamera>(new List<GridCamera>());

            serverRepositoryMock.Setup(x => x.SelectAll()).Returns(servers);
            cameraRepositoryMock.Setup(x => x.SelectAll()).Returns(cameras);
            gridCameraRepositoryMock.Setup(x => x.SelectAll()).Returns(gridCameras);

            manager = new GridSequenceManager(
                new Mock<PermissionManager<User>>().Object,
                sequenceRepositoryMock.Object,
                gridInSequenceRepositoryMock.Object,
                gridRepositoryMock.Object,
                new Mock<IAgentRepository>().Object,
                new Mock<IVideoSourceRepository>().Object,
                serverRepositoryMock.Object,
                cameraRepositoryMock.Object,
                new Mock<ICameraFunctionRepository>().Object,
                gridCameraRepositoryMock.Object,
                new Mock<IPersonalOptionsRepository>().Object,
                new Mock<IGeneralOptionsRepository>().Object,
                new Mock<ILogger<GridSequenceManager>>().Object,
                new Mtf.Network.Client("", 0),
                new Form(),
                new DisplayDto(),
                isMdi: false);
        }

        [TearDown]
        public void TearDown()
        {
            manager.Dispose();
        }

        [Test]
        public async Task StartSequenceAsync_InvalidId_SetsInvalidTrue()
        {
            // Arrange
            sequenceRepositoryMock.Setup(r => r.Select(It.IsAny<long>())).Returns((Database.Models.Sequence)null);

            // Act
            await manager.StartSequenceAsync(999);

            // Assert
            Assert.That(manager.Invalid, Is.True);
        }

        [Test]
        public async Task StartSequenceAsync_NoGrids_ShowsError()
        {
            // Arrange
            sequenceRepositoryMock.Setup(r => r.Select(It.IsAny<long>())).Returns(new Database.Models.Sequence());
            gridInSequenceRepositoryMock.Setup(r => r.SelectWhere(It.IsAny<object>())).Returns(new ReadOnlyCollection<GridInSequence>(new List<GridInSequence>()));
            gridRepositoryMock.Setup(r => r.SelectAll()).Returns(new ReadOnlyCollection<Grid>(new List<Grid>()));

            // Act
            await manager.StartSequenceAsync(1);

            // Assert
            Assert.That(manager.Invalid, Is.False); // nem lett invalid, de nincs rács
                                                    // A MessageBox-ot nem tudod tesztelni könnyen, csak ha kicseréled egy IErrorBox-ra pl.
        }
    }
}