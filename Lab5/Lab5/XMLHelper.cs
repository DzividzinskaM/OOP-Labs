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
        public readonly XmlDocument document;
        private string financialInfoElemName = "FinancialInfo";
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
        private string depositsElemName = "Deposits";
        private string depositElemName = "deposit";
        private string clientDepositsElemName = "ClientDeposits";
        private string clientDepositElemName = "clientDeposit";
        private string accountNumberAttrName = "accountNumber";
        private string clientsElemName = "Clients";
        private string depositIdAttrName = "depositId";
        private string clientIdAttrName = "clientId";
        private string dateParamElemName = "dateParameters";
        private string endDateAttrName = "endDate";
        private string startDateAttrName = "startDate";
        private string clientCreditsElemName = "ClientCredits";
        private string clientCreditElemName = "clientCredit";
        private string creditsElemName = "Credits";
        private string sumAttrName = "sum";
        private string creditIdAttrName = "creditId";
        private string BankElemName = "Bank";
        private string adrressAttrName = "adrress";

        public XMLHelper(string name)
        {
            fileName = name;
            document = new XmlDocument();
            document.Load(fileName);
        }
        public void WriteInfoToXml(Bank bank, List<Currency> currencies)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartElement(financialInfoElemName);

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

                writer.WriteStartElement(BankElemName);

                writer.WriteAttributeString(nameAttrName, bank.name);
                writer.WriteAttributeString(adrressAttrName, bank.address);
                writer.WriteAttributeString(phoneAttrName, bank.phone);


                writer.WriteStartElement(clientsElemName);
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


                writer.WriteStartElement(depositsElemName);
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


                writer.WriteStartElement(creditsElemName);
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

                writer.WriteStartElement(clientDepositsElemName);

                foreach (var deposit in bank.ClientDeposit)
                {
                    writer.WriteStartElement(clientDepositElemName);
                    writer.WriteAttributeString(clientIdAttrName, deposit.clientId.ToString());
                    writer.WriteAttributeString(depositIdAttrName, deposit.depositId.ToString());
                    writer.WriteAttributeString(accountNumberAttrName, deposit.accountNumber);
                    writer.WriteAttributeString(startSumElemName, deposit.startSum.ToString());
                    writer.WriteStartElement(currencyElemName);
                    writer.WriteElementString(nameAttrName, deposit.currency.name);
                    writer.WriteEndElement(); //currency
                    writer.WriteStartElement(dateParamElemName);
                    writer.WriteAttributeString(startDateAttrName, deposit.startDate.ToString());
                    writer.WriteAttributeString(endDateAttrName, deposit.endDate.ToString());
                    writer.WriteEndElement(); //date
                    writer.WriteEndElement(); //clientDeposit
                }

                writer.WriteEndElement();  //ClientDeposits

                writer.WriteStartElement(clientCreditsElemName);

                foreach (var credit in bank.ClientCredit)
                {
                    writer.WriteStartElement(clientCreditElemName);
                    writer.WriteAttributeString(clientIdAttrName, credit.clientId.ToString());
                    writer.WriteAttributeString(creditIdAttrName, credit.creditId.ToString());
                    writer.WriteAttributeString(sumAttrName, credit.sum.ToString());
                    writer.WriteAttributeString(startSumElemName, credit.startSum.ToString());

                    writer.WriteStartElement(currencyElemName);
                    writer.WriteElementString(nameAttrName, credit.currency.name);
                    writer.WriteEndElement(); //currency

                    writer.WriteStartElement(dateParamElemName);
                    writer.WriteAttributeString(startDateAttrName, credit.startDate.ToString());
                    writer.WriteAttributeString(endDateAttrName, credit.endDate.ToString());
                    writer.WriteEndElement(); //date
                    writer.WriteEndElement(); //clientCredit
                }

                writer.WriteEndElement(); //ClientCredits;

                writer.WriteEndElement(); //Bank

                writer.WriteEndElement();

            }
        }

        public void getInfoFromXml(ref Bank bank, List<Currency> currencies)
        {

            var clients = document.GetElementsByTagName("client");
            getInfoAboutBank(ref bank);
            getCurrencyLstFromXml();
            bank.Clients = getClientsListFromXml();
            bank.credits = getCreditsListFromXml(); 
            bank.deposits = getDepositsListFromXml();
            bank.ClientDeposit = getClientDepositFromXml();
            bank.ClientCredit = getClientCreditFromXml();

        }

        private void getInfoAboutBank(ref Bank bankResult)
        {
            var banks = document.GetElementsByTagName(BankElemName);
            foreach(XmlNode bank in banks)
            {
                var bankAttr = bank.Attributes;
                bankResult.name = bankAttr.GetNamedItem(nameAttrName).Value;
                bankResult.phone = bankAttr.GetNamedItem(phoneAttrName).Value;
                bankResult.address = bankAttr.GetNamedItem(adrressAttrName).Value;

            }
        }

        private List<Currency> getCurrencyLstFromXml()
        {
            List<Currency> currenciesLst = new List<Currency>();
            var currencies = document.GetElementsByTagName(currenciesElemName)[0].ChildNodes;
            foreach (XmlNode currency in currencies)
            {
                string name = "";
                double buying = 0;
                double selling = 0;
                foreach (XmlNode currencyParam in currency.ChildNodes)
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
            foreach (var value in currencies)
            {
                if (value.name == name)
                    return value;
            }
            return null;
        }

        private List<DepositInfo> getDepositsListFromXml()
        {
            List<DepositInfo> DepositsLst = new List<DepositInfo>();

            Dictionary<Currency, double> CurrencyPercent;

            Dictionary<Currency, double> startSum;

            var deposits = document.GetElementsByTagName(depositElemName);
            foreach (XmlNode deposit in deposits)
            {
                CurrencyPercent = new Dictionary<Currency, double>();
                startSum = new Dictionary<Currency, double>();
                var creditAttr = deposit.Attributes;

                string name = creditAttr.GetNamedItem(nameAttrName).Value;
                int id = int.Parse(creditAttr.GetNamedItem(idAttrName).Value);
                int term = int.Parse(creditAttr.GetNamedItem(termAttrName).Value);


                var currencyParametrs = deposit.FirstChild.ChildNodes;
                foreach (XmlNode currParam in currencyParametrs)
                {
                    var curr = currParam.Attributes.GetNamedItem(nameAttrName).Value;
                    Currency currency = getCurrencyByName(getCurrencyLstFromXml(), curr);

                    
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

            return DepositsLst;
        }

        private List<CreditInfo> getCreditsListFromXml()
        {
            List<CreditInfo> CreditsLst = new List<CreditInfo>();

            Dictionary<Currency, double> CurrencyPercent;

            Dictionary<Currency, double> StartSum;

            Dictionary<Currency, double> MaxSum;

            var credits = document.GetElementsByTagName(creditElemName);
            foreach (XmlNode credit in credits)
            {
                CurrencyPercent = new Dictionary<Currency, double>();
                StartSum = new Dictionary<Currency, double>();
                MaxSum = new Dictionary<Currency, double>();
                var creditAttr = credit.Attributes;

                string name = creditAttr.GetNamedItem(nameAttrName).Value;
                int id = int.Parse(creditAttr.GetNamedItem(idAttrName).Value);
                int term = int.Parse(creditAttr.GetNamedItem(termAttrName).Value);

                var currencyParametrs = credit.FirstChild;

                
                foreach (XmlNode currParam in currencyParametrs.ChildNodes)
                {
                    
                    var curr = currParam.Attributes.GetNamedItem(nameAttrName).Value;
                    Currency currency = getCurrencyByName(getCurrencyLstFromXml(), curr);
               
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
           
            return CreditsLst;
        }

        public List<Client> getClientsListFromXml()
        {
            List<Client> ClientLst = new List<Client>();
            var clients = document.GetElementsByTagName(clientElemName);
            foreach (XmlNode client in clients)
            {
                var clientAttr = client.Attributes;

                ClientLst.Add(new Client(clientAttr.GetNamedItem(firstNameAttrName).Value,
                    clientAttr.GetNamedItem(lastNameAttrName).Value,
                    int.Parse(clientAttr.GetNamedItem(ITNAttrName).Value),
                    clientAttr.GetNamedItem(phoneAttrName).Value));
            }

            return ClientLst;
        }

        private List<Credit> getClientCreditFromXml()
        {
            List<Credit> ClientCreditsLst = new List<Credit>();
            var credits = document.GetElementsByTagName(clientCreditElemName);

            foreach (XmlNode credit in credits)
            {
                var creditAttr = credit.Attributes;
                int clientId = int.Parse(creditAttr.GetNamedItem(clientIdAttrName).Value);
                int creditId = int.Parse(creditAttr.GetNamedItem(creditIdAttrName).Value);
                double startSum = double.Parse(creditAttr.GetNamedItem(startSumElemName).Value);
                double sum = double.Parse(creditAttr.GetNamedItem(sumAttrName).Value);
                Currency currency = null;
                DateTime startDate = new DateTime();
                DateTime endDate = new DateTime();
                foreach (XmlNode creditParam in credit.ChildNodes)
                {
                    if (creditParam.Name == currencyElemName)
                    {
                        currency = getCurrencyByName(getCurrencyLstFromXml(), creditParam.InnerText);

                    }
                    if (creditParam.Name == dateParamElemName)
                    {
                        startDate = Convert.ToDateTime(creditParam.Attributes
                          .GetNamedItem(startDateAttrName).Value);
                        endDate = Convert.ToDateTime(creditParam.Attributes
                          .GetNamedItem(endDateAttrName).Value);
                    }
                }
                ClientCreditsLst.Add(new Credit(creditId, clientId, sum, startSum, currency, startDate, endDate));
            }
            return ClientCreditsLst;
        }

        private List<Deposit> getClientDepositFromXml()
        {
            List<Deposit> ClientDepositLst = new List<Deposit>();
            var deposits = document.GetElementsByTagName(clientDepositElemName);

            foreach(XmlNode deposit in deposits)
            {
                var depositAttr = deposit.Attributes;
                int clientId = int.Parse(depositAttr.GetNamedItem(clientIdAttrName).Value);
                int depositId = int.Parse(depositAttr.GetNamedItem(depositIdAttrName).Value);
                string accountNumber = depositAttr.GetNamedItem(accountNumberAttrName).Value;
                double startSum = double.Parse(depositAttr.GetNamedItem(startSumElemName).Value);
                Currency currency = null;
                DateTime startDate = new DateTime();
                DateTime endDate = new DateTime();
                foreach(XmlNode depositParam in deposit.ChildNodes)
                {
                    if (depositParam.Name == currencyElemName)
                    {
                        currency = getCurrencyByName(getCurrencyLstFromXml(), depositParam.InnerText);
                    }
                    if(depositParam.Name == dateParamElemName)
                    {
                        startDate = Convert.ToDateTime(depositParam.Attributes
                            .GetNamedItem(startDateAttrName).Value);
                        endDate = Convert.ToDateTime(depositParam.Attributes
                          .GetNamedItem(endDateAttrName).Value);
                    }
                }
                ClientDepositLst.Add(new Deposit(clientId, depositId, accountNumber, startSum, currency, startDate, endDate));
            }
            return ClientDepositLst;
        }


    }
}
