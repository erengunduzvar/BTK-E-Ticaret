using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;

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

        public IActionResult Index(ProductRequestParameters p)
        {
            var products = serviceManager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = serviceManager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel()
            {
                Pagination = pagination,
                Products = products
            });
        }

        public IActionResult Get(int id)
        {
            var model = serviceManager.ProductService.GetProductById(id, false);
            return View(model);
        }


    }
}
