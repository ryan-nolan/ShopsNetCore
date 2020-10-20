using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using ShopsNetCore.Core;
using ShopsNetCore.Data;
using ShopsNetCore.Web.Models;

namespace ShopsNetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHtmlHelper htmlHelper;

        public IShopRepository _repository { get; }

        public HomeController(ILogger<HomeController> logger, IShopRepository repository, IHtmlHelper htmlHelper)
        {
            _logger = logger;
            _repository = repository;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult Index(string searchTerm)
        {
            HomeViewModel hvm = new HomeViewModel
            {
                Shops = _repository.GetShopsByName(searchTerm)
            };
            return View(hvm);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Shop shop = _repository.GetById(id.Value);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }
        public IActionResult Create()
        {
            var vm = new CreateEditViewModel
            {
                ShopType = htmlHelper.GetEnumSelectList<ShopType>()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,AddressLineOne,AddressLineTwo,Postcode,ShopType,OpeningTime,ClosingTime")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(shop);
                _repository.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
