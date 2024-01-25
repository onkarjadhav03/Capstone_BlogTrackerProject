using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace NunitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [Test]
        public void Login_Successful()
        {
            // Arrange
            Class1 admin = new Class1 { email = "onkar@gmail.com", password = "onkar@123" };

            // Act
            string result = admin.Login("onkar@gmail.com", "onkar@123");

            // Assert
            Assert.AreEqual("Successful", result);
        }

        [Test]
        public void Login_Failed_InvalidEmail()
        {
            // Arrange
            string email = "invalid@gmail.com";
            string password = "onkar@123";
            string expected = "Unsuccessful";

            // Act
            Class1 classInstance = new Class1();
            string actual = classInstance.Login(email, password);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
