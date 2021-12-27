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
    public class ProductsController : Controller
    {
        private readonly DataManager dataManager;

        public ProductsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Products.GetProductById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeword("PageServices");
            return View(dataManager.Products.GetProducts());
        }
    }
}
