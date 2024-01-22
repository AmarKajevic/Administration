using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class MarketContext: DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {

            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //seeding some data

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Krema", Description = "Kreme" }
                
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "BioBalance krema", Quantity = 10000,Points =20,
                     Price = 15 },
                new Product { ProductId = 2, CategoryId = 1, Name = "BioBalance krema 1+1", Quantity = 10000, Points = 30,
                    
                    Price = 25.5 }
             
                );
                    
        }
    }
}
