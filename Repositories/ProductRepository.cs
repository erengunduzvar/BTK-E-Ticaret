﻿using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void DeleteOneProduct(Product product) => Remove(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _context
                    .Products
                    .FilteredByCategoryId(p.CategoryId)
                    .FilteredBySearchTerm(p.SearchTerm)
                    .FilteredByPrice(p.MinPrice,p.MaxPrice,p.IsValidPrice)
                    .ToPaginate(p.PageNumber,p.PageSize);

        }

        public Product? GetById(int id, bool trackChanges)
        {
            return FindByCondution(p => p.ProductId.Equals(id),trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }
    }
}
