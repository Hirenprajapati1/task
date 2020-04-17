using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using task1.Models;

namespace task1.Repository
{
    public class DesignationRepository
    {
        public List<DesignationModel> GetDesignations()
        {
            SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
                List<DesignationModel> s2 = new List<DesignationModel>();

                SqlDataAdapter sa = new SqlDataAdapter("GetDesignation", sc);
                DataTable dt = new DataTable();
                sa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sc.Open();
                sa.Fill(dt);
                sc.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    s2.Add(
                        new DesignationModel
                        {
                            DesignationID = Convert.ToInt32(dr["DesignationID"]),
                            DesignationName = Convert.ToString(dr["DesignationName"]),
                        }
                        );
                }
                return s2;
            
        }
    }
}
