using Cake_palace.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cake_palace.Data
{
    public class Cake_palaceContext : DbContext
    {
        public Cake_palaceContext()
        {
        }

        public Cake_palaceContext(DbContextOptions<Cake_palaceContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(c => c.CartId);

            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(r => r.CategoryName).IsRequired();
                entity.Property(r => r.ImageUrl).IsRequired();

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(c => c.OrderId);

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(c => c.ProductId);
                entity.Property(r => r.ProductName).IsRequired();
                entity.Property(r => r.ProductDescription).IsRequired();
                entity.Property(r => r.ImageUrl).IsRequired();
                entity.Property(r => r.ProductPrice).IsRequired();
                entity.Property(r => r.ProductQuantity).IsRequired();

                entity.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(c => c.UserId);
                entity.Property(r => r.Name).IsRequired();
                entity.Property(r => r.Role).IsRequired();
                entity.Property(r => r.Password).IsRequired();
                entity.Property(r => r.Email).IsRequired();
                entity.Property(r => r.Address).IsRequired();
                entity.Property(r => r.MobileNo).IsRequired();
                entity.Property(r => r.PostelCode).IsRequired();

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
