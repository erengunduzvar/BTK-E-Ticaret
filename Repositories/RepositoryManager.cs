using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IProductRepository _productRepository;
        private readonly RepositoryContext _repositoryContext;

        public RepositoryManager(IProductRepository productRepository, RepositoryContext repositoryContext)
        {
            _productRepository = productRepository;
            _repositoryContext = repositoryContext;
        }

        public IProductRepository Product => _productRepository;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
