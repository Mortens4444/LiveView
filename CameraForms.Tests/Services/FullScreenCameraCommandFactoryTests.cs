using CameraForms.Network.Commands;
using CameraForms.Services;
using LiveView.Core.Enums.Network;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class FullScreenCameraCommandFactoryTests
    {
        private Form form;
        private FullScreenCameraCommandFactory fullScreenCameraCommandFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            form = new Form();
            fullScreenCameraCommandFactory = new FullScreenCameraCommandFactory(form, null);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            form.Dispose();
        }

        [Test]
        public void EmptyOrNullMessagesReturnsEmptyCollection()
        {
            var res1 = fullScreenCameraCommandFactory.CreateCommands(null);
            var res2 = fullScreenCameraCommandFactory.CreateCommands(String.Empty);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(res1, Is.Empty);
                Assert.That(res2, Is.Empty);
            }
        }

        [TestCase(NetworkCommand.Close)]
        [TestCase(NetworkCommand.Kill)]
        public void CloseOrKillReturnsCloseCommand(NetworkCommand cmd)
        {
            var result = fullScreenCameraCommandFactory.CreateCommands(cmd.ToString());

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].GetType().Name, Is.EqualTo(nameof(CloseCommand)));
        }

        [Test]
        public void MultipleLinesReturnsExpectedCommandTypesInOrder()
        {
            var messages = String.Join(Environment.NewLine, new[]
            {
                NetworkCommand.PanToEastAndTiltToNorth.ToString(),
                NetworkCommand.PanToWestAndTiltToSouth.ToString(),
                NetworkCommand.MoveToPresetZero.ToString(),
                "UNKNOWN_CMD"
            });

            var result = fullScreenCameraCommandFactory.CreateCommands(messages);

            Assert.That(result, Has.Count.EqualTo(4));

            var names = result.Select(c => c.GetType().Name).ToArray();
            using (Assert.EnterMultipleScope())
            {
                Assert.That(names[0], Is.EqualTo(nameof(FullScreenCameraPanToEastAndTiltToNorthCommand)));
                Assert.That(names[1], Is.EqualTo(nameof(FullScreenCameraPanToWestAndTiltToSouthCommand)));
                Assert.That(names[2], Is.EqualTo(nameof(FullScreenCameraMoveToPresetZeroCommand)));
                Assert.That(names[3], Is.EqualTo(nameof(ShowErrorCommand)));
            }
        }

        [Test]
        public void IndividualCommandMappingsAreCorrect()
        {
            var map = new[]
            {
                new { Cmd = NetworkCommand.PanToEastAndTiltToNorth.ToString(), Expected = nameof(FullScreenCameraPanToEastAndTiltToNorthCommand) },
                new { Cmd = NetworkCommand.PanToWestAndTiltToNorth.ToString(), Expected = nameof(FullScreenCameraPanToWestAndTiltToNorthCommand) },
                new { Cmd = NetworkCommand.MoveToPresetZero.ToString(), Expected = nameof(FullScreenCameraMoveToPresetZeroCommand) },
                new { Cmd = NetworkCommand.PanToEast.ToString(), Expected = nameof(FullScreenCameraPanToEastCommand) },
                new { Cmd = NetworkCommand.PanToWest.ToString(), Expected = nameof(FullScreenCameraPanToWestCommand) },
                new { Cmd = NetworkCommand.TiltToNorth.ToString(), Expected = nameof(FullScreenCameraTiltToNorthCommand) },
                new { Cmd = NetworkCommand.TiltToSouth.ToString(), Expected = nameof(FullScreenCameraTiltToSouthCommand) },
                new { Cmd = NetworkCommand.StopPanAndTilt.ToString(), Expected = nameof(FullScreenCameraStopPanAndTiltCommand) },
                new { Cmd = NetworkCommand.ZoomOut.ToString(), Expected = nameof(FullScreenCameraZoomOutCommand) }
            };

            foreach (var pair in map)
            {
                var result = fullScreenCameraCommandFactory.CreateCommands(pair.Cmd);
                Assert.That(result, Has.Count.EqualTo(1), "Expected single command for " + pair.Cmd);
                Assert.That(result[0].GetType().Name, Is.EqualTo(pair.Expected), "Type mismatch for " + pair.Cmd);
            }
        }
    }
}
