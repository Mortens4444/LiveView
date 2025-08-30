using CameraForms.Services;
using Database.Enums;
using LiveView.Core.Dto;
using Mtf.Network.EventArg;
using NUnit.Framework;
using System;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    public class CameraRegisterTests : ServerBaseTest
    {
        private DisplayDto display;
        private EventHandler<DataArrivedEventArgs> handler;

        [OneTimeSetUp]
        public void SetUp()
        {
            display = new DisplayDto { };
            handler = (s, e) => { };
        }

        [Test]
        public void RegisterCameraShouldSendCorrectMessage()
        {
            var userId = 99L;
            var cameraId = 123L;
            var mode = CameraMode.AxVideoPlayer;

            var cameraRegister = new CameraRegister();
            var client = cameraRegister.RegisterCamera(userId, cameraId, display, handler, mode);
            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void RegisterVideoSourceShouldSendCorrectMessage()
        {
            var userId = 11L;
            var serverIp = "192.168.0.10";
            var source = "CameraA";

            var cameraRegister = new CameraRegister();
            var client = cameraRegister.RegisterVideoSource(userId, serverIp, source, display, handler);
            Assert.That(client, Is.Not.Null);
        }
    }
}