using Models.CostModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.CostRepositories
{
    public class CostRepository : ICostRepository
    {
        public List<CostModel> GetAllBenifitsCostsByCompany(int companyid)
        {
            var returnList = new List<CostModel>();
            returnList.Add(new CostModel() { Id = 1, CompanyId = 1, Cost = 1000M, DependentCost = false, EmployeeCost = true, SpouseCost = false });
            returnList.Add(new CostModel() { Id = 2, CompanyId = 1, Cost = 500M, DependentCost = true, EmployeeCost = false, SpouseCost = false });
            returnList.Add(new CostModel() { Id = 3, CompanyId = 1, Cost = 500M, DependentCost = false, EmployeeCost = false, SpouseCost = true });

            //using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString))
            //using (var cmd = new SqlCommand("GetAllBenifitsCostsByCompany", conn))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@CompanyId", companyid);
            //    cmd.CommandTimeout = 3500;

            //    using (var reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var item = new CostModel();

            //            item.Id = Convert.ToInt32(reader["Id"]);
            //            item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
            //            item.Cost = Convert.ToDecimal(reader["Cost"]);
            //            item.DependentCost = Convert.ToBoolean(reader["DependentCost"]);
            //            item.EmployeeCost = Convert.ToBoolean(reader["EmployeeCost"]);
            //            item.SpouseCost = Convert.ToBoolean(reader["SpouseCost"]);




            //            returnList.Add(item);

            //        }
            //    }


            //}

            return returnList;
        }


    }
}
