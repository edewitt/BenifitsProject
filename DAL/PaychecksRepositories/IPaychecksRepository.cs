using Models.PaychecksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PaychecksRepositories
{
    public interface IPaychecksRepository
    {
        PaychecksModel GetNumberOfPaychecksByCompany(int companyid);
    }
}
