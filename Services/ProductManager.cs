using AutoMapper;
using Entities.Dtos;
using Entities.Models;
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

        public ProductManager(IRepositoryManager repositoryManager,IMapper mapper)
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
            if(product is not null)
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

        public void UpdateOneProduct(Product product)
        {
            var entity = repositoryManager.Product.GetById(product.ProductId,true);
            entity.ProductName = product.ProductName;
            entity.Price = product.Price;
            repositoryManager.Save();
        }
    }
}
