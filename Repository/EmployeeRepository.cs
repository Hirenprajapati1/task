using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using task1.Models;
using task1.Repository;


namespace task1.Repository
{
    public class EmployeeRepository
    {

        public bool AddEmployeeData(EmployeeModel st)
        {
            try
            {
                SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

                SqlCommand cd = new SqlCommand("AddEmployee1", sc);
                cd.CommandType = System.Data.CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@Name", st.Name);
                cd.Parameters.AddWithValue("@Email", st.Email);
                cd.Parameters.AddWithValue("@EmployeeCode", st.EmployeeCode);
                cd.Parameters.AddWithValue("@Gender", st.Gender);
                cd.Parameters.AddWithValue("@Designation", st.Designation);
                cd.Parameters.AddWithValue("@Department", st.Department);
                cd.Parameters.AddWithValue("@DOB", st.DOB);
                cd.Parameters.AddWithValue("@Salary", st.Salary);
                sc.Open();
                bool isExecute = Convert.ToBoolean(cd.ExecuteNonQuery());
                sc.Close();
                return isExecute;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }



        public List<EmployeeModel> GetEmployees()
        {
            SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            List<EmployeeModel> s2 = new List<EmployeeModel>();

            SqlDataAdapter sa = new SqlDataAdapter("GetEmployee2", sc);
            DataTable dt = new DataTable();
            sa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sc.Open();
            sa.Fill(dt);
            sc.Close();
            foreach (DataRow dr in dt.Rows)
            {
                s2.Add(
                    new EmployeeModel
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        EmployeeCode = Convert.ToString(dr["EmployeeCode"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        //Designation = Convert.ToInt32(dr["Designation"]),
                        DesignationName=Convert.ToString(dr["DesignationName"]),
                        //Department = Convert.ToInt32(dr["Department"]),
                        DepartmentName = Convert.ToString(dr["DepartmentName"]),
                        DOB = Convert.ToDateTime(dr["DOB"]),
                        Salary = Convert.ToInt32(dr["Salary"])
                    }
                    );
            }
            return s2;
        }


        public bool UpdateEmployeeData(EmployeeModel st)
        {
            try
            {
                SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
                SqlCommand cd = new SqlCommand("UpdateEmployee3", sc);
                cd.CommandType = System.Data.CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ID", st.ID);
                cd.Parameters.AddWithValue("@Name", st.Name);
                cd.Parameters.AddWithValue("@Email", st.Email);
                cd.Parameters.AddWithValue("@EmployeeCode", st.EmployeeCode);
                cd.Parameters.AddWithValue("@Gender", st.Gender);
                cd.Parameters.AddWithValue("@Designation", st.Designation);
                cd.Parameters.AddWithValue("@Department", st.Department);
                cd.Parameters.AddWithValue("@DOB", st.DOB);
                cd.Parameters.AddWithValue("@Salary", st.Salary);
                sc.Open();
                bool isExecute = Convert.ToBoolean(cd.ExecuteNonQuery());
                sc.Close();
                return isExecute;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }


        public bool DeleteEmployeeData(int ID)
        {
            SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = database1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cd = new SqlCommand("DeleteEmployee", sc);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@ID", ID);
            sc.Open();
            int isExecute = cd.ExecuteNonQuery();
            sc.Close();
            if (isExecute > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}
