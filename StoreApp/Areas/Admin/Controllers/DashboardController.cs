﻿using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {[Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
