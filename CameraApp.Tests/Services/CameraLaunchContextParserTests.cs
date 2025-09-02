using CameraApp.Services;
using CameraForms.Enums;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Drawing;

namespace CameraApp.Tests.Services
{
    [TestFixture]
    public class CameraLaunchContextParserTests
    {
        [Test]
        public void ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CameraLaunchContextParser.Parse(null, null));
        }

        [Test]
        public void ParseLength4StartCamera()
        {
            var args = new[] { "0", "123", "45", "0" };

            var ctx = CameraLaunchContextParser.Parse(args, Substitute.For<IServiceProvider>());

            Assert.That(ctx.AgentId, Is.Null);
            Assert.That(ctx.UserId, Is.EqualTo(123));
            Assert.That(ctx.StartType, Is.EqualTo(StartType.StartCamera));
            Assert.That(ctx.CameraId, Is.EqualTo(45));
        }

        [Test]
        public void ParseLength5WithNumericCameraId()
        {
            var args = new[] { "1", "100", "55", "2", "2" };

            var ctx = CameraLaunchContextParser.Parse(args, Substitute.For<IServiceProvider>());

            Assert.That(ctx.AgentId, Is.EqualTo(1));
            Assert.That(ctx.UserId, Is.EqualTo(100));
            Assert.That(ctx.StartType, Is.EqualTo(StartType.StartCameraOnDisplay));
            Assert.That(ctx.CameraId, Is.EqualTo(55));
            Assert.That(ctx.DisplayId, Is.EqualTo(2));
        }

        [Test]
        public void ParseLength5WithNonNumericCameraId()
        {
            var args = new[] { "1", "100", "192.168.1.10", "0", "1" };

            var ctx = CameraLaunchContextParser.Parse(args, Substitute.For<IServiceProvider>());

            Assert.That(ctx.AgentId, Is.EqualTo(1));
            Assert.That(ctx.UserId, Is.EqualTo(100));
            Assert.That(ctx.StartType, Is.EqualTo(StartType.StartVideoSource));
            Assert.That(ctx.ServerIp, Is.EqualTo("192.168.1.10"));
            Assert.That(ctx.VideoCaptureSource, Is.EqualTo("0"));
        }

        [Test]
        public void ParseLength6StartVideoSourceOnDisplay()
        {
            var args = new[] { "1", "200", "10.0.0.1", "file.mp4", "3", "1" };

            var ctx = CameraLaunchContextParser.Parse(args, Substitute.For<IServiceProvider>());

            Assert.That(ctx.StartType, Is.EqualTo(StartType.StartVideoSourceOnDisplay));
            Assert.That(ctx.ServerIp, Is.EqualTo("10.0.0.1"));
            Assert.That(ctx.VideoCaptureSource, Is.EqualTo("file.mp4"));
            Assert.That(ctx.DisplayId, Is.EqualTo(3));
        }

        [Test]
        public void ParseLength8StartCameraInRectangle()
        {
            var args = new[] { "0", "50", "77", "10", "20", "640", "480", "3" };

            var ctx = CameraLaunchContextParser.Parse(args, Substitute.For<IServiceProvider>());

            Assert.That(ctx.StartType, Is.EqualTo(StartType.StartCameraInRectangle));
            Assert.That(ctx.CameraId, Is.EqualTo(77));
            Assert.That(ctx.Rectangle, Is.EqualTo(new Rectangle(10, 20, 640, 480)));
        }

        [Test]
        public void ParseLength9StartVideoSourceInRectangle()
        {
            var args = new[] { "0", "50", "10.0.0.1", "file.mp4", "5", "6", "200", "150", "4" };

            var ctx = CameraLaunchContextParser.Parse(args, Substitute.For<IServiceProvider>());

            Assert.That(ctx.StartType, Is.EqualTo(StartType.StartVideoSourceInRectangle));
            Assert.That(ctx.ServerIp, Is.EqualTo("10.0.0.1"));
            Assert.That(ctx.VideoCaptureSource, Is.EqualTo("file.mp4"));
            Assert.That(ctx.Rectangle, Is.EqualTo(new Rectangle(5, 6, 200, 150)));
        }

        [Test]
        public void ParseUnsupportedArgumentsCount()
        {
            var args = new[] { "0", "1", "2" };
            Assert.Throws<NotSupportedException>(() => CameraLaunchContextParser.Parse(args, Substitute.For<IServiceProvider>()));
        }
    }
}