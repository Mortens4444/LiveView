using CameraForms.Dto;
using Database.Enums;
using Database.Models;
using NUnit.Framework;
using Sequence.Dto;
using Sequence.Services;
using System;
using System.Collections.ObjectModel;

namespace Sequence.Tests.Services
{
    [TestFixture]
    public class CameraInfoBuilderTests
    {
        private ReadOnlyCollection<Server> servers;
        private Server server;

        [SetUp]
        public void SetUp()
        {
            server = new Server { Id = 1 };
            servers = new ReadOnlyCollection<Server>(new[] { server });
        }

        [Test]
        public void GetCameraInfo_AxVideoPlayer_ReturnsAxVideoPictureCameraInfo()
        {
            var gridCamera = new GridCamera { CameraMode = CameraMode.AxVideoPlayer };
            var camera = new Camera { ServerId = server.Id };

            var result = CameraInfoBuilder.GetCameraInfo(servers, gridCamera, camera, null);

            Assert.IsInstanceOf<AxVideoPictureCameraInfo>(result);
            Assert.AreSame(gridCamera, result.GridCamera);
            //Assert.AreSame(camera, result.Camera);
        }

        [Test]
        public void GetCameraInfo_VideoSource_WithId_ReturnsVideoCaptureSourceCameraInfo()
        {
            var gridCamera = new GridCamera { CameraMode = CameraMode.VideoSource };
            var camera = new Camera
            {
                VideoSourceId = 1,
                ServerId = server.Id
            };
            var videoSourceInfo = new Tuple<string, string>("127.0.0.1", "source");

            var result = CameraInfoBuilder.GetCameraInfo(servers, gridCamera, camera, videoSourceInfo);

            var info = result as VideoCaptureSourceCameraInfo;
            Assert.IsNotNull(info);
            Assert.AreEqual("127.0.0.1", info.ServerIp);
            Assert.AreEqual("source", info.VideoSourceName);
            Assert.AreSame(gridCamera, info.GridCamera);
        }

        [Test]
        public void GetCameraInfo_NullCamera_ReturnsNull()
        {
            var result = CameraInfoBuilder.GetCameraInfo(servers, new GridCamera(), null, null);
            Assert.IsNull(result);
        }

        [Test]
        public void GetCameraInfo_UnsupportedMode_ThrowsException()
        {
            var gridCamera = new GridCamera { CameraMode = (CameraMode)999 };
            var camera = new Camera();

            Assert.Throws<NotSupportedException>(() => CameraInfoBuilder.GetCameraInfo(servers, gridCamera, camera, null));
        }
    }
}
