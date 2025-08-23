using CameraForms.Extensions;
using Database.Enums;
using Database.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Drawing;

namespace CameraForms.Tests.Extensions
{
    [TestFixture]
    public class PersonalOptionsRepositoryExtensionsTests
    {
        [Test]
        public void ReturnExpectedValues()
        {
            var userId = 42L;
            var repository = Substitute.For<IPersonalOptionsRepository>();

            repository.Get(Setting.CameraLargeFontSize, userId, 30).Returns(40);
            repository.Get(Setting.CameraSmallFontSize, userId, 15).Returns(20);
            repository.Get(Setting.CameraFont, userId, "Arial").Returns("Times New Roman");
            repository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()).Returns(Color.Red.ToArgb());
            repository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()).Returns(Color.Blue.ToArgb());

            var osd = repository.GetOsdSettings(userId);

            Assert.That(osd.LargeFontSize, Is.EqualTo(40));
            Assert.That(osd.SmallFontSize, Is.EqualTo(20));
            Assert.That(osd.FontName, Is.EqualTo("Times New Roman"));
            Assert.That(osd.FontColor.ToArgb(), Is.EqualTo(Color.Red.ToArgb()));
            Assert.That(osd.ShadowColor.ToArgb(), Is.EqualTo(Color.Blue.ToArgb()));
        }

        [Test]
        public void UseDefaultsWhenRepositoryReturnsDefaults()
        {
            var userId = 99L;
            var repository = Substitute.For<IPersonalOptionsRepository>();

            repository.Get(Setting.CameraLargeFontSize, userId, 30).Returns(30);
            repository.Get(Setting.CameraSmallFontSize, userId, 15).Returns(15);
            repository.Get(Setting.CameraFont, userId, "Arial").Returns("Arial");
            repository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()).Returns(Color.White.ToArgb());
            repository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()).Returns(Color.Black.ToArgb());

            var osd = repository.GetOsdSettings(userId);

            Assert.That(osd.LargeFontSize, Is.EqualTo(30));
            Assert.That(osd.SmallFontSize, Is.EqualTo(15));
            Assert.That(osd.FontName, Is.EqualTo("Arial"));
            Assert.That(osd.FontColor.ToArgb(), Is.EqualTo(Color.White.ToArgb()));
            Assert.That(osd.ShadowColor.ToArgb(), Is.EqualTo(Color.Black.ToArgb()));
        }
    }
}
