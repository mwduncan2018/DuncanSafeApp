using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuncanSafeApp2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DuncanSafeApp2024.DataStore;
using DuncanSafeApp2024.Models;

namespace DuncanSafeApp2024.Controllers
{
    public class WatchListController : Controller
    {
        // GET: WatchListController
        public ActionResult Index()
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            return View(Table.WatchListEntries.OrderBy(x => x.Manufacturer).ThenBy(y => y.Model).ThenBy(z => z.Id).ToList());
        }

        // GET: WatchListController/Details/5
        public ActionResult Details(int id)
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            var watchListEntry = Table.WatchListEntries.FirstOrDefault(x => x.Id == id);
            if (watchListEntry == null)
            {
                return RedirectToAction("Index", "CustomError");
            }
            else
            {
                return View(watchListEntry);
            }
        }

        // GET: WatchListController/Create
        public ActionResult Create()
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            return View();
        }

        // POST: WatchListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form)
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            try
            {
                Table.WatchListEntries.Add(new WatchListEntry(
                                                    Table.WatchListEntryCount,
                                                    form["Manufacturer"],
                                                    form["Model"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }

        // GET: WatchListController/Edit/5
        public ActionResult Edit(int id)
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            try
            {
                return View(Table.WatchListEntries.FirstOrDefault(x => x.Id == id));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }

        }

        // POST: WatchListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection form)
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            try
            {
                Table.WatchListEntries = Table.WatchListEntries.Where(x => x.Id != id).ToList();
                Table.WatchListEntries.Add(new WatchListEntry(
                                                    Table.WatchListEntryCount,
                                                    form["Manufacturer"],
                                                    form["Model"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }

        // GET: WatchListController/Delete/5
        public ActionResult Delete(int id)
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            return View(Table.WatchListEntries.FirstOrDefault(x => x.Id == id));
        }

        // POST: WatchListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            System.Threading.Thread.Sleep(new Random().Next(50, 125));
            try
            {
                Table.WatchListEntries = Table.WatchListEntries.Where(x => x.Id != id).ToList();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }
    }
}