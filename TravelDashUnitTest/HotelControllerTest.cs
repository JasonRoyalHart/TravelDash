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
    public class HotelControllerTest
    {
        [TestMethod]
        public void TestHotelsIndex()
        {
            //Arrange
            HotelController controller = new HotelController();
            //Act
            ViewResult result = controller.HotelsIndex() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
