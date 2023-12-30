using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string cashierName);
        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
        public IEnumerable<Transaction> Search(string cashierName, DateTime startdate, DateTime dateTime);
        public void DeleteTransaction(int transactionId);
        public void Save(string cashierName,int productId,string productName,
            double price,int beforeQty, int soldqty,int points,
            int PersonalPoints, int GeneralPoints, string address, string city,
            string firstName, string lastName, string postalCode, string phone);
    }
}
