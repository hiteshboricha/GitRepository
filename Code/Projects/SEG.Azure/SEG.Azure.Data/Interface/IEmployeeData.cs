using SEG.Azure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG.Azure.Data
{
    public interface IEmployeeData
    {
        int InsertEmployee(Employee employee);
        List<Employee> GetEmployees(int employeeid);
        int UpdateEmployeeDOB();
    }
}
