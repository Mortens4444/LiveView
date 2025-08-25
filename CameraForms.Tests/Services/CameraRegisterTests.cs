using CameraForms.Services;
using Database.Enums;
using LiveView.Core.Dto;
using Mtf.Network;
using Mtf.Network.EventArg;
using NUnit.Framework;
using System;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    public class CameraRegisterTests
    {
        private DisplayDto display;
        private EventHandler<DataArrivedEventArgs> handler;

        private Server server;

        [OneTimeSetUp]
        public void SetUp()
        {
            display = new DisplayDto { };
            handler = (s, e) => { };

            server = new Server(listenerPort: 4444);
            server.Start();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            server?.Stop();
            server.Dispose();
            server = null;
        }

        [Test]
        public void RegisterCameraShouldSendCorrectMessage()
        {
            var userId = 99L;
            var cameraId = 123L;
            var mode = CameraMode.AxVideoPlayer;

            var sut = new CameraRegister();
            var client = sut.RegisterCamera(userId, cameraId, display, handler, mode);
            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void RegisterVideoSourceShouldSendCorrectMessage()
        {
            var userId = 11L;
            var serverIp = "192.168.0.10";
            var source = "CameraA";

            var sut = new CameraRegister();
            var client = sut.RegisterVideoSource(userId, serverIp, source, display, handler);
            Assert.That(client, Is.Not.Null);
        }
    }
}