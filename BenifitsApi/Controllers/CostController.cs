using DAL.CostRepositories;
using Models.CostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BenifitsApi.Controllers
{
    public class CostController : ApiController
    {
        private ICostRepository costRepository;

        public CostController()
        {
            this.costRepository = new CostRepository();
        }

        // GET: api/Cost
        public CostModel[] Get(int id)
        {
            return costRepository.GetAllBenifitsCostsByCompany(id).ToArray();
        }


    }
}
