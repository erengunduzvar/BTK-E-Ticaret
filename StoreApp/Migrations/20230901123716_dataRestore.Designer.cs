﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace StoreApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230901123716_dataRestore")]
    partial class dataRestore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entities.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Kitap"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Elektronik"
                        });
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("GiftWrap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Line2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Line3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Shipped")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ShowCase")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            ImageUrl = "/images/1.jpg",
                            Price = 15000m,
                            ProductName = "Laptop",
                            ShowCase = false,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ImageUrl = "/images/2.jpg",
                            Price = 15000m,
                            ProductName = "Computer",
                            ShowCase = false,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            ImageUrl = "/images/3.jpg",
                            Price = 698m,
                            ProductName = "Mouse",
                            ShowCase = false,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            ImageUrl = "/images/4.jpg",
                            Price = 3544m,
                            ProductName = "Monitor",
                            ShowCase = false,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            ImageUrl = "/images/5.jpg",
                            Price = 6200m,
                            ProductName = "Keyboard",
                            ShowCase = false,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            ImageUrl = "/images/6.jpg",
                            Price = 6200m,
                            ProductName = "Matematik",
                            ShowCase = false,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            ImageUrl = "/images/7.jpg",
                            Price = 6200m,
                            ProductName = "Türkçe",
                            ShowCase = false,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 2,
                            ImageUrl = "/images/8.jpg",
                            Price = 6985m,
                            ProductName = "XP-Pen",
                            ShowCase = true,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            ImageUrl = "/images/9.jpg",
                            Price = 5m,
                            ProductName = "İnsan Ne İle Yaşar",
                            ShowCase = true,
                            Summary = ""
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 2,
                            ImageUrl = "/images/10.jpg",
                            Price = 957m,
                            ProductName = "Samsung Galaxy 3",
                            ShowCase = true,
                            Summary = ""
                        });
                });

            modelBuilder.Entity("Entities.Models.CartLine", b =>
                {
                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("Lines")
                        .HasForeignKey("OrderId");

                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}