using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem;

namespace ClientSystem
{
    internal class Client : BaseAccount, IFee
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public decimal CheckingAccount { get; set; }
        public decimal InternationalAccount { get; set; }
        public decimal CryptoAccount { get; set; }

        public Client(string cpf, string name, decimal checkingAccount, decimal internationalAccount, decimal cryptoAccount)
            : base(checkingAccount)
        {
            Cpf = cpf;
            Name = name;
            CheckingAccount = checkingAccount;
            InternationalAccount = internationalAccount;
            CryptoAccount = cryptoAccount;
        }

        public decimal Calculate()
        {
            decimal totalFee = 0m;

            totalFee += CurrentBalance * _feeCheckingAccount;
            totalFee += CurrentBalance * _feeInternationalAccount;

            return totalFee;
        }

        public override string ToString()
            => $"{this.CurrentBalance}|{Calculate()}";
        
    }
}
