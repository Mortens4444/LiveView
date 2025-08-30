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
    public class AxVideoPlayerWindowCommandFactoryTests
    {
        private Form form;
        private AxVideoPlayerWindowCommandFactory axVideoPlayerWindowCommandFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            form = new Form();
            axVideoPlayerWindowCommandFactory = new AxVideoPlayerWindowCommandFactory(form, null, 5);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            form.Dispose();
        }

        [Test]
        public void EmptyOrNullMessagesReturnsEmptyCollection()
        {
            var res1 = axVideoPlayerWindowCommandFactory.CreateCommands(null);
            var res2 = axVideoPlayerWindowCommandFactory.CreateCommands(String.Empty);

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
            var result = axVideoPlayerWindowCommandFactory.CreateCommands(cmd.ToString());

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].GetType().Name, Is.EqualTo(nameof(CloseCommand)));
        }

        [Test]
        public void MultipleLinesReturnsExpectedCommandTypesInOrder()
        {
            var messages = String.Join(Environment.NewLine, new[]
            {
                NetworkCommand.PanToEast.ToString(),
                NetworkCommand.TiltToNorth.ToString(),
                NetworkCommand.ZoomIn.ToString(),
                "UNKNOWN_CMD"
            });

            var result = axVideoPlayerWindowCommandFactory.CreateCommands(messages);

            Assert.That(result, Has.Count.EqualTo(4));

            var names = result.Select(c => c.GetType().Name).ToArray();
            using (Assert.EnterMultipleScope())
            {
                Assert.That(names[0], Is.EqualTo(nameof(AxVideoPlayerPanToEastCommand)));
                Assert.That(names[1], Is.EqualTo(nameof(AxVideoPlayerTiltToNorthCommand)));
                Assert.That(names[2], Is.EqualTo(nameof(AxVideoPlayerZoomInCommand)));
                Assert.That(names[3], Is.EqualTo(nameof(ShowErrorCommand)));
            }
        }

        [Test]
        public void IndividualCommandMappingsAreCorrect()
        {
            var map = new[]
            {
                new { Cmd = NetworkCommand.PanToEast.ToString(), Expected = nameof(AxVideoPlayerPanToEastCommand) },
                new { Cmd = NetworkCommand.PanToWest.ToString(), Expected = nameof(AxVideoPlayerPanToWestCommand) },
                new { Cmd = NetworkCommand.PanToEastAndTiltToNorth.ToString(), Expected = nameof(AxVideoPlayerPanToEastAndTiltToNorthCommand) },
                new { Cmd = NetworkCommand.PanToWestAndTiltToSouth.ToString(), Expected = nameof(AxVideoPlayerPanToWestAndTiltToSouthCommand) },
                new { Cmd = NetworkCommand.MoveToPresetZero.ToString(), Expected = nameof(AxVideoPlayerMoveToPresetZeroCommand) },
                new { Cmd = NetworkCommand.StopPanAndTilt.ToString(), Expected = nameof(AxVideoPlayerStopPanAndTiltCommand) },
                new { Cmd = NetworkCommand.StopZoom.ToString(), Expected = nameof(AxVideoPlayerStopZoomCommand) },
                new { Cmd = NetworkCommand.ZoomOut.ToString(), Expected = nameof(AxVideoPlayerZoomOutCommand) }
            };

            foreach (var pair in map)
            {
                var result = axVideoPlayerWindowCommandFactory.CreateCommands(pair.Cmd);
                Assert.That(result, Has.Count.EqualTo(1), "Expected single command for " + pair.Cmd);
                Assert.That(result[0].GetType().Name, Is.EqualTo(pair.Expected), "Type mismatch for " + pair.Cmd);
            }
        }
    }
}
