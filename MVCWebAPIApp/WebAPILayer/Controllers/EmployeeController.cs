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
using EntityFrameworkLayer;

namespace WebAPILayer.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeManager emanager;
        public EmployeeController()
        {
            emanager = new EmployeeManager();
        }

        //home/
        [Filters.CustomAuthentication]
        public IEnumerable<Employee> Get()
        {
            return emanager.GetAllEmployee();
        }

        //home/get/1
        [Filters.CustomAuthentication]
        public Employee Get(int id)
        {
            return emanager.GetEmployeeByID(id);
        }
    }
}