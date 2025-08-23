using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CameraForms.Services;
using CameraForms.Network.Commands;
using LiveView.Core.Enums.Network;
using NUnit.Framework;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class SunellVideoWindowCommandFactoryTests
    {
        [Test]
        public void EmptyOrNullMessagesReturnsEmptyCollection()
        {
            using (var form = new Form())
            {
                var res1 = SunellVideoWindowCommandFactory.Create(form, null, null);
                var res2 = SunellVideoWindowCommandFactory.Create(form, null, String.Empty);

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
                var result = SunellVideoWindowCommandFactory.Create(form, null, messages);

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

                var result = SunellVideoWindowCommandFactory.Create(form, null, messages);

                Assert.That(result.Count, Is.EqualTo(4));

                var names = result.Select(c => c.GetType().Name).ToArray();
                Assert.That(names[0], Is.EqualTo(nameof(SunellVideoWindowPanToEastAndTiltToNorthCommand)));
                Assert.That(names[1], Is.EqualTo(nameof(SunellVideoWindowPanToWestAndTiltToSouthCommand)));
                Assert.That(names[2], Is.EqualTo(nameof(SunellVideoWindowMoveToPresetZeroCommand)));
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
                    new { Cmd = NetworkCommand.PanToEast.ToString(), Expected = nameof(SunellVideoWindowPanToEastCommand) },
                    new { Cmd = NetworkCommand.PanToWest.ToString(), Expected = nameof(SunellVideoWindowPanToWestCommand) },
                    new { Cmd = NetworkCommand.PanToEastAndTiltToNorth.ToString(), Expected = nameof(SunellVideoWindowPanToEastAndTiltToNorthCommand) },
                    new { Cmd = NetworkCommand.PanToWestAndTiltToSouth.ToString(), Expected = nameof(SunellVideoWindowPanToWestAndTiltToSouthCommand) },
                    new { Cmd = NetworkCommand.MoveToPresetZero.ToString(), Expected = nameof(SunellVideoWindowMoveToPresetZeroCommand) },
                    new { Cmd = NetworkCommand.StopPanAndTilt.ToString(), Expected = nameof(SunellVideoWindowStopPanAndTiltCommand) },
                    new { Cmd = NetworkCommand.StopZoom.ToString(), Expected = nameof(SunellVideoWindowStopZoomCommand) },
                    new { Cmd = NetworkCommand.ZoomIn.ToString(), Expected = nameof(SunellVideoWindowZoomInCommand) },
                    new { Cmd = NetworkCommand.ZoomOut.ToString(), Expected = nameof(SunellVideoWindowZoomOutCommand) }
                };

                foreach (var pair in map)
                {
                    var result = SunellVideoWindowCommandFactory.Create(form, null, pair.Cmd);
                    Assert.That(result.Count, Is.EqualTo(1), "Expected single command for " + pair.Cmd);
                    Assert.That(result[0].GetType().Name, Is.EqualTo(pair.Expected), "Type mismatch for " + pair.Cmd);
                }
            }
        }
    }
}
