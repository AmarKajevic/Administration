﻿using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext _db; 
     

        public TransactionRepository( MarketContext db)
        {
            _db = db;
        }
        public IEnumerable<Transaction> Get(string cashierName)
        {
            return _db.Transactions.ToList();
        }
        


        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
             if (string.IsNullOrEmpty(cashierName))
            {
                return _db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            }
            else
            {
                
            

                return _db.Transactions.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                    x.TimeStamp.Date == date.Date);
            }
        }


       


        public void DeleteTransaction(int transactionId)
        {
            var transaction = _db.Transactions.Find(transactionId);
            if (transaction == null) return;
            _db.Transactions.Remove(transaction);
            _db.SaveChanges();
        }
        public Transaction GetTransactionById(int transactionId)
    {
          return _db.Transactions.Find(transactionId);
    }
         

        public void Save(string cashierName, int productId, string productName,
            double price, int beforeQty, int soldqty,int points, 
            int PersonalPoints, int GeneralPoints, string address, string city,
            string firstName, string lastName, string postalCode, string phone, string UserId)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldqty,
                Points = points,
                Address = address,
                City= city,
                FirstName= firstName,
                LastName= lastName,
                PostalCode= postalCode, 
                Phone= phone,
                PersonalPoints = PersonalPoints,
                GeneralPoints = GeneralPoints,
                CashierName = cashierName,
                UserId = UserId
                
            };

            _db.Transactions.Add(transaction);
            _db.SaveChanges();
          
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startdate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return _db.Transactions;
            }
            else
            {
                return _db.Transactions
                    .Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%"));
            }
        }
    }
}
    
