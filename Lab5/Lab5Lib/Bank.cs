using System;
using System.Collections.Generic;
using System.Linq;
using Lab5Lib;
using System.Xml;

namespace Lab5Lib
{
    public class Bank
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public List<Client> Clients = new List<Client>(); 
        public List<DepositInfo> deposits = new List<DepositInfo>();
        public List<CreditInfo> credits = new List<CreditInfo>();
     

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
            if (!Clients.Contains(client))
            {
                Clients.Add(client);
            }
            else
            {
                throw new BankException("is already exist in your bank",
                    $"{client.lastName} {client.firstName} ");

            }
        }

        public void giveDepositToClient(Client client, DepositInfo deposit, string accNumber,
            double startSum, Currency currency, DateTime date)
        {
            if (!Clients.Contains(client))
                throw new BankException("isn't client of our bank", $"{client.lastName}" +
                    $" {client.firstName} ");
            if (!deposits.Contains(deposit))
                throw new BankException(" doesn't exist in our service", deposit.name);

            Deposit d = new Deposit(client, deposit, accNumber, startSum, currency, date);
            ClientDeposit.Add(d);
        }

        public void giveCreditToClient(Client client, CreditInfo credit, Currency currency,
            double requestSum, double advanse, DateTime date)
        {
            if (!Clients.Contains(client))
                throw new BankException("isn't client of our bank", $"{client.lastName}" +
                    $" {client.firstName} ");
            if (!credits.Contains(credit))
                throw new BankException(" doesn't exist in our service", credit.name);


            if (ClientCredit.Any(c => c.creditId == client.id))
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

       

       

        public void getInfoFromXML()
        {
            XmlDocument document = new XmlDocument();
            document.Load("BANKS.xml");

        }

    }
}
