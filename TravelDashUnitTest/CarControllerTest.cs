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
    public class CarControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            CarController controller = new CarController();
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
