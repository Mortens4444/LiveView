using CameraForms.Services;
using NUnit.Framework;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    public class MultiplierProviderTests
    {
        [TestCase(0, 100)]
        [TestCase(15, 100)]
        [TestCase(17, 120)]
        [TestCase(31, 120)]
        [TestCase(32, 140)]
        [TestCase(40, 140)]
        [TestCase(49, 180)]
        [TestCase(100, 180)]
        public void GetMultiplierReturnsExpectedValues(int input, int expected)
        {
            var result = MultiplierProvider.GetMultiplier(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
