using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenifitsApi.Controllers;
using Models;
using System.Linq;
using Models.DiscountsModels;

namespace BenifitsApi.Tests.Controllers
{
    [TestClass]
    public class DiscountsControllerTest
    {
        [TestMethod]
        public void GetDiscountsById()
        {
            DiscountsController discounts = new DiscountsController();

            var value = discounts.Get(1);

            Assert.AreEqual(1, value.Length);
            Assert.AreEqual("A", value.FirstOrDefault().DiscountValue);
            Assert.AreEqual(0.10m, value.FirstOrDefault().Discount);
            Assert.AreEqual(DiscountParse.StartsWith, value.FirstOrDefault().DiscountParse);

        }
    }
}
