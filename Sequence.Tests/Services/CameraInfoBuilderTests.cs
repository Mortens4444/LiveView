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
        private ReadOnlyCollection<VideoServer> videoServers;
        private VideoServer videoServer;

        [SetUp]
        public void SetUp()
        {
            videoServer = new VideoServer { Id = 1 };
            videoServers = new ReadOnlyCollection<VideoServer>(new[] { videoServer });
        }

        [Test]
        public void GetCameraInfo_AxVideoPlayer_ReturnsAxVideoPictureCameraInfo()
        {
            var gridCamera = new GridCamera { CameraMode = CameraMode.AxVideoPlayer };
            var camera = new Camera { VideoServerId = videoServer.Id };

            var result = CameraInfoBuilder.GetCameraInfo(videoServers, gridCamera, camera, null);

            Assert.That(result, Is.InstanceOf<AxVideoPictureCameraInfo>());
            Assert.That(result.GridCamera, Is.SameAs(gridCamera));
            //Assert.That(camera, Is.EqualTo(result.Camera));
        }

        [Test]
        public void GetCameraInfo_VideoSource_WithId_ReturnsVideoCaptureSourceCameraInfo()
        {
            var gridCamera = new GridCamera { CameraMode = CameraMode.VideoSource };
            var camera = new Camera
            {
                VideoSourceId = 1,
                VideoServerId = videoServer.Id
            };
            var videoSourceInfo = new Tuple<string, string>("127.0.0.1", "source");

            var result = CameraInfoBuilder.GetCameraInfo(videoServers, gridCamera, camera, videoSourceInfo);

            var info = result as VideoCaptureSourceCameraInfo;
            Assert.That(info, Is.Not.Null);
            Assert.That(info.ServerIp, Is.EqualTo("127.0.0.1"));
            Assert.That(info.VideoSourceName, Is.EqualTo("source"));
            Assert.That(info.GridCamera, Is.SameAs(gridCamera));
        }

        [Test]
        public void GetCameraInfo_NullCamera_ReturnsNull()
        {
            var result = CameraInfoBuilder.GetCameraInfo(videoServers, new GridCamera(), null, null);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetCameraInfo_UnsupportedMode_ThrowsException()
        {
            var gridCamera = new GridCamera { CameraMode = (CameraMode)999 };
            var camera = new Camera();

            Assert.Throws<NotSupportedException>(() => CameraInfoBuilder.GetCameraInfo(videoServers, gridCamera, camera, null));
        }
    }
}
