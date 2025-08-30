using CameraForms.Dto;
using CameraForms.Services;
using Database.Models;
using LiveView.Core.Services;
using Mtf.Controls.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class OsdSetterTests
    {
        [Test]
        public void ThrowWhenFormIsNull()
        {
            var vw = Substitute.For<IVideoWindow>();
            var gc = new GridCamera();
            var osd = new OsdSettings();
            Assert.That(() => OsdSetter.SetInfo(null, vw, gc, osd, "t"), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowWhenVideoWindowIsNull()
        {
            using (var form = new Form())
            {
                var gc = new GridCamera();
                var osd = new OsdSettings();
                Assert.That(() => OsdSetter.SetInfo(form, null, gc, osd, "t"), Throws.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void ReturnWhenGridCameraIsNull()
        {
            using (var form = new Form())
            {
                var vw = Substitute.For<IVideoWindow>();
                var osd = new OsdSettings();
                var before = vw.ReceivedCalls().Count();
                OsdSetter.SetInfo(form, vw, null, osd, "t");
                var after = vw.ReceivedCalls().Count();
                Assert.That(after, Is.EqualTo(before));
            }
        }

        [Test]
        public void SetOverlayPropertiesFromOsdSettings()
        {
            using (var form = new Form())
            {
                var vw = Substitute.For<IVideoWindow>();
                var gc = new GridCamera { Frame = false, Osd = true, ShowDateTime = false };
                var osd = new OsdSettings
                {
                    LargeFontSize = 30f,
                    SmallFontSize = 15f,
                    ShadowColor = Color.Blue,
                    FontName = "Arial",
                    FontColor = Color.Red
                };

                OsdSetter.SetInfo(form, vw, gc, osd, "hello");

                vw.Received().OverlayFont = Arg.Is<Font>(f =>
                    f.Name == osd.OverlayFont.Name &&
                    Math.Abs(f.Size - osd.OverlayFont.Size) < 0.01f &&
                    f.Style == osd.OverlayFont.Style);

                vw.Received().OverlayBrush = Arg.Is<Brush>(b =>
                    (b as SolidBrush) != null &&
                    ((SolidBrush)b).Color.ToArgb() == osd.FontColor.ToArgb());
            }
        }

        [Test]
        public void SetFormBorderAndTextWhenFrameTrue()
        {
            using (var form = new Form())
            {
                var vw = Substitute.For<IVideoWindow>();
                var gc = new GridCamera { Frame = true, Osd = false, ShowDateTime = false };
                OsdSetter.SetInfo(form, vw, gc, null, "caption");
                using (Assert.EnterMultipleScope())
                {
                    Assert.That(form.FormBorderStyle, Is.EqualTo(FormBorderStyle.FixedSingle));
                    Assert.That(form.Text, Is.EqualTo("caption"));
                }
            }
        }

        [Test]
        public void SetOverlayTextWhenOsdTrueAndAppendDateTime()
        {
            using (var form = new Form())
            {
                var vw = Substitute.For<IVideoWindow>();
                var now = DateUtils.GetNowFriendlyString();
                var gc = new GridCamera { Frame = false, Osd = true, ShowDateTime = true };
                OsdSetter.SetInfo(form, vw, gc, null, "T");
                vw.Received().OverlayText = Arg.Is<string>(s => s.StartsWith("T") && s.Contains(now));
            }
        }

        [Test]
        public void ClearOverlayWhenOsdFalse()
        {
            using (var form = new Form())
            {
                var vw = Substitute.For<IVideoWindow>();
                var gc = new GridCamera { Frame = false, Osd = false, ShowDateTime = false };
                OsdSetter.SetInfo(form, vw, gc, null, "X");
                vw.Received().OverlayText = String.Empty;
            }
        }
    }
}
