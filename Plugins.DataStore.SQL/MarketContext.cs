﻿using CoreBusiness;
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
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100,Points =20, Price = 1.99 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Points = 30, Price = 2.99 },
                new Product { ProductId = 3, CategoryId = 3, Name = "Steak", Quantity = 100, Points = 30, Price = 10.99 },
                new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Points = 20, Price = 0.99 }
                );
                    
        }
    }
}
