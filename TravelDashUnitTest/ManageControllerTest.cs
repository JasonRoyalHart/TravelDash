using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TravelDash;
using TravelDash.Controllers;

namespace TravelDashUnitTest
{
    [TestClass]
    public class ManageControllerTest
    {
        [TestMethod]
        public void TestAddPhoneNumber()
        {
            //Arrange
            ManageController controller = new ManageController();
            //Act
            ViewResult result = controller.AddPhoneNumber() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestChangePassword()
        {
            //Arrange
            ManageController controller = new ManageController();
            //Act
            ViewResult result = controller.ChangePassword() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestSetPassword()
        {
            //Arrange
            ManageController controller = new ManageController();
            //Act
            ViewResult result = controller.SetPassword() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
    }
}
