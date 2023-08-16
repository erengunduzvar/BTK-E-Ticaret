using Entities.Models;
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
        Product? GetProductById(int id, bool trackChanges);

        void CreateProduct(Product product);
        void UpdateOneProduct(Product product);
    }
}
