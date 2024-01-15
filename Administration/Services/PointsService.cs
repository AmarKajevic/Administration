using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Administration.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Plugins.DataStore.SQL;

namespace Administration.Services
{
    public class PointsService 
    {
        
//      private readonly AccountContext _accountContext;
//     private readonly MarketContext _marketContext;

//     public PointsService(AccountContext accountContext, MarketContext marketContext)
//     {
//         _accountContext = accountContext;
//         _marketContext = marketContext;
//     }

//     public async Task UpdateRecommenderPoints(string recommenderId, int pointsToAdd)
//     {
//         var recommender = await _accountContext.Users.FindAsync(recommenderId);
//         if (recommender != null)
//         {
//             // Pretpostavimo da je Transaction tabela koja sadrži bodove
//             var transaction = await _marketContext.Transactions
//                 .Where(t => t.UserId == recommenderId)
//                 .FirstOrDefaultAsync();

//             if (transaction != null)
//             {
//                 transaction.Points += pointsToAdd;
//                 _marketContext.Transactions.Update(transaction);
//                 await _marketContext.SaveChangesAsync();
//             }
//         }
//     }
  }
}