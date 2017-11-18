using SEG.Azure.Data;
using SEG.Azure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG.Azure.WebJobScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateEmployeeDOB();
        }

        static int UpdateEmployeeDOB()
        {
            int noofemployeesupdated = 0;
            try
            {
                IEmployeeData employeedal = new EmployeeData();
                noofemployeesupdated = employeedal.UpdateEmployeeDOB();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return noofemployeesupdated;
        }
    }
}
