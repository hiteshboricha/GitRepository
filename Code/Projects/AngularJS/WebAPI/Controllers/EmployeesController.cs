using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        Employee[] employees = new Employee[] 
        { 
            new Employee { Id = 1, Name = "Nitin", BU = "Nordics", ManagerId = 7 }, 
            new Employee { Id = 2, Name = "Sanjay", BU = "Oracle", ManagerId = 7 }, 
            new Employee { Id = 3, Name = "Shailesh", BU = "Nordics", ManagerId = 7 }
        };

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees.OrderByDescending(e => e.Name);
        }
    }
}
