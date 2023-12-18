﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product{ProductId = 1, CategoryId = 1, Name="Iced Tea", Quantity =100, Price=1.99 },
                new Product{ProductId = 1, CategoryId = 1, Name="Canada Dry", Quantity =200, Price=2.99 },
                new Product{ProductId = 3, CategoryId = 3, Name="Steak", Quantity =100, Price=10.99 },
                new Product{ProductId = 2, CategoryId = 2, Name="White Bread", Quantity =300, Price=0.99 },
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            products.Add(product);

        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        public void UpdateProduct(Product product)
        {
            var productToUpdate  = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
            }
        }
        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(x => x.ProductId == productId);
        }
    }
}
