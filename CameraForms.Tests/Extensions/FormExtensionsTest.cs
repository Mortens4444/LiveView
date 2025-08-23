using CameraForms.Extensions;
using NUnit.Framework;
using System.Windows.Forms;

namespace CameraForms.Tests.Extensions
{
    [TestFixture]
    public class FormExtensionsTest
    {
        [Test]
        public void ExitShouldCloseForm()
        {
            using (var form = new Form())
            {
                form.Exit();
                Assert.That(form.IsDisposed, Is.EqualTo(true));
            }
        }
    }
}
