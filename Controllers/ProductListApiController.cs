using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DuncanSafeApp2024.DataStore;
using DuncanSafeApp2024.ViewModels;
using System.Reflection.Emit;

namespace DuncanSafeApp2024.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ProductListApiController : ControllerBase
    {
        // GET: ProductListApi/Get
        [HttpGet("Get")]
        public ActionResult Get()
        {
            IList<FuzzyViewModel> viewModelList = new List<FuzzyViewModel>();
            foreach (var product in Table.Products)
            {
                FuzzyViewModel fuzzyViewModel = new FuzzyViewModel
                {
                    Id = product.Id,
                    Manufacturer = product.Manufacturer,
                    Model = product.Model,
                    NumberInStock = product.NumberInStock,
                    Price = product.Price,
                };
                // If both Manufacturer and Model match, the product is on the watch list
                fuzzyViewModel.IsOnWatchList = Table.WatchListEntries
                    .Where(e => e.Manufacturer == product.Manufacturer && e.Model == product.Model)
                    .Count() != 0 ? true : false;
                if (fuzzyViewModel.IsOnWatchList == false)
                {
                    // If either Manufacturer or Model is a match, the product is a fuzzy match
                    fuzzyViewModel.IsFuzzyMatch = Table.WatchListEntries
                        .Where(f => f.Manufacturer == product.Manufacturer || f.Model == product.Model)
                        .Count() != 0 ? true : false;
                }
                viewModelList.Add(fuzzyViewModel);
            }
            return Ok(viewModelList
                .OrderBy(w => w.Manufacturer)
                .ThenBy(x => x.Model)
                .ThenBy(y => y.Price)
                .ThenBy(z => z.Id)
                .ToList());
        }

        // GET ProductListApi/Get/5
        [HttpGet("Get/{id}")]
        public ActionResult Get(int id)
        {
            IList<FuzzyViewModel> viewModelList = new List<FuzzyViewModel>();
            foreach (var product in Table.Products)
            {
                FuzzyViewModel fuzzyViewModel = new FuzzyViewModel
                {
                    Id = product.Id,
                    Manufacturer = product.Manufacturer,
                    Model = product.Model,
                    NumberInStock = product.NumberInStock,
                    Price = product.Price,
                };
                fuzzyViewModel.IsOnWatchList = Table.WatchListEntries
                    .Where(e => e.Manufacturer == product.Manufacturer && e.Model == product.Model)
                    .Count() != 0 ? true : false;
                if (fuzzyViewModel.IsOnWatchList == false)
                {
                    // If either Manufacturer or Model is a match, fuzzy match is true
                    fuzzyViewModel.IsFuzzyMatch = Table.WatchListEntries
                        .Where(f => f.Manufacturer == product.Manufacturer || f.Model == product.Model)
                        .Count() != 0 ? true : false;
                }
                viewModelList.Add(fuzzyViewModel);
            }
            return Ok(viewModelList.FirstOrDefault(x => x.Id == id));

        }

        // POST ProductListApi/Post
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT ProductListApi/Put/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE ProductListApi/Delete/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            var x = Table.Products.Count;
            Console.WriteLine("===");
            Console.WriteLine(x);
            Table.Products.Remove(Table.Products.FirstOrDefault(x => x.Id == id));
            x = Table.Products.Count;
            Console.WriteLine("===");
            Console.WriteLine(x);
        }
    }
}