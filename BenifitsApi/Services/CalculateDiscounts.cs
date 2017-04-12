using BenifitsApi.Models;
using Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenifitsApi.Services
{
    public static class CalculateDiscounts
    {

        public static decimal CalculateDiscount(DiscountsModel[] discounts, decimal benfitCost, Person person)
        {
            foreach (var discount in discounts)
            {
                switch (discount.DiscountParse)
                {
                    case DiscountParse.Contains:

                        if (person.FirstName.Contains(discount.DiscountValue))
                        {
                            benfitCost = benfitCost - (benfitCost * discount.Discount);
                        }

                        break;
                    case DiscountParse.StartsWith:
                        if (person.FirstName.StartsWith(discount.DiscountValue))
                        {
                            benfitCost = benfitCost - (benfitCost * discount.Discount);
                        }
                        break;
                    case DiscountParse.EndsWith:
                        if (person.FirstName.EndsWith(discount.DiscountValue))
                        {
                            benfitCost = benfitCost - (benfitCost * discount.Discount);
                        }
                        break;
                    case DiscountParse.Equals:
                        if (person.FirstName.Equals(discount.DiscountValue))
                        {
                            benfitCost = benfitCost - (benfitCost * discount.Discount);
                        }
                        break;
                    default:
                        break;
                }
            }

            return benfitCost;
        }
    }
}