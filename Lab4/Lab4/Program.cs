using System;
using Lab4Lib;
using Lab4Lib.Exception;
using System.Linq;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client("Ivan", "Ivanov", 123456, "0000");
            Client client2 = new Client("Pavlov", "Pavlo", 0123450, "0002");
            Client client3 = new Client("Sudorov", "Sudir", 012530, "03215");
            Client client4 = new Client("Petrov", "Petro", 12589, "4567");


            Currency usd = new Currency("usd", 26.75, 27.027);
            Currency ua = new Currency("ua", 1, 1);
            Currency eur = new Currency("eur", 28.8, 29.24);


            CreditInfo credit1 = new CreditInfo(121, "First Credit", 60,
                10000, 100000, 5, ua);
            CreditInfo credit2 = new CreditInfo(122, "Second Credit", 120, 
                15000, 200000, 4, ua);
            credit1.addCurrency(usd, 3, 400, 4000);
            credit2.addCurrency(eur, 12, 350, 4000);

            DepositInfo deposit1 = new DepositInfo(211, "First Deposit", 12, 
                1000, 10, ua);
            DepositInfo deposit2 = new DepositInfo(212, "Second Deposit", 20,
                5000, 11, ua);
            deposit1.addCurrency(usd, 7, 40);
            deposit2.addCurrency(usd, 6, 200);





            Bank PrivatBank = new Bank("Privat Bank", "Kyiv, Holovna, 20", "5555");
            PrivatBank.credits.Add(credit1);
            PrivatBank.credits.Add(credit2);

            PrivatBank.deposits.Add(deposit1);
            PrivatBank.deposits.Add(deposit2);

            PrivatBank.addClient(client1);
            PrivatBank.addClient(client2);
          
            PrivatBank.addClient(client3);
            PrivatBank.addClient(client4);




            PrivatBank.giveCreditToClient(client1, credit1, usd, 3000, 
                500, DateTime.Now.AddDays(1));
            PrivatBank.giveCreditToClient(client2, credit2, ua, 100000, 
                15000, DateTime.Now.AddDays(1));

            PrivatBank.giveDepositToClient(client3, deposit1, "123456", 
                1000, ua, DateTime.Now.AddDays(1));
            PrivatBank.giveDepositToClient(client4, deposit2, "456789", 
                2000, usd, DateTime.Now.AddDays(1));



            Console.WriteLine("Information");
            Console.WriteLine("All clients");
            foreach(var value in PrivatBank.clients)
            {
                Console.WriteLine($"{value.id}. {value.lastName} {value.firstName}");
            }
            Console.WriteLine();

            Console.WriteLine("All credits");
            foreach(var val in PrivatBank.credits)
            {
                string cur = "";
                foreach(var c in val.CurrencyPercent)
                {
                    cur = cur + " " + c.Key.name + " " + c.Value + "% ";
                }

                Console.WriteLine($"{val.id}. {val.name}: {cur}");
            }

            Console.WriteLine();

            Console.WriteLine("All deposits");
            foreach (var val in PrivatBank.deposits)
            {
                string cur = "";
                foreach (var c in val.CurrencyPercent)
                {
                    cur = cur + " " + c.Key.name + " " + c.Value + "% ";
                }

                Console.WriteLine($"{val.id}. {val.name}: {cur}");
            }

            Console.WriteLine();

            Console.WriteLine("All credits of client");
            foreach (var val in PrivatBank.ClientCredit)
            {
                Console.WriteLine($"Client id - {val.clientId}, Credit id - " +
                    $"{val.creditId}," +
                    $" Sum - {val.sum}{val.currency.name}");
            }


            Console.WriteLine();

            Console.WriteLine("All deposits of client");
            foreach (var val in PrivatBank.ClientDeposit)
            {
                Console.WriteLine($"Client id - {val.clientId}, Deposit id - " +
                    $"{val.depositId}," +
                    $" Sum - {val.startSum}{val.currency.name}");
            }
            Console.WriteLine();





            Console.WriteLine("Sort list of clients");
            var query1 = from client in PrivatBank.clients
                         orderby client.lastName, client.firstName
                         select client;
            foreach (var value in query1)
            {
                Console.WriteLine($"{value.id}. {value.lastName} {value.firstName}");
            }
            Console.WriteLine();

            

            var query2 = from credit in PrivatBank.ClientCredit
                        where credit.currency == usd
                        select credit;

            Console.WriteLine($"Select how many credits are in some currency, fox " +
                $"example in usd {query2.Count()}");
            Console.WriteLine();


            Console.WriteLine("Join clients and deposit for clients");
            var query3 = from clientDeposit in PrivatBank.ClientDeposit
                         join client in PrivatBank.clients on
                         clientDeposit.clientId equals client.id
                         orderby client.lastName
                         select new
                         {
                             client.lastName,
                             client.firstName,
                             clientDeposit.accountNumber,
                             clientDeposit.depositId
                         };

            foreach (var value in query3)
            {
                Console.WriteLine($"{value.lastName} {value.firstName} - " +
                    $"{value.accountNumber} - {value.depositId}");
            }

            Console.WriteLine();

            Console.WriteLine("Join previous and deposit info");
            var query4 = query3.Join(PrivatBank.deposits, q3 => q3.depositId,
                d => d.id, (q3, d) => 
                new { fullName = q3.lastName + " " + q3.firstName,
                    account = q3.accountNumber, NameDeposit = d.name });

            foreach (var value in query4)
            {
                Console.WriteLine($"{value.fullName} - {value.account} - " +
                    $"{value.NameDeposit}");
            }
            Console.WriteLine();


            Console.WriteLine("Do group by credit for people by currency");
            PrivatBank.giveCreditToClient(client3, credit1, usd, 3000, 500, 
                DateTime.Now.AddDays(1));

            var query5 = from credit in PrivatBank.ClientCredit
                         group credit by credit.currency;

            Console.WriteLine();


            foreach (IGrouping<Currency, Credit> value in query5)
            {
                Console.WriteLine(value.Key.name);
                foreach(var val in value)
                {
                    Console.WriteLine(val.creditId);
                }
            }
            Console.WriteLine();


            Bank OTP = new Bank("OTP", "123", "321");

            OTP.addClient(client1);
            OTP.addClient(client2);

            Console.WriteLine("Get clients that are in two banks");
            var query6 = PrivatBank.clients.Intersect(OTP.clients);

            foreach(var value in query6)
            {
                Console.WriteLine(value.lastName + " " + value.firstName);
            }
            Console.WriteLine();


            Console.WriteLine("Check somebody has credit in eur");
            var query7 = PrivatBank.ClientCredit.Any(credit => credit.currency == eur);
            Console.WriteLine(query7);
            Console.WriteLine();


            var query8 = from credits in PrivatBank.credits
                         where credits.term >= 36
                         select credits;
            Console.WriteLine($"Credits, which term more than 3 years - {query8.Count()}");
            Console.WriteLine();


            Console.WriteLine("Sum of credit > 100000");
            var query9 = from credits in PrivatBank.ClientCredit
                         where credits.sum >= 100000
                         select credits;
            var query10 = query9.Join(PrivatBank.credits,(q9) => q9.creditId,
                (credit) => credit.id,
                (q9, credits) => new {Sum = q9.sum, Name = credits.name });

            foreach (var value in query10)
            {
                Console.WriteLine($"{value.Name}, {value.Sum }");
            }
            Console.WriteLine();


            Console.WriteLine();


            Console.WriteLine("Clients who last name start with P");
            var query11 = from client in PrivatBank.clients
                          where client.lastName.StartsWith("P")
                          orderby client.firstName descending
                          select client;
            foreach(var value in query11)
            {
                Console.WriteLine($"{value.lastName} {value.firstName}");
            }
            Console.WriteLine();



            var query12 = (from credits in PrivatBank.credits
                           select credits).First();
            Console.WriteLine($"First element in credits {query12.name}");


        }
    }
}
