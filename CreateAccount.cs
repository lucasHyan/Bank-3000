using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem;

namespace tp3._5
{
    internal class CreateAccount
    {
        public static CryptoAccount CreateCryptoAccount()
        {
            decimal balance = 0;
            bool validInput = false;
            do
            {
                Console.WriteLine("Enter the current balance:");
                try
                {
                    string input = Console.ReadLine();
                    if (input != null)
                    {
                        balance = decimal.Parse(input);
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid decimal value.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal value.");
                }
            } while (!validInput);

            CryptoAccount account = new CryptoAccount(balance);
            return account;

            Console.WriteLine("Crypto account created successfully.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
