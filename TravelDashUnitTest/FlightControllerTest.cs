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
    public class FlightControllerTest
    {
        [TestMethod]
        public void TestFlightsIndex()
        {
            //Arrange
            FlightController controller = new FlightController();
            //Act
            ViewResult result = controller.FlightsIndex() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
