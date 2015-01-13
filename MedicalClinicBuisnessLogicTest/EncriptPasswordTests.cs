using MedicalClinicHandler.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using StringAssert = NUnit.Framework.StringAssert;

namespace MedicalClinicBuisnessLogicTest
{
    [TestClass]
    public class EncriptPasswordTests
    {
        [SetUp]
        public void Setup() { }

        [TestCase("pass1", "pass1")]
        [TestCase("pass1", "pass2")]
        [TestCase("pass2", "pass2")]
        [TestCase("pass2", "pass3")]
        [TestCase("pass3", "pass3")]
        [TestCase("pass3", "pass4")]
        public void EncriptShouldBeEqual(string password1, string password2)
        {
            var result1 = EncryptString.DoHash(password1);
            var result2 = EncryptString.DoHash(password2);

            Assert.True(result1.Equals(result2));
        }

        [TestCase("pass1", "pass1")]
        [TestCase("pass1", "pass2")]
        [TestCase("pass2", "pass2")]
        [TestCase("pass2", "pass3")]
        [TestCase("pass3", "pass3")]
        [TestCase("pass3", "pass4")]
        public void EncriptShoulBeDifferent(string password1, string password2)
        {
            var result1 = EncryptString.DoHash(password1);
            var result2 = EncryptString.DoHash(password2);

            Assert.False(result1.Equals(result2));
        }
    }
}
