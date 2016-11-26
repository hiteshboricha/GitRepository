using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary.LSP
{
    public class CurrentAccount : SavingsAccount
    {
        public CurrentAccount()
        {
            ZeroBalance = 0;
        }

        public override string Withdraw()
        {
            if (ZeroBalance > 0)
            {
                return "Amount withdrawn";
            }
            else
            {
                throw new Exception("No sufficient balance in account");
            }
        }
    }
}
