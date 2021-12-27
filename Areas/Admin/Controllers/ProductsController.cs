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
    public class ProductsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;

        public ProductsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View(dataManager.Products.GetProducts());
        }
        public IActionResult Edit(Guid id)
        {
            var item = id == default ? new Product() : dataManager.Products.GetProductById(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Product model, IFormFile titleImageFile)
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
                dataManager.Products.SaveProduct(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Products.DeleteProduct(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult AddToShop(string shopId)
        {
            dataManager.Products.GetProducts();

            if (shopId != null)
            {
                Response.Cookies.Append("ShopId", shopId);
                Response.Cookies.Append("ShopTitle", dataManager.Shops.GetShopById(new Guid(shopId)).Title);
            }

            return View();
        }
        /*
        [HttpPost]
        public IActionResult AddToShop(Guid id, int cnt)
        {
            if (ModelState.IsValid && Request.Cookies.ContainsKey("ShopId"))
            {
                var shop = dataManager.Shops.GetShopById(new Guid(Request.Cookies.ContainsKey("ShopId").ToString()));
                dataManager.Products.GetProductById(id).Shops.Add(shop);
                Response.Cookies.Append("ShopId", shopId);
                Response.Cookies.Append("ShopTitle", dataManager.Shops.GetShopById(new Guid(shopId)).Title);
            }

            return View();
        }
        */
    }
}
