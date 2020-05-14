using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Lib
{
    public class Credit
    {
        public int creditId { get; }
        public int clientId { get; }

        public double sum { get; }

        public double startSum { get; }

        public Currency currency { get; }

        public DateTime startDate { get; }
        public DateTime endDate { get; }

        public Credit(CreditInfo credit, Client client, double requstSum,
            double advance, Currency currency, DateTime start)
        {
            creditId = credit.id;
            clientId = client.id;

            if (credit.CurrencyPercent.ContainsKey(currency))
                this.currency = currency;
            else
                throw new BankException("invalid currency");


            if (requstSum <= credit.MaxSum[currency])
                sum = requstSum;
            else
                throw new BankException("you go over limit of credit");


            if (advance >= credit.StartSum[currency])
                startSum = advance;
            else
                throw new BankException("Too small advance");



            if (start < DateTime.Now)
                throw new BankException("Incorrect start date");
            else
                endDate = start.AddMonths(credit.term);


        }
    }
}
