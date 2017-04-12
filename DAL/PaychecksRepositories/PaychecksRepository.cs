using Models.PaychecksModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PaychecksRepositories
{
    public class PaychecksRepository : IPaychecksRepository
    {
        public PaychecksModel GetNumberOfPaychecksByCompany(int companyid)
        {
            var returnvalue = new PaychecksModel() { Id = 1, CompanyId = 1, NumberOfPaychecks = 26 };

            //using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString))
            //using (var cmd = new SqlCommand("GetNumberOfPaychecksByCompany", conn))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@CompanyId", companyid);
            //    cmd.CommandTimeout = 3500;

            //    using (var reader = cmd.ExecuteReader())
            //    {
            //        returnvalue.Id = Convert.ToInt32(reader["Id"]);
            //        returnvalue.CompanyId = Convert.ToInt32(reader["CompanyId"]);
            //        returnvalue.NumberOfPaychecks = Convert.ToInt32(reader["NumberOfPaychecks"]);
            //    }


            //}

            return returnvalue;
        }

    }
}
