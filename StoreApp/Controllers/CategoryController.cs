﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
           var model = _serviceManager.CategoryService.GetAllCategories(false).ToList();
           return View(model);
        }
    }
}
