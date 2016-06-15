using ITC.UnifaunOnline.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITC.UnifaunOnline.Tests
{
    [TestClass]
    public class EmailValidatorTests
    {
        [TestMethod]
        public void ValidateEmail_Test()
        {
            Assert.AreEqual(true, EmailValidator.IsValid("test@test.se"));
            Assert.AreEqual(true, EmailValidator.IsValid("test.test@test.test.se"));
            Assert.AreEqual(true, EmailValidator.IsValid("test_99@test.com"));

            Assert.AreEqual(false, EmailValidator.IsValid("testtest.se"));
            Assert.AreEqual(false, EmailValidator.IsValid("testtest"));
            Assert.AreEqual(false, EmailValidator.IsValid("test@test"));
            Assert.AreEqual(false, EmailValidator.IsValid("test@test."));
        }
    }
}
