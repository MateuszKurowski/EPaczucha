﻿using Microsoft.AspNetCore.Mvc;

namespace EPaczucha.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }
    }
}