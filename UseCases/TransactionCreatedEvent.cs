using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases
{
    public class TransactionCreatedEvent
    {
         public string? RecommenderId { get; set; }
        public int PointsToAdd { get; set; }
    }
}