using Models.CostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CostRepositories
{
    public interface ICostRepository
    {
        List<CostModel> GetAllBenifitsCostsByCompany(int companyid);
    }
}
