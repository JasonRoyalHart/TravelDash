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
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestAbout()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.About() as ViewResult;
            //Assert
            Assert.AreEqual("Everything Travel Dash can do for you.", result.ViewBag.Message);
        }
        [TestMethod]
        public void TestContact()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.Contact() as ViewResult;
            //Assert
            Assert.AreEqual("Let us know how our app worked for you.", result.ViewBag.Message);
        }
        [TestMethod]
        public void TestContactOverride()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.Contact("") as ViewResult;
            //Assert
            Assert.AreEqual("Thanks for reviewing our app.", result.ViewBag.Message);
        }
    }
}
