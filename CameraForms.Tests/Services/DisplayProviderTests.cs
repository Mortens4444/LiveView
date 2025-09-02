using CameraForms.Services;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    public class DisplayProviderTests
    {
        private IDisplayRepository displayRepository;
        private IDisplayManager displayManager;
        private DisplayProvider provider;

        [SetUp]
        public void Setup()
        {
            displayRepository = Substitute.For<IDisplayRepository>();
            displayManager = Substitute.For<IDisplayManager>();
            provider = new DisplayProvider(displayRepository, displayManager);
        }

        [Test]
        public void GetDisplayWithValidIdReturnsDisplayDto()
        {
            var displayModel = new Display { Id = 1 };
            var displayDto = new DisplayDto { DeviceName = @"\\.\DISPLAY1" };

            displayRepository.Select(1).Returns(displayModel);
            displayManager.GetAll().Returns(new List<DisplayDto> { displayDto });

            var result = provider.GetDisplay(1);

            Assert.That(displayDto, Is.EqualTo(result));
        }

        [Test]
        public void GetDisplayWithNullIdReturnsFullscreenDisplay()
        {
            var displayModel = new Display { Id = 2 };
            var displayDto = new DisplayDto { DeviceName = @"\\.\DISPLAY2" };

            displayRepository.GetFullscreenDisplay().Returns(displayModel);
            displayManager.GetAll().Returns(new List<DisplayDto> { displayDto });

            var result = provider.GetDisplay(null);

            Assert.That(displayDto, Is.EqualTo(result));
        }

        [Test]
        public void GetDisplayWhenFullscreenDisplayIsNullThrowsException()
        {
            displayRepository.GetFullscreenDisplay().Returns((Display)null);

            var ex = Assert.Throws<InvalidOperationException>(() => provider.GetDisplay(null));
            Assert.That(ex.Message, Is.EqualTo("Choose a fullscreen display first."));
        }

        [Test]
        public void GetDisplayWhenDisplayNotFoundInManagerThrowsException()
        {
            var displayModel = new Display { Id = 3 };
            displayRepository.Select(3).Returns(displayModel);
            displayManager.GetAll().Returns(new List<DisplayDto>());

            var ex = Assert.Throws<InvalidOperationException>(() => provider.GetDisplay(3));
            Assert.That(ex.Message, Is.EqualTo("Choose another fullscreen display."));
        }
    }
}
