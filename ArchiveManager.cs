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
        private static List<Client>? clients;

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

        public static void WriteClients()
        {
            if (clients != null)
            {
                foreach (Client client in clients)
                {
                    string archive = $"{Environment.CurrentDirectory}\\{client.Cpf}.txt";
                    if (!File.Exists(archive))
                    {
                        File.Create(archive).Close();
                    }
                    
                    File.WriteAllLines(archive, new string[] { client.ToString() });
                }
            }
        }

    }
}
