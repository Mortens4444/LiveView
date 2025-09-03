using Database.Services.PasswordHashers;
using NUnit.Framework;
using System;

namespace Database.Tests.Services.PasswordHashers
{
    [TestFixture]
    public class WindowsPasswordCryptorTests
    {
        [Test]
        public void UsernameRoundTripReturnsOriginal()
        {
            var input = "win-user";
            var encrypted = WindowsPasswordCryptor.UsernameEncrypt(input);
            var decrypted = WindowsPasswordCryptor.UsernameDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void PasswordRoundTripReturnsOriginal()
        {
            var input = "W1nP@ss!";
            var encrypted = WindowsPasswordCryptor.PasswordEncrypt(input);
            var decrypted = WindowsPasswordCryptor.PasswordDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void EmptyStringRoundTripReturnsEmpty()
        {
            var encryptedUser = WindowsPasswordCryptor.UsernameEncrypt(String.Empty);
            var decryptedUser = WindowsPasswordCryptor.UsernameDecrypt(encryptedUser);
            Assert.That(decryptedUser, Is.EqualTo(String.Empty));

            var encryptedPass = WindowsPasswordCryptor.PasswordEncrypt(String.Empty);
            var decryptedPass = WindowsPasswordCryptor.PasswordDecrypt(encryptedPass);
            Assert.That(decryptedPass, Is.EqualTo(String.Empty));
        }

        [Test]
        public void UsernameAndPasswordEncryptionDiffer()
        {
            var input = "same-win-input";
            var u = WindowsPasswordCryptor.UsernameEncrypt(input);
            var p = WindowsPasswordCryptor.PasswordEncrypt(input);

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
