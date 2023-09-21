using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class InternationalAccount : BaseAccount, IFee
    {
        private decimal _currentInternationalBalance;
        public InternationalAccount(decimal currentBalance) : base(currentBalance)
        {
        }

        public override decimal CurrentBalance
        {
            get => _currentInternationalBalance * _exchangeRate;
            protected set { _currentInternationalBalance = value; }
        }

        public decimal Calculate() => CurrentBalance * _feeInternationalAccount;
    }
}