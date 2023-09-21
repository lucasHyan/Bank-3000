using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class CryptoAccount : BaseAccount
    {
        private decimal _currentCryptoBalance;

        public CryptoAccount(decimal currentBalance) : base(currentBalance)
        {
        }

        public override decimal CurrentBalance
        {
            get => _currentCryptoBalance * _exchangeRate;
            protected set { _currentCryptoBalance = value; }
        }
    }
}