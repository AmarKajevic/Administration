﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {

        private List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if(string.IsNullOrEmpty(cashierName))
            return transactions;
            else
            {
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
            {
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) && 
                x.TimeStamp.Date == date.Date);
            }
            
        }

        public void Save(string cashierName, int productId, string productName, double price,int beforeQty, int soldQty,int points, int personalPoints, int generalPoints)
        {
            int transactionId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                int maxId = transactions.Max(x => x.TransactionId);
            }
            else
            {
                transactionId = 1;
            }

            
            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                ProductName = productName,
                Price = price,
                TimeStamp = DateTime.Now,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                PersonalPoints = personalPoints,
                GeneralPoints = generalPoints,
                Points = points,
                CashierName = cashierName
                

            });
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startdate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
                return transactions.Where(x => x.TimeStamp >= startdate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
            {
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
               x.TimeStamp >= startdate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            }

        }
    }
}
