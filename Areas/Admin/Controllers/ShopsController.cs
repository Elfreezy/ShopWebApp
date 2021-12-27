using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain;
using ShopWebApp.Domain.Entities;
using ShopWebApp.Service;

namespace ShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;

        public ShopsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View(dataManager.Shops.GetShops());
        }

        public IActionResult Edit(Guid id)
        {
            var item = id == default ? new Shop() : dataManager.Shops.GetShopById(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Shop model, IFormFile titleImageFile)
        {
            if(ModelState.IsValid)
            {
                if(titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "img/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                else if(!(model.TitleImagePath != null))
                {
                    model.TitleImagePath = "zero.png";
                }
                dataManager.Shops.SaveShop(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Shops.DeleteShop(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult EditProducts(Guid id)
        {
            dataManager.Shops.GetShopById(id);
            return View();
        }
    }
}
