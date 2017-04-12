using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenifitsApi.Controllers;
using Models;
using System.Linq;

namespace BenifitsApi.Tests.Controllers
{
    [TestClass]
    public class PaychecksControllerTest
    {
        [TestMethod]
        public void GetNumberOfPaychecks()
        {
            PaychecksController paychecks = new PaychecksController();

            var value = paychecks.Get(1);

            Assert.AreEqual(26, value.NumberOfPaychecks);

        }
    }
}
