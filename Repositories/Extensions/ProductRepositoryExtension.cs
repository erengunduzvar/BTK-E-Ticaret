﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,
            int? categoryId)
        {
            if(categoryId is null)
                return products;
            else
                return products.Where(prd => prd.CategoryId == categoryId);
        }

        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,
            String? searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return products;
            else
                return products.Where(prd => prd.ProductName.ToLower()
                .Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,
            int minPrice, int maxPrice, bool isValidPrice)
        {
            if(isValidPrice)
                return products.Where(prd => prd.Price >= minPrice && prd.Price <= maxPrice);
            else
                return products;
        }

        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products,
            int pageNumber, int PageSize)
        {
            return products
                .Skip(((pageNumber - 1) * PageSize))
                .Take(PageSize);

        }
    }
}
