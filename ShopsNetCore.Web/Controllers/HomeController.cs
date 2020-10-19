using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopsNetCore.Data;
using ShopsNetCore.Web.Models;

namespace ShopsNetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IShopData _repository { get; }

        public HomeController(ILogger<HomeController> logger, IShopData repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string searchTerm)
        {
            HomeViewModel hvm = new HomeViewModel
            {
                Shops = _repository.GetShopsByName(searchTerm),
            };
            return View(hvm);
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
