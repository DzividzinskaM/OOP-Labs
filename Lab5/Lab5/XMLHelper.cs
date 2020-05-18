using System;
using System.Collections.Generic;
using System.Text;
using Lab5Lib;
using System.Xml;

namespace Lab5
{
    public class XMLHelper
    {
        public string fileName { get; }
        private string firstNameAttrName = "firstName";
        private string lastNameAttrName = "lastName";
        private string phoneAttrName = "phone";
        private string idAttrName = "id";
        private string ITNAttrName = "ITN";
        private string clientElemName = "client";
        private string nameAttrName = "name";
        private string termAttrName = "term";
        private string currencyElemName = "currency";
        private string buyingAttrName = "buying";
        private string sellingAttrName = "selling";
        private string percentElemName = "percent";
        private string startSumElemName = "startSum";
        private string maxSumElemName = "maxSum";
        private string currParamElemName = "currencyParametr";
        private string creditElemName = "credit";
        private string currenciesElemName = "Currencies";
        private string depositElemName = "deposit";


        public XMLHelper(string name)
        {
            fileName = name;
        }
        public void WriteInfoToXml(Bank bank, List<Currency> currencies)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartElement("FinancialInfo");

                writer.WriteStartElement(currenciesElemName);
                foreach (var currency in currencies)
                {
                    writer.WriteStartElement(currenciesElemName);
                    writer.WriteElementString(nameAttrName, currency.name);
                    writer.WriteElementString(buyingAttrName, currency.buying.ToString());
                    writer.WriteElementString(sellingAttrName, currency.sellling.ToString());
                    writer.WriteEndElement();

                }
                writer.WriteEndElement(); //Currency

                writer.WriteStartElement("Bank");

                writer.WriteAttributeString("name", bank.name);
                writer.WriteAttributeString("adress", bank.address);
                writer.WriteAttributeString("phone", bank.phone);


                writer.WriteStartElement("Clients");
                foreach (var client in bank.Clients)
                {
                    writer.WriteStartElement(clientElemName);
                    writer.WriteAttributeString(idAttrName, client.id.ToString());
                    writer.WriteAttributeString(firstNameAttrName, client.firstName);
                    writer.WriteAttributeString(lastNameAttrName, client.lastName);
                    writer.WriteAttributeString(ITNAttrName, client.ITN.ToString());
                    writer.WriteAttributeString(phoneAttrName, client.phone.ToString());
                    writer.WriteEndElement(); //client

                }
                writer.WriteEndElement(); //Clients


                writer.WriteStartElement("Deposits");
                foreach (var deposit in bank.deposits)
                {
                    writer.WriteStartElement(depositElemName);
                    writer.WriteAttributeString(idAttrName, deposit.id.ToString());
                    writer.WriteAttributeString(nameAttrName, deposit.name.ToString());
                    writer.WriteAttributeString(termAttrName, deposit.term.ToString());
                    writer.WriteStartElement(currParamElemName);
                    foreach (var currencyKey in deposit.CurrencyPercent.Keys)
                    {
                        writer.WriteStartElement(currencyElemName);
                        writer.WriteAttributeString(nameAttrName, currencyKey.name);
                        writer.WriteElementString(percentElemName, deposit.CurrencyPercent[currencyKey].ToString());
                        writer.WriteElementString(startSumElemName, deposit.startSum[currencyKey].ToString());
                        writer.WriteEndElement(); //currency
                    }

                    writer.WriteEndElement(); //currencyParametr
                    writer.WriteEndElement(); //deposit
                }
                writer.WriteEndElement(); //Deposits


                writer.WriteStartElement("Credits");
                foreach (var credit in bank.credits)
                {
                    writer.WriteStartElement(creditElemName);
                    writer.WriteAttributeString(idAttrName, credit.id.ToString());
                    writer.WriteAttributeString(nameAttrName, credit.name);
                    writer.WriteAttributeString(termAttrName, credit.term.ToString());

                    writer.WriteStartElement(currParamElemName);
                    foreach (var currencyKey in credit.CurrencyPercent.Keys)
                    {
                        writer.WriteStartElement(currencyElemName);
                        writer.WriteAttributeString(nameAttrName, currencyKey.name);
                        writer.WriteElementString(percentElemName, credit.CurrencyPercent[currencyKey].ToString());
                        writer.WriteElementString(startSumElemName, credit.StartSum[currencyKey].ToString());
                        writer.WriteElementString(maxSumElemName, credit.MaxSum[currencyKey].ToString());
                        writer.WriteEndElement(); //currency
                    }
                    writer.WriteEndElement(); //currencyParemetr

                    writer.WriteEndElement(); //credit
                }
                writer.WriteEndElement(); //credits

                writer.WriteStartElement("ClientDeposits");

                foreach (var deposit in bank.ClientDeposit)
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

                foreach (var credit in bank.ClientCredit)
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

