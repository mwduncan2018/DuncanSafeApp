using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DuncanSafeApp2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SafeAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            return RedirectToAction("Index", "ProductList");
        }

        public IActionResult Contact()
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            return View();
        }

        public IActionResult Privacy()
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}