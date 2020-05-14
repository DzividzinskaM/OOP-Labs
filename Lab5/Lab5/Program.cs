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
            Client client2 = new Client("Pavlov", "Pavlo", 0123450, "0002");
            Client client3 = new Client("Sudorov", "Sudir", 012530, "03215");
            Client client4 = new Client("Petrov", "Petro", 12589, "4567");

            Bank Bank1 = new Bank("Bank1", "Kyiv", "5555");

            Bank1.addClient(client1);
            Bank1.addClient(client2);
            Bank1.addClient(client3);
            Bank1.addClient(client4);

            Currency usd = new Currency("usd", 26.75, 27.027);
            Currency ua = new Currency("ua", 1, 1);
            Currency eur = new Currency("eur", 28.8, 29.24);

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





            using (XmlWriter writer = XmlWriter.Create("BANKS.xml"))
            {
                writer.WriteStartElement("Bank");

                writer.WriteAttributeString("name", Bank1.name);
                writer.WriteAttributeString("adress", Bank1.address);
                writer.WriteAttributeString("phone", Bank1.phone);


                writer.WriteStartElement("Clients");
                foreach(var client in Bank1.Clients)
                {
                    writer.WriteStartElement("client");
                    writer.WriteAttributeString("id", client.id.ToString());
                    writer.WriteAttributeString("firstName", client.firstName);
                    writer.WriteAttributeString("lastName", client.lastName);
                    writer.WriteAttributeString("ITN", client.ITN.ToString());
                    writer.WriteAttributeString("phone", client.phone.ToString());
                    writer.WriteEndElement(); //client

                }
                writer.WriteEndElement(); //Clients


                writer.WriteStartElement("Deposits");
                foreach(var deposit in Bank1 .deposits)
                {
                    writer.WriteStartElement("deposit");
                    writer.WriteAttributeString("id", deposit.id.ToString());
                    writer.WriteAttributeString("name", deposit.name.ToString());
                    writer.WriteAttributeString("term", deposit.term.ToString());
                    writer.WriteStartElement("CurrencyParametrs");
                    foreach(var currencyKey in deposit.CurrencyPercent.Keys)
                    {
                        writer.WriteStartElement("currency");
                        writer.WriteAttributeString("name", currencyKey.name);
                        writer.WriteAttributeString("buying", currencyKey.buying.ToString());
                        writer.WriteAttributeString("selling", currencyKey.sellling.ToString());
                        writer.WriteElementString("percent", deposit.CurrencyPercent[currencyKey].ToString());
                        writer.WriteElementString("startSum", deposit.startSum[currencyKey].ToString());
                        writer.WriteEndElement(); //currency
                    }
                    
                    writer.WriteEndElement(); //currencyParametr
                    writer.WriteEndElement(); //deposit
                }
                writer.WriteEndElement(); //Deposits


                writer.WriteStartElement("Credits");
                foreach (var credit in Bank1.credits)
                {
                    writer.WriteStartElement("credit");
                    writer.WriteAttributeString("id", credit.id.ToString());
                    writer.WriteAttributeString("name", credit.name);
                    writer.WriteAttributeString("term", credit.term.ToString());

                    writer.WriteStartElement("currencyParametr");
                    foreach(var currencyKey in credit.CurrencyPercent.Keys)
                    {
                        writer.WriteStartElement("currency");
                        writer.WriteAttributeString("name", currencyKey.name);
                        writer.WriteAttributeString("buying", currencyKey.buying.ToString());
                        writer.WriteAttributeString("selling", currencyKey.sellling.ToString());
                        writer.WriteElementString("percent", credit.CurrencyPercent[currencyKey].ToString());
                        writer.WriteElementString("startSum", credit.StartSum[currencyKey].ToString());
                        writer.WriteElementString("maxSum", credit.MaxSum[currencyKey].ToString());
                        writer.WriteEndElement(); //currency
                    }
                    writer.WriteEndElement(); //currencyParemetr

                    writer.WriteEndElement(); //credit
                }
                writer.WriteEndElement(); //credits

                writer.WriteStartElement("ClientDeposits");

                foreach(var deposit in Bank1.ClientDeposit)
                {
                    writer.WriteStartElement("clientDeposit");
                    writer.WriteAttributeString("clientId", deposit.clientId.ToString());
                    writer.WriteAttributeString("depositId", deposit.depositId.ToString());
                    writer.WriteAttributeString("accountNumber", deposit.accountNumber);
                    writer.WriteAttributeString("startSum", deposit.startSum.ToString());
                    writer.WriteStartElement("currency");
                    writer.WriteAttributeString("name", deposit.currency.name);
                    writer.WriteAttributeString("buying", deposit.currency.buying.ToString());
                    writer.WriteAttributeString("selling", deposit.currency.sellling.ToString());
                    writer.WriteEndElement(); //currency
                    writer.WriteStartElement("dateParametres");
                    writer.WriteAttributeString("startDate", deposit.startDate.ToString());
                    writer.WriteAttributeString("endDate", deposit.endDate.ToString());
                    writer.WriteEndElement(); //date
                    writer.WriteEndElement(); //clientDeposit
                }

                writer.WriteEndElement();  //ClientDeposits

                writer.WriteStartElement("ClientCredits");

                foreach(var credit in Bank1.ClientCredit)
                {
                    writer.WriteStartElement("clientCredit");
                    writer.WriteAttributeString("clientId", credit.clientId.ToString());
                    writer.WriteAttributeString("creditId", credit.creditId.ToString());
                    writer.WriteAttributeString("sum", credit.sum.ToString());
                    writer.WriteAttributeString("startSum", credit.startSum.ToString());

                    writer.WriteStartElement("currency");
                    writer.WriteAttributeString("name", credit.currency.name);
                    writer.WriteAttributeString("buying", credit.currency.buying.ToString());
                    writer.WriteAttributeString("selling", credit.currency.sellling.ToString());
                    writer.WriteEndElement(); //currency

                    writer.WriteStartElement("dateParametres");
                    writer.WriteAttributeString("startDate", credit.startDate.ToString());
                    writer.WriteAttributeString("endDate", credit.endDate.ToString());
                    writer.WriteEndElement(); //date
                    writer.WriteEndElement(); //clientCredit
                }

                writer.WriteEndElement(); //ClientCredits;

                writer.WriteEndElement(); //Bank

            }
        }
    }
}
