using Microsoft.EntityFrameworkCore;
using Cake_palace.Data;
using Cake_palace.models;

namespace Cake_palace.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Cake_palaceContext _context;
        public ProductRepository(Cake_palaceContext context) 
        {
            _context = context;
        }


        public async Task<List<Product>> GetProducts()
        {
            return  await _context.Products.ToListAsync();
        }

        public async  Task<List<Product>> SearchProductsByName(string name)
        {
            return await _context.Products.Where(p => p.ProductName.Contains(name)).ToListAsync();
            
        }

        public async Task<List<Product>>  GetProductsByCategory(int categoryId) 
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
            
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(int id,Product product)
        {
            var pr = await _context.Products.FindAsync(id);
            if(pr != null)
            {
                pr.ProductName = product.ProductName;
                pr.ProductDescription = product.ProductDescription;
                pr.ProductPrice = product.ProductPrice;
                pr.ProductQuantity = product.ProductQuantity;
                pr.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
            }
            return pr;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var pr = _context.Products.Find(productId);
            var cart = _context.Carts.Find(productId);
            if (pr != null)
            {
                if (cart != null)
                {
                     _context.Carts.Remove(cart);
                     _context.Products.Remove(pr);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    _context.Products.Remove(pr);
                    await _context.SaveChangesAsync();
                }
            }
            return pr;
        }
    }
}
