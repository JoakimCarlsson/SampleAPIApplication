using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApplication.Models;

namespace SampleApplication
{
    public class InMemoryDataStore
    {
        private static List<Models.Product> _products;
        public InMemoryDataStore()
        {
            _products = new List<Models.Product>
            {
                new() { Id = 1, Name = "Test Product 1", Description = "Big thing"},
                new() { Id = 2, Name = "Test Product 2", Description = "Small thing" },
                new() { Id = 3, Name = "Test Product 3", Description = "Medium thing." }
            };
        }
        public async Task<Product> AddProduct(Models.Product product)
        {
            _products.Add(product);
            return product;
        }
        public async Task<IEnumerable<Models.Product>> GetAllProducts() => await Task.FromResult(_products);
        public async Task<Models.Product> GetProductById(int id) => await Task.FromResult(_products.First(i => i.Id == id));

    }
}
