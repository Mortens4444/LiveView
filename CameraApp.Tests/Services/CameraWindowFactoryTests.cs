using CameraApp.Services;
using CameraForms.Dto;
using CameraForms.Enums;
using Database.Enums;
using Database.Repositories;
using Mtf.Database;
using Mtf.Network;
using Mtf.Network.Interfaces;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CameraApp.Tests.Services
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class CameraWindowFactoryTests
    {
        private Server server;
        private CameraWindowFactory factory;
        private IServiceProvider serviceProvider;

        [OneTimeSetUp]
        public void SetUp()
        {
            factory = new CameraWindowFactory();
            serviceProvider = ServiceProviderFactory.Create();

            server = new Server(listenerPort: 4444);
            server.Start();

            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LiveView;Integrated Security=True;Encrypt=True;";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            server?.Stop();
            server.Dispose();
            server = null;
            BaseRepository.DatabaseScriptsAssembly = null;
            BaseRepository.ConnectionString = null;
        }

        [TestCase(CameraMode.AxVideoPlayer, "AxVideoCameraWindow")]
        [TestCase(CameraMode.FFMpeg, "FFMpegCameraWindow")]
        [TestCase(CameraMode.MortoGraphy, "MortoGraphyCameraWindow")]
        [TestCase(CameraMode.OpenCvSharp, "OpenCvSharpCameraWindow")]
        [TestCase(CameraMode.OpenCvSharp4, "OpenCvSharp4CameraWindow")]
        [TestCase(CameraMode.SunellCamera, "SunellCameraWindow")]
        [TestCase(CameraMode.SunellLegacyCamera, "SunellLegacyCameraWindow")]
        [TestCase(CameraMode.VideoSource, "VideoSourceCameraWindow")]
        [TestCase(CameraMode.Vlc, "VlcCameraWindow")]
        public void CreateKnownMode(CameraMode mode, string expectedTypeName)
        {
            var ctx = new CameraLaunchContext(serviceProvider)
            {
                CameraMode = mode,
                CameraId = 3,
                DisplayId = 1,
                UserId = 2,
                StartType = StartType.StartCamera
            };

            var form = factory.Create(ctx);

            Assert.That(form, Is.Not.Null, "Expected non-null Form for mode " + mode);
            Assert.That(form.GetType().Name, Is.EqualTo(expectedTypeName), "Form type name mismatch for mode " + mode);
            Assert.That(form, Is.InstanceOf<Form>());

            form.Dispose();
        }

        [Test]
        public void CreateChromium()
        {
            var ctx = new CameraLaunchContext(serviceProvider) { CameraMode = CameraMode.Chromium };

            var form = factory.Create(ctx);

            Assert.That(form, Is.Null);
        }

        [Test]
        public void CreateUnsupportedMode()
        {
            var ctx = new CameraLaunchContext(serviceProvider) { CameraMode = (CameraMode)999 };

            Assert.Throws<NotSupportedException>(() => factory.Create(ctx));
        }
    }
}
