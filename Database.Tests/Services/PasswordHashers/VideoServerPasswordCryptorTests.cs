using Database.Services.PasswordHashers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Tests.Services.PasswordHashers
{
    [TestFixture]
    public class VideoServerPasswordCryptorTests
    {
        [Test]
        public void UsernameRoundTripReturnsOriginal()
        {
            var input = "video-user";
            var encrypted = VideoServerPasswordCryptor.UsernameEncrypt(input);
            var decrypted = VideoServerPasswordCryptor.UsernameDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void PasswordRoundTripReturnsOriginal()
        {
            var input = "Vid3oP@ss!";
            var encrypted = VideoServerPasswordCryptor.PasswordEncrypt(input);
            var decrypted = VideoServerPasswordCryptor.PasswordDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void EmptyStringRoundTripReturnsEmpty()
        {
            var encryptedUser = VideoServerPasswordCryptor.UsernameEncrypt(String.Empty);
            var decryptedUser = VideoServerPasswordCryptor.UsernameDecrypt(encryptedUser);
            Assert.That(decryptedUser, Is.EqualTo(String.Empty));

            var encryptedPass = VideoServerPasswordCryptor.PasswordEncrypt(String.Empty);
            var decryptedPass = VideoServerPasswordCryptor.PasswordDecrypt(encryptedPass);
            Assert.That(decryptedPass, Is.EqualTo(String.Empty));
        }

        [Test]
        public void UsernameAndPasswordEncryptionDiffer()
        {
            var input = "same-video-input";
            var u = VideoServerPasswordCryptor.UsernameEncrypt(input);
            var p = VideoServerPasswordCryptor.PasswordEncrypt(input);

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
