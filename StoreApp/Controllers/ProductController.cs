using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //Dependency Injection
        IServiceManager serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var model = serviceManager.ProductService.GetAllProducts(false).ToList();
            return View(model);
        }

        public IActionResult Get(int id)
        {
            var model = serviceManager.ProductService.GetProductById(id, false);
            return View(model);
        }


    }
}
