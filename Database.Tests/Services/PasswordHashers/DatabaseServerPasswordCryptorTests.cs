using Database.Services.PasswordHashers;
using NUnit.Framework;
using System;

namespace Database.Tests.Services.PasswordHashers
{
    [TestFixture]
    public class DatabaseServerPasswordCryptorTests
    {
        [Test]
        public void UsernameRoundTripReturnsOriginal()
        {
            var input = "test-user";
            var encrypted = DatabaseServerPasswordCryptor.UsernameEncrypt(input);
            var decrypted = DatabaseServerPasswordCryptor.UsernameDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void PasswordRoundTripReturnsOriginal()
        {
            var input = "P@ssw0rd!";
            var encrypted = DatabaseServerPasswordCryptor.PasswordEncrypt(input);
            var decrypted = DatabaseServerPasswordCryptor.PasswordDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void EmptyStringRoundTripReturnsEmpty()
        {
            var encryptedUser = DatabaseServerPasswordCryptor.UsernameEncrypt(String.Empty);
            var decryptedUser = DatabaseServerPasswordCryptor.UsernameDecrypt(encryptedUser);
            Assert.That(decryptedUser, Is.EqualTo(String.Empty));

            var encryptedPass = DatabaseServerPasswordCryptor.PasswordEncrypt(String.Empty);
            var decryptedPass = DatabaseServerPasswordCryptor.PasswordDecrypt(encryptedPass);
            Assert.That(decryptedPass, Is.EqualTo(String.Empty));
        }

        [Test]
        public void UsernameAndPasswordEncryptionDiffer()
        {
            var input = "same-input";
            var u = DatabaseServerPasswordCryptor.UsernameEncrypt(input);
            var p = DatabaseServerPasswordCryptor.PasswordEncrypt(input);

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
