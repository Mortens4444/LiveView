using Database.Services.PasswordHashers;
using NUnit.Framework;
using System;

namespace Database.Tests.Services.PasswordHashers
{
    [TestFixture]
    public class NoCryptorTests
    {
        [Test]
        public void StringRoundTripReturnsOriginal()
        {
            var cryptor = new NoCryptor();
            var input = "plain-text";
            var encrypted = cryptor.Encrypt(input);
            var decrypted = cryptor.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void ByteArrayRoundTripReturnsOriginal()
        {
            var cryptor = new NoCryptor();
            var input = new byte[] { 1, 2, 3, 4, 5 };
            var encrypted = cryptor.Encrypt(input);
            var decrypted = cryptor.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void EmptyStringRoundTripReturnsEmpty()
        {
            var cryptor = new NoCryptor();
            var encrypted = cryptor.Encrypt(String.Empty);
            var decrypted = cryptor.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(String.Empty));
        }

        [Test]
        public void EmptyByteArrayRoundTripReturnsEmpty()
        {
            var cryptor = new NoCryptor();
            var input = new byte[0];
            var encrypted = cryptor.Encrypt(input);
            var decrypted = cryptor.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void NullStringReturnsNull()
        {
            var cryptor = new NoCryptor();
            string input = null;
            var encrypted = cryptor.Encrypt(input);
            var decrypted = cryptor.Decrypt(encrypted);

            Assert.That(decrypted, Is.Null);
        }

        [Test]
        public void NullByteArrayReturnsNull()
        {
            var cryptor = new NoCryptor();
            byte[] input = null;
            var encrypted = cryptor.Encrypt(input);
            var decrypted = cryptor.Decrypt(encrypted);

            Assert.That(decrypted, Is.Null);
        }

        [Test]
        public void EncryptAndDecryptDoNotModifyData()
        {
            var cryptor = new NoCryptor();
            var str = "check";
            var bytes = new byte[] { 9, 8, 7 };

            var encryptedStr = cryptor.Encrypt(str);
            var decryptedStr = cryptor.Decrypt(encryptedStr);

            var encryptedBytes = cryptor.Encrypt(bytes);
            var decryptedBytes = cryptor.Decrypt(encryptedBytes);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(encryptedStr, Is.EqualTo(str));
                Assert.That(decryptedStr, Is.EqualTo(str));
                Assert.That(encryptedBytes, Is.EqualTo(bytes));
                Assert.That(decryptedBytes, Is.EqualTo(bytes));
            }
        }
    }
}
