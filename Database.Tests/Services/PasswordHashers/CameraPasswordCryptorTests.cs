using Database.Services.PasswordHashers;
using NUnit.Framework;
using System;

namespace Database.Tests.Services.PasswordHashers
{
    [TestFixture]
    public class CameraPasswordCryptorTests
    {
        [Test]
        public void UsernameRoundTripReturnsOriginal()
        {
            var input = "test-user";
            var encrypted = CameraPasswordCryptor.UsernameEncrypt(input);
            var decrypted = CameraPasswordCryptor.UsernameDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void PasswordRoundTripReturnsOriginal()
        {
            var input = "P@ssw0rd!";
            var encrypted = CameraPasswordCryptor.PasswordEncrypt(input);
            var decrypted = CameraPasswordCryptor.PasswordDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void EmptyStringRoundTripReturnsEmpty()
        {
            var encryptedUser = CameraPasswordCryptor.UsernameEncrypt(String.Empty);
            var decryptedUser = CameraPasswordCryptor.UsernameDecrypt(encryptedUser);
            Assert.That(decryptedUser, Is.EqualTo(String.Empty));

            var encryptedPass = CameraPasswordCryptor.PasswordEncrypt(String.Empty);
            var decryptedPass = CameraPasswordCryptor.PasswordDecrypt(encryptedPass);
            Assert.That(decryptedPass, Is.EqualTo(String.Empty));
        }

        [Test]
        public void UsernameAndPasswordEncryptionDiffer()
        {
            var input = "same-input";
            var u = CameraPasswordCryptor.UsernameEncrypt(input);
            var p = CameraPasswordCryptor.PasswordEncrypt(input);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(u, Is.Not.Null);
                Assert.That(u, Is.Not.EqualTo(input));
                Assert.That(p, Is.Not.Null);
                Assert.That(p, Is.Not.EqualTo(input));
                Assert.That(u, Is.Not.EqualTo(p), "Expected username and password encryptions to differ (different rounds).");
            }
        }
    }
}
