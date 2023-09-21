using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class CheckingAccount : BaseAccount, IFee
    {
        public CheckingAccount(decimal currentBalance) : base(currentBalance)
        {
        }

        public decimal Calculate() => CurrentBalance * _feeCheckingAccount;
    }
}