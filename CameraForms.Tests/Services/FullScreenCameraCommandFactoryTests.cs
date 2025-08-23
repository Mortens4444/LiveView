using CameraForms.Network.Commands;
using CameraForms.Services;
using LiveView.Core.Enums.Network;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class FullScreenCameraCommandFactoryTests
    {
        [Test]
        public void EmptyOrNullMessagesReturnsEmptyCollection()
        {
            using (var form = new Form())
            {
                var res1 = FullScreenCameraCommandFactory.Create(null, form, null);
                var res2 = FullScreenCameraCommandFactory.Create(null, form, String.Empty);

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
                var result = FullScreenCameraCommandFactory.Create(null, form, messages);

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
                    NetworkCommand.PanToEastAndTiltToNorth.ToString(),
                    NetworkCommand.PanToWestAndTiltToSouth.ToString(),
                    NetworkCommand.MoveToPresetZero.ToString(),
                    "UNKNOWN_CMD"
                });

                var result = FullScreenCameraCommandFactory.Create(null, form, messages);

                Assert.That(result.Count, Is.EqualTo(4));

                var names = result.Select(c => c.GetType().Name).ToArray();
                Assert.That(names[0], Is.EqualTo(nameof(FullScreenCameraPanToEastAndTiltToNorthCommand)));
                Assert.That(names[1], Is.EqualTo(nameof(FullScreenCameraPanToWestAndTiltToSouthCommand)));
                Assert.That(names[2], Is.EqualTo(nameof(FullScreenCameraMoveToPresetZeroCommand)));
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
                    var result = FullScreenCameraCommandFactory.Create(null, form, pair.Cmd);
                    Assert.That(result.Count, Is.EqualTo(1), "Expected single command for " + pair.Cmd);
                    Assert.That(result[0].GetType().Name, Is.EqualTo(pair.Expected), "Type mismatch for " + pair.Cmd);
                }
            }
        }
    }
}
