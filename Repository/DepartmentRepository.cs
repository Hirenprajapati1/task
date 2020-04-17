using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using task1.Models;

namespace task1.Repository
{
    public class DepartmentRepository
    {
        public List<DepartmentModel> GetDepartments()
        {


            SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            List<DepartmentModel> s2 = new List<DepartmentModel>();

            SqlDataAdapter sa = new SqlDataAdapter("GetDepartment", sc);
            DataTable dt = new DataTable();
            sa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sc.Open();
            sa.Fill(dt);
            sc.Close();
            foreach (DataRow dr in dt.Rows)
            {
                s2.Add(
                    new DepartmentModel
                    {
                       DepartmentID = Convert.ToInt32(dr["DepartmentID"]),
                       DepartmentName= Convert.ToString(dr["DepartmentName"]),
                                           }
                    );
            }
            return s2;
        }

    }


}

