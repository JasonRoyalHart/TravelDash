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
    public class EventControllerTest
    {
        [TestMethod]
        public void TestEventsIndex()
        {
            //Arrange
            EventController controller = new EventController();
            //Act
            ViewResult result = controller.EventsIndex() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
