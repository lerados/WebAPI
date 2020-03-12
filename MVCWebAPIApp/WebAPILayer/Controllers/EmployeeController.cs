using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPILayer.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employees;
        public EmployeeController()
        {
            employees = new List<Employee>();
            //employees.Add(new Employee { ID = 1, Name = "Galih", ContactNumber = 1234567890, Addres = "Test Addres 111" });
            //employees.Add(new Employee { ID = 2, Name = "Satria", ContactNumber = 0987654321, Addres = "Test Addres 222" });
        }

        //api/employee
        [Filters.CustomAuthentication]
        public IEnumerable<Employee> Get()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
            string command = "SELECT * FROM EMPLOYEE";
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                employees.Add(new Employee
                {
                    ID = (int)dr["ID"],
                    Name = (string)dr["FirstName"] + " " + dr["LastName"].ToString(),
                    ContactNumber = Convert.ToInt64(dr["ContactNumber"]),
                    Addres = (string)dr["Address"]
                });
            }
            cn.Close();
            return employees;
        }


        //api/employee/1
        [Filters.CustomAuthentication]
        public Employee Get(int id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
            string command = "SELECT * FROM EMPLOYEE WHERE ID = " + id;
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employees.Add(new Employee
                {
                    ID = (int)dr["ID"],
                    Name = (string)dr["FirstName"] + " " + dr["LastName"].ToString(),
                    ContactNumber = Convert.ToInt64(dr["ContactNumber"]),
                    Addres = (string)dr["Address"]
                });
            }
            cn.Close();
            return employees.FirstOrDefault<Employee>(x => x.ID.Equals(id));
        }
    }
}