using Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DiscountsRepositories
{
    public class DiscountsRepository : IDiscountsRepository
    {
        public List<DiscountsModel> GetAllDiscountsByCompany(int companyid)
        {
            var returnList = new List<DiscountsModel>();
            returnList.Add(new DiscountsModel() { Id = 1, CompanyId = 1, Discount = 0.10M, DiscountParse = DiscountParse.StartsWith, DiscountValue = "A"});

            //using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString))
            //using (var cmd = new SqlCommand("GetAllDiscountsByCompany", conn))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@CompanyId", companyid);
            //    cmd.CommandTimeout = 3500;

            //    using (var reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var item = new DiscountsModel();

            //            item.Id = Convert.ToInt32(reader["Id"]);
            //            item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
            //            item.Discount = Convert.ToDecimal(reader["Cost"]);
            //            item.DiscountParse = (DiscountParse)reader["DependentCost"];
            //            item.DiscountValue = reader["DiscountValue"].ToString();
                        
            //            returnList.Add(item);

            //        }
            //    }


            //}

            return returnList;
        }

    }
}
