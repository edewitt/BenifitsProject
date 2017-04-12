using DAL.DiscountsRepositories;
using Models.DiscountsModels;
using System.Web.Http;

namespace BenifitsApi.Controllers
{
    public class DiscountsController : ApiController
    {
        private IDiscountsRepository discounts;

        public DiscountsController()
        {
            this.discounts = new DiscountsRepository();
        }


        // GET: Paychecks
        public DiscountsModel[] Get(int id)
        {
            return discounts.GetAllDiscountsByCompany(id).ToArray();
        }

    }
}
