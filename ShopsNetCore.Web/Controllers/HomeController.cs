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
        private readonly IHtmlHelper _htmlHelper;
        private IShopRepository _repository { get; }

        public HomeController(ILogger<HomeController> logger, IShopRepository repository, IHtmlHelper htmlHelper)
        {
            _logger = logger;
            _repository = repository;
            _htmlHelper = htmlHelper;
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
                ShopType = _htmlHelper.GetEnumSelectList<ShopType>()
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
            return View(new CreateEditViewModel {Shop = shop});
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Shop shop = _repository.GetById(id.Value);
            if (shop == null)
            {
                return NotFound();
            }
            var vm = new CreateEditViewModel
            {
                ShopType = _htmlHelper.GetEnumSelectList<ShopType>(),
                Shop = shop
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Shop shop)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(shop);
                _repository.Commit();
                return RedirectToAction(nameof(Details), new  {id = shop.Id});
            }
            return View(new CreateEditViewModel { Shop = shop });
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Shop shop = _repository.GetById(id.Value);
            if (shop == null)
            {
                return NotFound();
            }
            return Delete(shop);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Shop shop)
        {
            _repository.Delete(shop.Id);
            _repository.Commit();
            return RedirectToAction(nameof(Index));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
