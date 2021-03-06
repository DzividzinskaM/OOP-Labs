﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Lib
{
    public class Deposit
    {
        public int clientId { get; }
        public int depositId { get; }
        public string accountNumber { get; }
        public double startSum { get; }

        public Currency currency { get; }

        public DateTime startDate { get; }

        public DateTime endDate { get; }

        public Deposit(Client client, DepositInfo deposit,
            string accountNumber, double sum, Currency currency, DateTime start)
        {
            clientId = client.id;
            depositId = deposit.id;

            this.accountNumber = accountNumber;

            if (deposit.CurrencyPercent.ContainsKey(currency))
                this.currency = currency;
            else
                throw new BankException("invalid currency");


            if (sum >= deposit.startSum[currency])
                startSum = sum;
            else
                throw new BankException("Not enough");


            if (start < DateTime.Now)
                throw new BankException("Incorrect start date");
            else
            {
                startDate = start;
                endDate = start.AddMonths(deposit.term);
            }

        }

        public Deposit(int clientId, int depositId,
            string accountNumber, double sum, Currency currency,
            DateTime start, DateTime end)
        {
            this.clientId = clientId;
            this.depositId = depositId;
            this.accountNumber = accountNumber;
            startSum = sum;
            this.currency = currency;
            startDate = start;
            endDate = end;
        }
    }
}
