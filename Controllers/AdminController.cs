using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DuncanSafeApp2024.DataStore;

namespace DuncanSafeApp2024.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ResetDb()
        {
            Table.Initialize();
            return RedirectToAction("Index", "ProductList");
        }
    }
}