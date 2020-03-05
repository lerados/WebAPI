using ModelLayer;
using System;
using System.Collections.Generic;
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
            employees.Add(new Employee { ID = 1, Name = "Galih", ContactNumber = 1234567890, Addres = "Test Addres 111" });
            employees.Add(new Employee { ID = 2, Name = "Satria", ContactNumber = 0987654321, Addres = "Test Addres 222" });
        }

        //api/employee
        [Filters.CustomAuthentication]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }


        //api/employee/1
        [Filters.CustomAuthentication]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault<Employee>(x => x.ID.Equals(id));
        }
    }
}