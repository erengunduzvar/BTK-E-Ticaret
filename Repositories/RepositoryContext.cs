﻿using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using System.Reflection;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Orders { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}