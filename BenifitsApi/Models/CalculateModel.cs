using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenifitsApi.Models
{
    public class CalculateModel
    {
        public int CompanyId { get; set; }

        public Person Employee { get; set; }

        public Person Spouse { get; set; }

        public List<Person> Dependents { get; set; }

        public decimal PayPerPaycheck { get; set; }

        public decimal TotalBenifitCost => GetTotalBenifits();

        public decimal TotalCalculatedPay { get; set; }

        private decimal GetTotalBenifits()
        {
            var total = Employee.BenifitsCost;

            if (Spouse != null)
            {
                total += Spouse.BenifitsCost;
            }

            if (Dependents != null)
            {
                foreach (var depen in Dependents)
                {
                    total += depen.BenifitsCost;
                }
            }

            return total;
        }


    }

}