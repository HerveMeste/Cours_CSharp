using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Razor_BonnePratique.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_BonnePratique.Controllers
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
            String conclusion = String.Empty;
            IEnumerable<Int32> Amount = new Int32[] { 1, 3, 4};
            Int32 sum = Amount.Sum();
            if (sum > 10)
            {
                conclusion = "You earn too much money";
            }
            else
            {
                conclusion = "You should ask for a salary raise";
            }
            return View("Index", conclusion);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
