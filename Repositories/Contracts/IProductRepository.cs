using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void DeleteOneProduct(Product product);
        IQueryable<Product> GetAllProducts(bool trackChanges);

        Product? GetById(int id, bool trackChanges);
    }
}
