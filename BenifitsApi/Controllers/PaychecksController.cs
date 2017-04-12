using DAL.PaychecksRepositories;
using Models.PaychecksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BenifitsApi.Controllers
{
    public class PaychecksController : ApiController
    {
        IPaychecksRepository paychecks;

        public PaychecksController()
        {
            this.paychecks = new PaychecksRepository();
        }


        // GET: Paychecks
        public PaychecksModel Get(int id)
        {
            return paychecks.GetNumberOfPaychecksByCompany(id);
        }

    }
}
