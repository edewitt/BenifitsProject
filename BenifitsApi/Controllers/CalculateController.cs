using BenifitsApi.Models;
using Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BenifitsApi.Services;
using System.Web.Http.Results;

namespace BenifitsApi.Controllers
{
    public class CalculateController : ApiController
    {
        public CalculateModel  post([FromBody] CalculateModel data)
        {
            var totalBenifitsCost = 0.00M;
            var cost = new CostController().Get(data.CompanyId);
            var paychecks = new PaychecksController().Get(data.CompanyId);
            var discounts = new DiscountsController().Get(data.CompanyId);

            var employeeBenfitCost = cost.Where(x => x.EmployeeCost).Select(x => x.Cost).FirstOrDefault();
            employeeBenfitCost = CalculateDiscounts.CalculateDiscount(discounts, employeeBenfitCost, data.Employee);
            data.Employee.BenifitsCost = employeeBenfitCost;
            totalBenifitsCost += employeeBenfitCost;

            if (!string.IsNullOrEmpty(data.Spouse?.FirstName) && !string.IsNullOrEmpty(data.Spouse?.LastName))
            {
                var benfitCost = cost.Where(x => x.SpouseCost).Select(x => x.Cost).FirstOrDefault();
                benfitCost = CalculateDiscounts.CalculateDiscount(discounts, benfitCost, data.Spouse);
                data.Spouse.BenifitsCost = benfitCost;
                totalBenifitsCost += benfitCost;
            }
                


            if(data.Dependents!=null)
                foreach (var depen in data.Dependents)
                {
                    if (!string.IsNullOrEmpty(depen?.FirstName) && !string.IsNullOrEmpty(depen?.LastName))
                    {
                        var benfitCost = cost.Where(x => x.DependentCost).Select(x => x.Cost).FirstOrDefault();
                        benfitCost = CalculateDiscounts.CalculateDiscount(discounts, benfitCost, depen);
                        depen.BenifitsCost = benfitCost;
                        totalBenifitsCost += benfitCost;
                    }
                }


            data.TotalCalculatedPay = Math.Round(data.PayPerPaycheck - (data.TotalBenifitCost / paychecks.NumberOfPaychecks), 2);
            
            return data;
        }

    }
}
