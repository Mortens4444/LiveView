using Database.Services.PasswordHashers;
using NUnit.Framework;
using System;

namespace Database.Tests.Services.PasswordHashers
{
    [TestFixture]
    public class UserPasswordHasherTests
    {
        [Test]
        public void UsernameRoundTripReturnsOriginal()
        {
            var input = "test-user";
            var encrypted = UserPasswordHasher.UsernameEncrypt(input);
            var decrypted = UserPasswordHasher.UsernameDecrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(input));
        }

        [Test]
        public void EmptyStringRoundTripReturnsEmpty()
        {
            var encryptedUser = UserPasswordHasher.UsernameEncrypt(String.Empty);
            var decryptedUser = UserPasswordHasher.UsernameDecrypt(encryptedUser);

            Assert.That(decryptedUser, Is.EqualTo(String.Empty));
        }

        [Test]
        public void HashProducesConsistentValue()
        {
            var input = "P@ssw0rd!";
            var hash1 = UserPasswordHasher.Hash(input);
            var hash2 = UserPasswordHasher.Hash(input);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(hash1, Is.Not.Null);
                Assert.That(hash1, Is.Not.Empty);
                Assert.That(hash2, Is.EqualTo(hash1), "Hash should be deterministic");
            }
        }

        [Test]
        public void HashProducesDifferentValuesForDifferentInputs()
        {
            var h1 = UserPasswordHasher.Hash("input-one");
            var h2 = UserPasswordHasher.Hash("input-two");

            Assert.That(h1, Is.Not.EqualTo(h2));
        }

        [Test]
        public void ReverseStringWorks()
        {
            var input = "abcdef";
            var reversed = UserPasswordHasher.Reverse(input);

            Assert.That(reversed, Is.EqualTo("fedcba"));
        }

        [Test]
        public void ReverseOfEmptyOrNullReturnsEmpty()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(UserPasswordHasher.Reverse(String.Empty), Is.EqualTo(String.Empty));
                Assert.That(UserPasswordHasher.Reverse(null), Is.EqualTo(String.Empty));
            }
        }

        [Test]
        public void Sha256HashProducesExpectedLength()
        {
            var input = "abc";
            var hash = UserPasswordHasher.Sha256Hash(input);

            Assert.That(hash, Has.Length.EqualTo(64));
        }

        [Test]
        public void Sha256HashIsCaseInsensitiveStable()
        {
            var lower = UserPasswordHasher.Sha256Hash("abc");
            var upper = UserPasswordHasher.Sha256Hash("ABC");

            Assert.That(lower, Is.Not.EqualTo(upper));
        }
    }
}
