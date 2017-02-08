using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TravelDash;
using TravelDash.Controllers;
using TravelDash.Models;

namespace TravelDashUnitTest
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void TestLogin()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.Login("") as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestRegister()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.Register() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestForgotPassword()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.ForgotPassword() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestForgotPasswordConfirmation()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.ForgotPasswordConfirmation() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestResetPassword()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.ResetPassword("") as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestResetPasswordConfirmation()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.ResetPasswordConfirmation() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestExternalLoginFailure()
        {
            //Arrange
            AccountController controller = new AccountController();
            //Act
            ViewResult result = controller.ExternalLoginFailure() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
