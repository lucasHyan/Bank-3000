using System;
using System.Collections.Generic;
using System.IO;
using BankSystem;
using ClientSystem;

namespace tp3._5
{
    public class ArchiveManager
    {
        private static string[]? lines;
        internal static List<Client>? clients;

        new FeeSystem feeSystem = new FeeSystem();

        public static void LoadClients()
        {
            lines = File.ReadAllLines("testeDados.txt");
            clients = lines.Select(line =>
            {
                string[] values = line.Split('|');
                return new Client(
                    values[0],
                    values[1],
                    decimal.Parse(values[2]),
                    decimal.Parse(values[3]),
                    decimal.Parse(values[4])
                );
            }).ToList();
        }

        public static void WriteClients(string cpf, decimal balance, decimal fee)
        {
            if (clients != null)
            {
                foreach (Client client in clients)
                {
                    string archive = $"{Environment.CurrentDirectory}\\{cpf}.txt";
                    if (!File.Exists(archive))
                    {
                        File.Create(archive).Close();
                    }

                    File.WriteAllLines(archive, new string[] { $"{balance}|{fee}" });
                }
            }
        }

        public static void GenerateConsoleLogSuccess(string cpf)
        {
            Console.WriteLine($"Arquivo gerado para o cpf {cpf} criado com sucesso!");
        }

    }
}
