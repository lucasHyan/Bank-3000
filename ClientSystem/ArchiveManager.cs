using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BankSystem;
using ClientSystem;

namespace tp3._5
{
    public class ArchiveManager
    {
        public static CultureInfo ptBRCultureInfo = CultureInfo.CreateSpecificCulture("pt-BR");
        private static string[]? lines;
        internal static List<Client>? clients;

        public static void LoadClients()
        {
            lines = File.ReadAllLines("testeDados.txt");
            clients = lines.Select(line =>
            {
                string[] values = line.Split('|');
                return new Client(
                    values[0],
                    values[1],
                    decimal.Parse(values[2], ptBRCultureInfo),
            decimal.Parse(values[3], ptBRCultureInfo),
            decimal.Parse(values[4], ptBRCultureInfo)
                );
            }).ToList();
        }

        public static void WriteClients(string cpf, decimal balance, decimal fee)
        {
                    string archive = $"{Environment.CurrentDirectory}/{cpf}.txt";
                    if (File.Exists(archive))
                    {
                        GenerateConsoleLogUnsucessfully(cpf);
                        File.Create(archive).Close();
                    }
                    else
                    {
                        File.WriteAllLines(archive, new string[] { $"{balance}|{fee}" });
                        GenerateConsoleLogSuccess(cpf);
                    }
        }

        public static void GenerateConsoleLogSuccess(string cpf)
        {
            Console.WriteLine($"Archive {cpf}.txt created successfully.");
        }
        public static void GenerateConsoleLogUnsucessfully(string cpf)
        {
            Console.WriteLine($"Archive {cpf}.txt Has not been created.");
        }

    }
}
