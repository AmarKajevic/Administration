using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                return _db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
            {
                return _db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.TimeStamp.Date == date.Date);
            }
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int Soldqty,int points, int PersonalPoints, int GeneralPoints)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = Soldqty,
                Points = points,
                PersonalPoints = PersonalPoints,
                GeneralPoints = GeneralPoints,
                CashierName = cashierName
            };

            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startdate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
                return _db.Transactions.Where(x => x.TimeStamp >= startdate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
            {
                return _db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName,$"%{cashierName}%") &&
               x.TimeStamp >= startdate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            }
        }
    }
}
