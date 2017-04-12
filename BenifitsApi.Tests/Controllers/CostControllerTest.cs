using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenifitsApi.Controllers;
using Models;
using System.Linq;

namespace BenifitsApi.Tests.Controllers
{
    [TestClass]
    public class CostControllerTest
    {
        [TestMethod]
        public void GetById()
        {
            CostController cost = new CostController();

            var list = cost.Get(1);
            
            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(1000M, Convert.ToDecimal( list.Where(x=>x.EmployeeCost).Select(x => x.Cost).FirstOrDefault()));

        }
    }
}
