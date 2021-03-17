using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestRazorTemplating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestRazorTemplating.Controllers
{
    public class SpentController : Controller
    {
        // GET: SpentController
        public ActionResult Index()
        {
            List<Spent> spent = new List<Spent>
            {
                new Spent { spentName = "Pain", amount = 1 , date = DateTime.Now},
                new Spent { spentName = "Café", amount = 4.5, date = DateTime.Now},
                new Spent { spentName = "Gateaux", amount = 3.25, date = DateTime.Now }

            };
            return View(spent);
        }

        // GET: SpentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
