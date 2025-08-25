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
    public class SunellLegacyVideoWindowCommandFactoryTests
    {
        private Form form;
        private SunellLegacyVideoWindowCommandFactory sunellLegacyVideoWindowCommandFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            form = new Form();
            sunellLegacyVideoWindowCommandFactory = new SunellLegacyVideoWindowCommandFactory(form, null, 5);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            form.Dispose();
        }

        [Test]
        public void EmptyOrNullMessagesReturnsEmptyCollection()
        {
            var res1 = sunellLegacyVideoWindowCommandFactory.CreateCommands(null);
            var res2 = sunellLegacyVideoWindowCommandFactory.CreateCommands(String.Empty);

            Assert.That(res1.Count, Is.EqualTo(0));
            Assert.That(res2.Count, Is.EqualTo(0));
        }

        [TestCase(NetworkCommand.Close)]
        [TestCase(NetworkCommand.Kill)]
        public void CloseOrKillReturnsCloseCommand(NetworkCommand cmd)
        {
            var result = sunellLegacyVideoWindowCommandFactory.CreateCommands(cmd.ToString());

            Assert.That(result.Count, Is.EqualTo(1));
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

            var result = sunellLegacyVideoWindowCommandFactory.CreateCommands(messages);

            Assert.That(result.Count, Is.EqualTo(4));

            var names = result.Select(c => c.GetType().Name).ToArray();
            Assert.That(names[0], Is.EqualTo(nameof(SunellLegacyVideoWindowPanToEastAndTiltToNorthCommand)));
            Assert.That(names[1], Is.EqualTo(nameof(SunellLegacyVideoWindowPanToWestAndTiltToSouthCommand)));
            Assert.That(names[2], Is.EqualTo(nameof(SunellLegacyVideoWindowMoveToPresetZeroCommand)));
            Assert.That(names[3], Is.EqualTo(nameof(ShowErrorCommand)));
        }

        [Test]
        public void IndividualCommandMappingsAreCorrect()
        {
            var map = new[]
            {
                new { Cmd = NetworkCommand.PanToEast.ToString(), Expected = nameof(SunellLegacyVideoWindowPanToEastCommand) },
                new { Cmd = NetworkCommand.PanToWest.ToString(), Expected = nameof(SunellLegacyVideoWindowPanToWestCommand) },
                new { Cmd = NetworkCommand.PanToEastAndTiltToNorth.ToString(), Expected = nameof(SunellLegacyVideoWindowPanToEastAndTiltToNorthCommand) },
                new { Cmd = NetworkCommand.PanToWestAndTiltToSouth.ToString(), Expected = nameof(SunellLegacyVideoWindowPanToWestAndTiltToSouthCommand) },
                new { Cmd = NetworkCommand.MoveToPresetZero.ToString(), Expected = nameof(SunellLegacyVideoWindowMoveToPresetZeroCommand) },
                new { Cmd = NetworkCommand.StopPanAndTilt.ToString(), Expected = nameof(SunellLegacyVideoWindowStopPanAndTiltCommand) },
                new { Cmd = NetworkCommand.StopZoom.ToString(), Expected = nameof(SunellLegacyVideoWindowStopZoomCommand) },
                new { Cmd = NetworkCommand.ZoomIn.ToString(), Expected = nameof(SunellLegacyVideoWindowZoomInCommand) },
                new { Cmd = NetworkCommand.ZoomOut.ToString(), Expected = nameof(SunellLegacyVideoWindowZoomOutCommand) }
            };

            foreach (var pair in map)
            {
                var result = sunellLegacyVideoWindowCommandFactory.CreateCommands(pair.Cmd);
                Assert.That(result.Count, Is.EqualTo(1), "Expected single command for " + pair.Cmd);
                Assert.That(result[0].GetType().Name, Is.EqualTo(pair.Expected), "Type mismatch for " + pair.Cmd);
            }
        }
    }
}
