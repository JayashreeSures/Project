using Microsoft.AspNetCore.Mvc;
using Cake_palace.models;

namespace Cake_palace.Services
{
    public interface IProductService 
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsByCategory(int categoryId);
        Task<List<Product>> SearchProductsByName(string name);
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int id,Product product);
        Task<Product> DeleteProduct(int id);
    }
}
