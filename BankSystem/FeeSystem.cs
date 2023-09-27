using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSystem;

namespace BankSystem
{
    internal class FeeSystem
    {
        private decimal totalValueAccount;
        private decimal totalValueFee;
        public event Action<string, decimal, decimal> CreateAccountComplete;
        public Action<string> callback;


        public void CalculateTotalFeesAndBalance(List<BaseAccount> accounts)
        {
            foreach (BaseAccount account in accounts)
            {
                if (account is IFee)
                {
                    totalValueFee += ((IFee)account).Calculate();
                    totalValueAccount += account.CurrentBalance;

                }
                else if (account is InternationalAccount || account is CryptoAccount)
                {
                    totalValueAccount += account.CurrentBalance;
                }
            }
        }

        public decimal CalculateClientBalance(List<Client> accounts,
        Action<string> callback)
        {

            foreach (BaseAccount account in accounts)
            {
                decimal totalFee = 0m;
                decimal totalValueAccount = 0m;

                totalFee += account.CurrentBalance * account._feeCheckingAccount;
                totalFee += account.CurrentBalance * account._feeInternationalAccount;
            }

            return totalValueAccount;
        }
            public override string ToString()
        {
            decimal balanceAfterFee = this.totalValueAccount - this.totalValueFee;

            CultureInfo ptBRCultureInfo = CultureInfo.CreateSpecificCulture("pt-BR");

            return "The Total Balance is " + this.totalValueAccount.ToString("C", ptBRCultureInfo) +
                " and the total fee is " + this.totalValueFee.ToString("C", ptBRCultureInfo) +
                ". After the fee your balance is " + balanceAfterFee.ToString("C2", ptBRCultureInfo) + ".";
        }
    }
}
