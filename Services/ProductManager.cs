using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        IRepositoryManager repositoryManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            repositoryManager.Product.Create(product);
            repositoryManager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product? product = GetProductById(id, false);
            if (product is not null)
            {
                repositoryManager.Product.DeleteOneProduct(product);
                repositoryManager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return repositoryManager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetProductById(int id, bool trackChanges)
        {
            var product = repositoryManager.Product.GetById(id, trackChanges);
            if (product is null)
                throw new Exception("Product is not found");
            return product;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            Product entity = _mapper.Map<Product>(productDto);
            repositoryManager.Product.Update(entity);
            repositoryManager.Save();
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetProductById(id, trackChanges);
            ProductDtoForUpdate productDto = _mapper.Map<ProductDtoForUpdate>(product);

            return productDto;
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
        {
            var products = repositoryManager.Product.GetShowcaseProducts(trackChanges);
            return products;
        }

        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return repositoryManager.Product.GetAllProductsWithDetails(p);
        }

        public IEnumerable<Product> GetLatestProducts(int n, bool trackChanges)
        {
            return repositoryManager
                .Product
                .FindAll(trackChanges)
                .OrderByDescending(prd => prd.ProductId)
                .Take(n);
        }
    }
}
