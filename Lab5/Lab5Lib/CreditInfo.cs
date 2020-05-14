using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Lib
{
    public class CreditInfo
    {
        public int id { get; }
        public string name { get; }
        public int term { get; }

        public readonly Dictionary<Currency, double> CurrencyPercent =
            new Dictionary<Currency, double>();

        public readonly Dictionary<Currency, double> StartSum =
            new Dictionary<Currency, double>();

        public readonly Dictionary<Currency, double> MaxSum =
            new Dictionary<Currency, double>();

        public CreditInfo(int id, string name, int term, double minAdvance,
            double maxSum, double percent, Currency currency)
        {
            this.id = id;
            this.name = name;
            this.term = term;


            addCurrency(currency, percent, minAdvance, maxSum);
        }


        public void addCurrency(Currency currency, double percent, double startAdvance,
            double max)
        {
            if (percent < 100 || !CurrencyPercent.ContainsKey(currency))
            {
                CurrencyPercent.Add(currency, percent);
                StartSum.Add(currency, startAdvance);
                MaxSum.Add(currency, max);
            }
            else
                throw new BankException($"For {currency} is already exist value");
        }
    }
}
