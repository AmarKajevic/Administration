using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int Points { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public int PersonalPoints { get; set; }
        public int GeneralPoints { get; set; }
        public int SoldQty { get; set; }
        public string CashierName { get; set; }
    }
}
