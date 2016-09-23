using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary
{
    public class ContractEmployee : EmployeeBase
    {
        override public decimal GetSalary()
        {
            return 1;
        }

        public new string Message()
        {
            return "new ContractEmp Msg";
        }

        public string BaseMessage()
        {
            return base.Message();
        }

        public override string OverrideTest()
        {
            return "OverrideTest from ContractEmployee Class";
        }
    }
}
