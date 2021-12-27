using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain;
using ShopWebApp.Service;
using ShopWebApp.Domain.Entities;

namespace ShopWebApp.Controllers
{
    public class ShopsController : Controller
    {
        private readonly DataManager dataManager;

        public ShopsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                var shop = dataManager.Shops.GetShopById(id);
                ViewBag.Products = dataManager.Products.GetProducts();
                return View("Show", shop);
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeword("PageServices");
            return View(dataManager.Shops.GetShops());
        }
    }
}
