using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenifitsApi.Controllers;
using BenifitsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BenifitsApi.Tests.Controllers
{
    [TestClass]
    public class CalculateControllerTest
    {
        [TestMethod]
        public void CalculatePay()
        {
            CalculateController calculate = new CalculateController();

            CalculateModel model = new CalculateModel()
            {
                Employee = new Person() { FirstName = "Eric", LastName = "Dewitt" },
                Spouse = new Person() { FirstName = "Yara", LastName = "Dewitt" },
                Dependents = new List<Person>() { new Person() { FirstName = "Andrea", LastName = "Dewitt" }, new Person() { FirstName = "Nathan", LastName = "Dewitt" } },
                PayPerPaycheck = 2000M
            };


            var calc = calculate.post(model);

            Assert.AreEqual(1000M, calc.Employee.BenifitsCost);
            Assert.AreEqual(500M, calc.Spouse.BenifitsCost);
            Assert.AreEqual(450M, calc.Dependents.Where(x => x.FirstName == "Andrea").Select(x => x.BenifitsCost).FirstOrDefault());
            Assert.AreEqual(500m, calc.Dependents.Where(x => x.FirstName == "Nathan").Select(x => x.BenifitsCost).FirstOrDefault());
            Assert.AreEqual(2450M, calc.TotalBenifitCost);
            Assert.AreEqual(1905.77m, calc.TotalCalculatedPay);

        }
    }
}
