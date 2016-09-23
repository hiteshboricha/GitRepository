using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary
{
    public class PermanentEmployee : EmployeeBase
    {
        public override decimal GetSalary()
        {
            return 10;
        }

        public override string Message()
        {
            return "PermanentEmployee";
        }
    }
}
