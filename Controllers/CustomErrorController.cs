using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DuncanSafeApp2024.Controllers
{
    public class CustomErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}