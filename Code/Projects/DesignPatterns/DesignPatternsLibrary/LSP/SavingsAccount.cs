using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary.LSP
{
    public class SavingsAccount
    {
        private int _zero_balance_amount;
        private int _amount = 0;

        public int ZeroBalance
        {
            set
            {
                _zero_balance_amount = value;
            }

            get
            {
                return _zero_balance_amount;
            }
        }

        public SavingsAccount()
        {
            ZeroBalance = 10000;
        }

        public int WithdrawAmount
        {
            set
            {
                _amount = value;
            }

            get
            {
                return _amount;
            }
        }

        public virtual string Withdraw()
        {
            if (ZeroBalance > 10000 && WithdrawAmount < ZeroBalance)
            {
                return "Amount withdrawn";
            }
            else
            {
                throw new Exception("Not Allowed as minimum balance not maintained or no sufficient amount in account");
            }
        }
    }
}
