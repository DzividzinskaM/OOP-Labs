using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Lab4Lib.Exception;

namespace Lab4Lib
{
    public class Bank
    {
        public string name { get; }
        public string address { get; }
        public string phone { get; }
        public List<Client> clients = new List<Client>();
        public List<CreditInfo> credits = new List<CreditInfo>();
        public List<DepositInfo> deposits = new List<DepositInfo>();

        public List<Credit> ClientCredit = new List<Credit>();
        public List<Deposit> ClientDeposit = new List<Deposit>();

        public Bank(string name, string address, string phone)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
        }
        public void addClient(Client client)
        {
            if (!clients.Contains(client))
            {
                clients.Add(client);
            }
            else
            {
                throw new BankException("is already exist in your bank",
                    $"{client.lastName} {client.firstName} ");

            }
        }

        public void giveCreditToClient(Client client, CreditInfo credit, Currency currency, 
            double requestSum, double advanse, DateTime date)
        {
            if (!clients.Contains(client))
                throw new BankException("isn't client of our bank", $"{client.lastName}" +
                    $" {client.firstName} ");
            if (!credits.Contains(credit))
                throw new BankException(" doesn't exist in our service", credit.name);
           

            if(ClientCredit.Any(c => c.creditId == client.id))
            {
                throw new BankException(" already has credit", $"{client.lastName} " +
                    $"{client.firstName} "); 
            }
            else
            {
                Credit c = new Credit(credit, client, requestSum, advanse, currency, date);
                ClientCredit.Add(c);
            }
        }

        public void giveDepositToClient(Client client, DepositInfo deposit, string accNumber, 
            double startSum,Currency currency, DateTime date)
        {
            if (!clients.Contains(client))
                throw new BankException("isn't client of our bank", $"{client.lastName}" +
                    $" {client.firstName} ");
            if (!deposits.Contains(deposit))
                throw new BankException(" doesn't exist in our service", deposit.name);
 
            Deposit d = new Deposit(client, deposit, accNumber, startSum, currency, date);
            ClientDeposit.Add(d);
        }
    }
}
