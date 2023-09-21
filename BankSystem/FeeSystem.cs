using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class FeeSystem
    {
        private decimal totalValueAccount;
        private decimal totalValueFee;


        public void CalculateTotalFeesAndBalance(List<BaseAccount> accounts)
        {
            foreach (var account in accounts)
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
        public override string ToString()
        {
            decimal balanceAfterFee = totalValueAccount - totalValueFee;

            CultureInfo ptBRCultureInfo = CultureInfo.CreateSpecificCulture("pt-BR");

            return "The Total Balance is " + totalValueAccount.ToString("C", ptBRCultureInfo) +
            " and the total fee is " + totalValueFee.ToString("C", ptBRCultureInfo) +
            ". After the fee your balance is " + balanceAfterFee.ToString("C2", ptBRCultureInfo) + ".";
        }
    }
}