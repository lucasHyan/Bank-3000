using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal abstract class BaseAccount
    {
        internal decimal _exchangeRate = 4M;
        internal decimal _feeCheckingAccount = 0.015M;
        internal decimal _feeInternationalAccount = 0.025M;
        public virtual decimal CurrentBalance { get; protected set; }

        public BaseAccount(decimal currentBalance)
        {
            CurrentBalance = currentBalance;
        }
    }
}