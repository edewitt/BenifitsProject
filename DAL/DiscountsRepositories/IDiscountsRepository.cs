using Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DiscountsRepositories
{
    public interface IDiscountsRepository
    {
        List<DiscountsModel> GetAllDiscountsByCompany(int companyid);
    }
}
