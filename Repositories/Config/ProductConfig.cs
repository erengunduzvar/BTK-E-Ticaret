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
                new Product() { ProductId = 1, CategoryId = 2, ImageUrl=  "/images/1.jpg", ProductName = "Laptop", Price = 15000, ShowCase=false},
                new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/images/2.jpg", ProductName = "Computer", Price = 15000, ShowCase = false },
                new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/images/3.jpg", ProductName = "Mouse", Price = 698, ShowCase = false },
                new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/images/4.jpg", ProductName = "Monitor", Price = 3544, ShowCase = false },
                new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/images/5.jpg", ProductName = "Keyboard", Price = 6200 , ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/images/6.jpg", ProductName = "Matematik", Price = 6200, ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/images/7.jpg", ProductName = "Türkçe", Price = 6200, ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 1, ImageUrl = "/images/8.jpg", ProductName = "XP-Pen", Price = 6985, ShowCase = true },
                new Product() { ProductId = 9, CategoryId = 2, ImageUrl = "/images/9.jpg", ProductName= "İnsan Ne İle Yaşar", Price = 5, ShowCase = true },
                new Product() { ProductId = 10, CategoryId = 1, ImageUrl = "/images/10.jpg", ProductName = "Samsung Galaxy 3", Price = 957, ShowCase = true }
                );
        }
    }
}
