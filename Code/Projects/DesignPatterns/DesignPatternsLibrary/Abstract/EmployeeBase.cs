using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary
{
    public abstract class EmployeeBase
    {
        public string FirstName { get; set; }

        public abstract decimal GetSalary();

        public virtual string Message()
        {
            return "From EmployeeBase";
        }

    }
}
