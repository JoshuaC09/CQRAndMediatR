using Microsoft.AspNetCore.Mvc;

namespace CrqsMediatrExample
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product {Id =1, Name = "Test Product 1"},
                new Product {Id =1, Name = "Test Product 2"},
                new Product {Id =1, Name = "Test Product 3"},
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

        public async Task<Product> GetProductById(int id)
        {
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updatedProduct = new Product { Id = product.Id, Name = product.Name };

            return await Task.FromResult(updatedProduct);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product =  _products.FirstOrDefault(p => p.Id == id);

            if (product != null) { 
              _products.Remove(product);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}