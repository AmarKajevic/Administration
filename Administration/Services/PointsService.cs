using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Administration.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL;
using UseCases;

namespace Administration.Services
{
    public class PointsService 
    {
        
     private readonly AccountContext _accountContext;
    private readonly MarketContext _marketContext;

    public PointsService(AccountContext accountContext, MarketContext marketContext)
    {
        _accountContext = accountContext;
        _marketContext = marketContext;
    }
     public async Task OnTransactionCreated(TransactionCreatedEvent e)
    {
        await UpdateRecommenderPoints(e.RecommenderId, e.PointsToAdd);
    }

    public async Task UpdateRecommenderPoints(string recommenderId, int pointsToAdd)
    {
       var recommender = await _accountContext.Users.FindAsync(recommenderId);
       

    if (recommender != null)
    {
        // Find transactions for the recommender
        var transactions = await _marketContext.Transactions
            .Where(t => t.UserId == recommenderId)
            .ToListAsync();

        // Update points for each transaction
        foreach (var transaction in transactions)
        {
            transaction.PersonalPoints += pointsToAdd;
            _accountContext.Users.Update(recommender);
            _marketContext.Transactions.Update(transaction);
        }

        // Save changes to the market context
        await _marketContext.SaveChangesAsync();

        // Update points for the recommender
        recommender.Points += pointsToAdd;
        _accountContext.Users.Update(recommender);
        await _accountContext.SaveChangesAsync();
    }
    }
    public async Task AddPointsAfterTransaction(string userId, int pointsToAdd)
    {
        var user = await _accountContext.Users.FindAsync(userId);
        if (user != null)
        {
            user.Points += pointsToAdd;
            _accountContext.Users.Update(user);
            await _accountContext.SaveChangesAsync();
        }
    }
    public async Task RemovePointsAfterTransaction(string userId, int pointsToRemove)
{
    var user = await _accountContext.Users.FindAsync(userId);
    if (user != null)
    {
        user.Points -= pointsToRemove;
         if (user.Points < 0)
        {
            user.Points = 0;
        }
        _accountContext.Users.Update(user);
        await _accountContext.SaveChangesAsync();
    }
}
    
    
  }
}