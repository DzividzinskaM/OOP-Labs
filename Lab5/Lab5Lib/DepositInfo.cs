﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Lib
{
    public class DepositInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public int term { get; set; }


        public readonly Dictionary<Currency, double> CurrencyPercent =
            new Dictionary<Currency, double>();

        public readonly Dictionary<Currency, double> startSum =
            new Dictionary<Currency, double>();

        public DepositInfo(int id, string name, int term,
            double start, double percent, Currency currency)
        {
            this.id = id;
            this.name = name;
            this.term = term;

            addCurrency(currency, percent, start);

        }

        public DepositInfo(int id, string name, int term,
            Dictionary<Currency, double> CurrencyPercent,
            Dictionary<Currency, double> startSum
            )
        {
            this.id = id;
            this.name = name;
            this.CurrencyPercent = CurrencyPercent;
            this.startSum = startSum;
        }
        public void addCurrency(Currency currency, double percent, double start)
        {
            if (percent < 100 || !CurrencyPercent.ContainsKey(currency))
            {
                CurrencyPercent.Add(currency, percent);
                startSum.Add(currency, start);
            }
            else
                throw new BankException($"For {currency} is already exist value");
        }
    }
}
