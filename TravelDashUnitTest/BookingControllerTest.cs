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
    public class BookingControllerTest
    {
        [TestMethod]
        public void TestTripIndex()
        {
            //Arrange
            BookingController controller = new BookingController();
            //Act
            ViewResult result = controller.TripIndex() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestTripIndexOverride()
        {
            //Arrange
            BookingController controller = new BookingController();
            //Act
            ViewResult result = controller.TripIndex() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
