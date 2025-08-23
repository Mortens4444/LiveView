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
        [Test]
        public void EmptyOrNullMessagesReturnsEmptyCollection()
        {
            using (var form = new Form())
            {
                var res1 = AxVideoPlayerWindowCommandFactory.Create(form, null, null, 5);
                var res2 = AxVideoPlayerWindowCommandFactory.Create(form, null, String.Empty, 5);

                Assert.That(res1.Count, Is.EqualTo(0));
                Assert.That(res2.Count, Is.EqualTo(0));
            }
        }

        [TestCase(NetworkCommand.Close)]
        [TestCase(NetworkCommand.Kill)]
        public void CloseOrKillReturnsCloseCommand(NetworkCommand cmd)
        {
            using (var form = new Form())
            {
                var messages = cmd.ToString();
                var result = AxVideoPlayerWindowCommandFactory.Create(form, null, messages, 3);

                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result[0].GetType().Name, Is.EqualTo(nameof(CloseCommand)));
            }
        }

        [Test]
        public void MultipleLinesReturnsExpectedCommandTypesInOrder()
        {
            using (var form = new Form())
            {
                var messages = string.Join(Environment.NewLine, new[]
                {
                    NetworkCommand.PanToEast.ToString(),
                    NetworkCommand.TiltToNorth.ToString(),
                    NetworkCommand.ZoomIn.ToString(),
                    "UNKNOWN_CMD"
                });

                var result = AxVideoPlayerWindowCommandFactory.Create(form, null, messages, 7);

                Assert.That(result.Count, Is.EqualTo(4));

                var names = result.Select(c => c.GetType().Name).ToArray();
                Assert.That(names[0], Is.EqualTo(nameof(AxVideoPlayerPanToEastCommand)));
                Assert.That(names[1], Is.EqualTo(nameof(AxVideoPlayerTiltToNorthCommand)));
                Assert.That(names[2], Is.EqualTo(nameof(AxVideoPlayerZoomInCommand)));
                Assert.That(names[3], Is.EqualTo(nameof(ShowErrorCommand)));
            }
        }

        [Test]
        public void IndividualCommandMappingsAreCorrect()
        {
            using (var form = new Form())
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
                    var result = AxVideoPlayerWindowCommandFactory.Create(form, null, pair.Cmd, 2);
                    Assert.That(result.Count, Is.EqualTo(1), "Expected single command for " + pair.Cmd);
                    Assert.That(result[0].GetType().Name, Is.EqualTo(pair.Expected), "Type mismatch for " + pair.Cmd);
                }
            }
        }
    }
}
