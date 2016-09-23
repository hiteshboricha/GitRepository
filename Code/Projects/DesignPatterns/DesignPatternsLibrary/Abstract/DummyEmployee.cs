using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary
{
    public class DummyEmployee : ContractEmployee
    {
        override public decimal GetSalary()
        {
            return 1;
        }

        public new string Message()
        {
            return "new Dummy Emp Msg";
        }

        public override string OverrideTest()
        {
            return "OverrideTest from Dummy Employee Class";
        }
    }
}
