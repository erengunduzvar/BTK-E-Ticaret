using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //Dependency Injection
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.Product.GetAllProducts(false).ToList();
            return View(model);
        }

        public IActionResult Get(int id)
        {
            //Product product = _context.Products.First(x => x.ProductId == id);
            //return View(product);
            throw new NotImplementedException();
        }


    }
}
