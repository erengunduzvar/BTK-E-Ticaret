using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ProductName = "Laptop", Price = 15000 },
                new Product() { ProductId = 2, CategoryId = 2, ProductName = "Computer", Price = 15000 },
                new Product() { ProductId = 3, CategoryId = 2, ProductName = "Mouse", Price = 698 },
                new Product() { ProductId = 4, CategoryId = 2, ProductName = "Monitor", Price = 3544 },
                new Product() { ProductId = 5, CategoryId = 2, ProductName = "Keyboard", Price = 6200 },
                new Product() { ProductId = 6, CategoryId = 1, ProductName = "Matematik", Price = 6200 },
                new Product() { ProductId = 7, CategoryId = 1, ProductName = "Türkçe", Price = 6200 }
                );
        }
    }
}
