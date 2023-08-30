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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;

        public RepositoryManager(IProductRepository productRepository, RepositoryContext repositoryContext,ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _repositoryContext = repositoryContext;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order => _orderRepository;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
