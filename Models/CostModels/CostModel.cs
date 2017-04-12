using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CostModels
{
    public class CostModel
    {

        public int Id { get; set; }

        public decimal Cost { get; set; }

        public int CompanyId { get; set; }

        public bool EmployeeCost { get; set; }

        public bool DependentCost { get; set; }

        public bool SpouseCost { get; set; }

    }
}
