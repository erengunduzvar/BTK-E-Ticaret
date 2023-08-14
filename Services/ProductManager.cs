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

        public ProductManager(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
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
    }
}
