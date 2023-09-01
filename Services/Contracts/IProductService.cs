using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        Product? GetProductById(int id, bool trackChanges);
        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
        void CreateProduct(ProductDtoForInsertion product);
        void UpdateOneProduct(ProductDtoForUpdate product);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}
