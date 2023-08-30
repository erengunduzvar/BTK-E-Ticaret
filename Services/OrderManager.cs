using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager manager;

        public OrderManager(IRepositoryManager repositoryManager)
        {
            manager = repositoryManager;
        }

        public IQueryable<Order> Orders => manager.Order.Orders;

        public int NumberOfInProcess => manager.Order.NumberOfInProcess;

        public void Complete(int id)
        {
            manager.Order.Complete(id);
            manager.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return manager.Order.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            manager.Order.SaveOrder(order);
            manager.Save();
        }
    }
}
