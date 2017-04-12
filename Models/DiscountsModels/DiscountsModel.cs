using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DiscountsModels
{
     public class DiscountsModel
    {

        public int Id { get; set; }

        public int CompanyId { get; set; }

        public decimal Discount { get; set; }

        public string DiscountValue { get; set; }

        public DiscountParse DiscountParse { get; set; }


    }
}
