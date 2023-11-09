using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem;
using ClientSystem;
using static tp3._5.CreateAccount;

namespace tp3._5
{
    internal class MainMenu
    {
        public static string logo = @"
 /$$$$$$$   /$$$$$$  /$$   /$$ /$$   /$$      /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$ 
| $$__  $$ /$$__  $$| $$$ | $$| $$  /$$/     /$$__  $$ /$$$_  $$ /$$$_  $$ /$$$_  $$
| $$  \ $$| $$  \ $$| $$$$| $$| $$ /$$/     |__/  \ $$| $$$$\ $$| $$$$\ $$| $$$$\ $$
| $$$$$$$ | $$$$$$$$| $$ $$ $$| $$$$$/ /$$$$$$ /$$$$$/| $$ $$ $$| $$ $$ $$| $$ $$ $$
| $$__  $$| $$__  $$| $$  $$$$| $$  $$|______/|___  $$| $$\ $$$$| $$\ $$$$| $$\ $$$$
| $$  \ $$| $$  | $$| $$\  $$$| $$\  $$      /$$  \ $$| $$ \ $$$| $$ \ $$$| $$ \ $$$
| $$$$$$$/| $$  | $$| $$ \  $$| $$ \  $$    |  $$$$$$/|  $$$$$$/|  $$$$$$/|  $$$$$$/
|_______/ |__/  |__/|__/  \__/|__/  \__/     \______/  \______/  \______/  \______/ 
                                                                                    
                                                                                    
                                                                                    

";
        public static List<BaseAccount> _accountsList = new List<BaseAccount>();
        public static void ShowMainMenu()
        {
            FeeSystem feeSystem = new FeeSystem();

            string input;
            do
            {
                Console.WriteLine(logo);
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Show Fees and Balance");
                Console.WriteLine("3. Read Account File");
                Console.WriteLine("4. Exit");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        CreateAccountMenu();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(logo);
                        feeSystem.CalculateTotalFeesAndBalance(_accountsList);
                        Console.WriteLine(feeSystem.ToString());
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        Console.Clear();
                        return;

                    case "3":
                        ArchiveManager.LoadClients();
                        feeSystem.CalculateClientBalance(ArchiveManager.clients,
                         ArchiveManager.WriteClients);
                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case "4":
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (string.IsNullOrEmpty(input));
        }
        public static void CreateAccountMenu()
        {
            string input;
            do
            {
                Console.WriteLine(logo);
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create a Checking Account");
                Console.WriteLine("2. Create a Crypto Account");
                Console.WriteLine("3. Create a International Account");
                Console.WriteLine("4. Return to Main Menu");

                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            if (input == "4")
            {
                Console.Clear();
                return;
            }

            switch (input)
            {
                case "1":
                    CreateCheckingAccount(_accountsList);
                    break;
                case "2":
                    CreateCryptoAccount(_accountsList);
                    break;
                case "3":
                    CreateInternationalAccount(_accountsList);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey();
                    Console.Clear();
                    input = "";
                    return;
            }
        }
    }
}
