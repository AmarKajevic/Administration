using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases
{
    public class TransactionCreatedEventArgs : EventArgs
    {
        public Transaction Transaction { get; set; }
        
    }
}