                writer.WriteEndElement();

            }
        }

        public void getInfoFromXml(Bank bank, List<Currency> currencies)
        {

            
            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            var clients = document.GetElementsByTagName("client");
            getCurrencyLstFromXml(document);
            getClientsListFromXml(document);
            getCreditsListFromXml(document);
            getDepositsListFromXml(document);
           // Console.WriteLine(clients);
            /*foreach(XmlNode client in clients)
            {
                //Console.WriteLine(client);
                //Console.WriteLine("first name");
                var name = client.Attributes.GetNamedItem("firstName");
                Console.WriteLine(name.Value);
            }*/
            //Console.WriteLine(b["name"].InnerText);
        }

        

        private List<Currency> getCurrencyLstFromXml(XmlDocument document)
        {
            List<Currency> currenciesLst = new List<Currency>();
            var currencies = document.GetElementsByTagName(currenciesElemName)[0].ChildNodes;
            foreach(XmlNode currency in currencies)
            {
                string name = "";
                double buying = 0;
                double selling = 0;
                foreach(XmlNode currencyParam in currency.ChildNodes)
                {
                    if (currencyParam.Name == nameAttrName)
                        name = currencyParam.InnerText;
                    if (currencyParam.Name == buyingAttrName)
                        buying = double.Parse(currencyParam.InnerText);
                    if (currencyParam.Name == sellingAttrName)
                        selling = double.Parse(currencyParam.InnerText);
                }
                currenciesLst.Add(new Currency(name, buying, selling));
            }

            return currenciesLst;        
        }

        private Currency getCurrencyByName(List<Currency> currencies, string name)
        {
            foreach(var value in currencies)
            {
                if (value.name == name)
                    return value;
            }
            return null;
        }

        private void getDepositsListFromXml(XmlDocument document)
        {
            List<DepositInfo> DepositsLst = new List<DepositInfo>();

            Dictionary<Currency, double> CurrencyPercent =
            new Dictionary<Currency, double>();

            Dictionary<Currency, double> startSum =
            new Dictionary<Currency, double>();

            var deposits = document.GetElementsByTagName(depositElemName);
            foreach (XmlNode deposit in deposits)
            {
                var creditAttr = deposit.Attributes;

                string name = creditAttr.GetNamedItem(nameAttrName).Value;
                int id = int.Parse(creditAttr.GetNamedItem(idAttrName).Value);
                int term = int.Parse(creditAttr.GetNamedItem(termAttrName).Value);

                Console.WriteLine(creditAttr.GetNamedItem(nameAttrName).Value);

                var currencyParametrs = deposit.FirstChild.ChildNodes;
                foreach (XmlNode currParam in currencyParametrs)
                {
                    var curr = currParam.Attributes.GetNamedItem(nameAttrName).Value;
                    Currency currency = getCurrencyByName(getCurrencyLstFromXml(document), curr);

                    Console.WriteLine(curr);
                    foreach (XmlNode param in currParam.ChildNodes)
                    {
                        if (param.Name == percentElemName)
                        {
                            CurrencyPercent.Add(currency, double.Parse(param.InnerText));

                        }
                        if (param.Name == startSumElemName)
                        {
                            startSum.Add(currency, double.Parse(param.InnerText));
                        }
                    }

                }

                DepositsLst.Add(new DepositInfo(id, name, term, CurrencyPercent, startSum));

            }
        }

        private void getCreditsListFromXml(XmlDocument document)
        {
            List<CreditInfo> CreditsLst = new List<CreditInfo>();

            Dictionary<Currency, double> CurrencyPercent =
            new Dictionary<Currency, double>();

            Dictionary<Currency, double> StartSum =
            new Dictionary<Currency, double>();

            Dictionary<Currency, double> MaxSum =
            new Dictionary<Currency, double>();

            var credits = document.GetElementsByTagName(creditElemName);
            foreach(XmlNode credit in credits)
            {
                var creditAttr = credit.Attributes;

                string name = creditAttr.GetNamedItem(nameAttrName).Value;
                int id = int.Parse(creditAttr.GetNamedItem(idAttrName).Value);
                int term = int.Parse(creditAttr.GetNamedItem(termAttrName).Value);

                Console.WriteLine(creditAttr.GetNamedItem(nameAttrName).Value);

                var currencyParametrs = credit.FirstChild.ChildNodes;
                foreach(XmlNode currParam in currencyParametrs)
                {
                    var curr = currParam.Attributes.GetNamedItem(nameAttrName).Value;
                    Currency currency = getCurrencyByName(getCurrencyLstFromXml(document), curr);

                    Console.WriteLine(curr);
                    foreach (XmlNode param in currParam.ChildNodes)
                    {
                        if (param.Name == percentElemName)
                        {
                            CurrencyPercent.Add(currency, double.Parse(param.InnerText));
                            
                        }
                        if (param.Name == startSumElemName)
                        {
                            StartSum.Add(currency, double.Parse(param.InnerText));
                        }
                        if (param.Name == maxSumElemName)
                        {
                           MaxSum.Add(currency, double.Parse(param.InnerText));
                        }
                    }

                }

                CreditsLst.Add(new CreditInfo(id, name, term, CurrencyPercent, StartSum, MaxSum));
                
            }
        }

        public List<Client> getClientsListFromXml(XmlDocument document)
        {
            List<Client> ClientLst = new List<Client>();
            var clients = document.GetElementsByTagName(clientElemName);
            foreach(XmlNode client in clients)
            {
                var clientAttr = client.Attributes;

                ClientLst.Add(new Client(clientAttr.GetNamedItem(firstNameAttrName).Value, 
                    clientAttr.GetNamedItem(lastNameAttrName).Value, 
                    int.Parse(clientAttr.GetNamedItem(ITNAttrName).Value),
                    clientAttr.GetNamedItem(phoneAttrName).Value));
            }

            return ClientLst;
        }

    }
}
