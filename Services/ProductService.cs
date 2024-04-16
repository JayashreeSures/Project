using Microsoft.EntityFrameworkCore;
using Cake_palace.Exceptions;
using Cake_palace.models;
using Cake_palace.Repository;

namespace Cake_palace.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _repository.AddProduct(product);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var pr = await _repository.DeleteProduct(id);
            if(pr == null)
            {
                throw new ProductNotFoundException("Product with this id not found");
            }
            return pr;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _repository.GetProduct(id);
            if (product == null)
            {
                throw new ProductNotFoundException("Product not found with this id");
            }
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _repository.GetProducts();
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            var products = await _repository.GetProductsByCategory(categoryId);
            if (products == null)
            {
                throw new CategoryNotFoundException("Category not found with this id");
            }
            return products;
        }

        public async Task<List<Product>> SearchProductsByName(string name)
        {
            var products = await _repository.SearchProductsByName(name);
            if (products == null)
            {
                throw new ProductNotFoundException("No products with this name");
            }
            return products;
        }

        public async Task<Product> UpdateProduct(int id,Product product)
        {
            var pr = await _repository.UpdateProduct(id,product);
            if (pr == null)
            {
                throw new ProductNotFoundException($"Product With Product Id : {id} not found.");
            }
            return pr;
        }
    }
}
