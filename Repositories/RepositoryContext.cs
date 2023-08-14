using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Product> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product() { ProductId = 1, ProductName = "Laptop", Price = 15000 },
                new Product() { ProductId = 2, ProductName = "Computer", Price = 15000 },
                new Product() { ProductId = 3, ProductName = "Mouse", Price = 698 },
                new Product() { ProductId = 4, ProductName = "Monitor", Price = 3544 },
                new Product() { ProductId = 5, ProductName = "Keyboard", Price = 6200 }
                );


            modelBuilder.Entity<Category>()
                .HasData(
                new Category() { CategoryId = 1, CategoryName = "Mobilya"},
                new Category() { CategoryId = 2, CategoryName = "Elektronik" }
                );
        }
    }
}