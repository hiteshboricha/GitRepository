using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BU { get; set; }
        public int ManagerId { get; set; }
        //public Employee Manager { get; set; }
    }
}