using System;
using Lab5Lib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client("Ivan", "Ivanov", 123456, "0000");
            Client client2 = new Client("Pavlo", "Pavlov", 0123450, "0002");
            Client client3 = new Client("Sudir", "Sudorov", 012530, "03215");
            Client client4 = new Client("Petro", "Petrov", 12589, "4567");

            Bank Bank1 = new Bank("Bank1", "Kyiv", "5555");

            Bank1.addClient(client1);
            Bank1.addClient(client2);
            Bank1.addClient(client3);
            Bank1.addClient(client4);

            List<Currency> currencies = new List<Currency>();
            Currency usd = new Currency("usd", 26.75, 27.027);
            Currency ua = new Currency("ua", 1, 1);
            Currency eur = new Currency("eur", 28.8, 29.24);

            currencies.Add(usd);
            currencies.Add(ua);
            currencies.Add(eur);

            DepositInfo deposit1 = new DepositInfo(211, "First Deposit", 12,
                1000, 10, ua);
            DepositInfo deposit2 = new DepositInfo(212, "Second Deposit", 20,
                5000, 11, ua);
            deposit1.addCurrency(usd, 7, 40);
            deposit2.addCurrency(usd, 6, 200);

            Bank1.deposits.Add(deposit1);
            Bank1.deposits.Add(deposit2);

            Bank1.giveDepositToClient(client3, deposit1, "123456",
                1000, ua, DateTime.Now.AddDays(1));
            Bank1.giveDepositToClient(client4, deposit2, "456789",
                2000, usd, DateTime.Now.AddDays(1));

            CreditInfo credit1 = new CreditInfo(121, "First Credit", 60,
               10000, 100000, 5, ua);
            CreditInfo credit2 = new CreditInfo(122, "Second Credit", 120,
                15000, 200000, 4, ua);
            credit1.addCurrency(usd, 3, 400, 4000);
            credit2.addCurrency(eur, 12, 350, 4000);

            Bank1.credits.Add(credit1);
            Bank1.credits.Add(credit2);


            Bank1.giveCreditToClient(client1, credit1, usd, 3000,
                500, DateTime.Now.AddDays(1));
            Bank1.giveCreditToClient(client2, credit2, ua, 100000,
                15000, DateTime.Now.AddDays(1));


            XMLHelper xmlHelper = new XMLHelper("BANK.xml");

            xmlHelper.WriteInfoToXml(Bank1, currencies);

            Bank bank2 = new Bank("111", "123", "555555");
            xmlHelper.getInfoFromXml(ref bank2, currencies);

            showInfoFromXml(bank2);
        }

        private static void showInfoFromXml(Bank bank)
        {
            showBankInfo(bank);
            Console.WriteLine();
            showClients(bank.Clients);
            Console.WriteLine();
            showCredits(bank.credits);
            Console.WriteLine();
            showDeposit(bank.deposits);
            Console.WriteLine();
            showClientCredits(bank.ClientCredit);
            Console.WriteLine();
            showClientDeposits(bank.ClientDeposit);
            Console.WriteLine();
        }

        private static void showBankInfo(Bank bank)
        {
            Console.WriteLine($"Bank {bank.name}");
            Console.WriteLine($"Phone {bank.phone}");
            Console.WriteLine($"Address {bank.address}");
        }

        private static void showClientDeposits(List<Deposit> clientDeposits)
        {
            Console.WriteLine("Deposits of clients");
            foreach (var val in clientDeposits)
            {
                Console.WriteLine($"Client id - {val.clientId}, Deposit id - " +
                    $"{val.depositId}," +
                    $" Sum - {val.startSum}{val.currency.name}");   
            }
        }

        private static void showClientCredits(List<Credit> clientCredits)
        {
            Console.WriteLine("Credits of clients");
            foreach (var val in clientCredits)
            {
                Console.WriteLine($"Client id - {val.clientId}, Credit id - " +
                    $"{val.creditId}," +
                    $" Sum - {val.sum}{val.currency.name}");
            }

        }

        private static void showDeposit(List<DepositInfo> deposits)
        {
            Console.WriteLine("Deposits");
            foreach (var val in deposits)
            {
                string cur = "";
                foreach (var c in val.CurrencyPercent)
                {
                    cur = cur + " " + c.Key.name + " " + c.Value + "% ";
                }

                Console.WriteLine($"{val.id}. {val.name}: {cur}");
            }
        }

        private static void showCredits(List<CreditInfo> credits)
        {
            Console.WriteLine("Credits");
            foreach (var credit in credits)
            {
                string cur = "";
                foreach (var c in credit.CurrencyPercent)
                {
                    cur = cur + " " + c.Key.name + " " + c.Value + "% ";

                }

                Console.WriteLine($"{credit.id}. {credit.name}: {cur}");
            }
        }

        private static void showClients(List<Client> clients)
        {
            Console.WriteLine("Clients");
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.firstName} {client.lastName} - {client.ITN}");
            }
        }
    }
}
