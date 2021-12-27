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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductShopController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;

        public ProductShopController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.Shops = dataManager.Shops.GetShops();
            ViewBag.Products = dataManager.Products.GetProducts();
            return View(dataManager.ProductShop.GetProductShop());
        }
        public IActionResult Edit()
        {
            ViewBag.Shops = new SelectList(dataManager.Shops.GetShops().ToList<Shop>(), "Id", "Title");
            ViewBag.Products = new SelectList(dataManager.Products.GetProducts().ToList<Product>(), "Id", "Title");
            return View();
        }

        // Боже правый, зачем он поместил все в контроллер???
        [HttpPost]
        public IActionResult Edit(string shopId, string productId, int count)
        {
            Shop shop = dataManager.Shops.GetShopById(new Guid(shopId));
            Product product = dataManager.Products.GetProductById(new Guid(productId));

            if (product.Count >= count) {
                ProductShop productShop;

                if (dataManager.ProductShop.GetProductShopItemByIds(shop.Id, product.Id) != null)
                {
                    productShop = dataManager.ProductShop.GetProductShopItemByIds(shop.Id, product.Id);
                    product.Count = product.Count + productShop.Cnt;
                }
                else
                {
                    productShop = new ProductShop();

                    productShop.ShopsId = shop.Id;
                    productShop.ProductsId = product.Id;
                    shop.Products.Add(productShop);
                    product.Shops.Add(productShop);
                }
                productShop.Cnt = count;
                product.Count = product.Count - count;
                dataManager.Shops.SaveShop(shop);
                dataManager.Products.SaveProduct(product);
                dataManager.ProductShop.SaveProductShop(productShop);

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid shopId, Guid productId)
        {
            Shop shop = dataManager.Shops.GetShopById(shopId);
            Product product = dataManager.Products.GetProductById(productId);
            ProductShop productShop = dataManager.ProductShop.GetProductShopItemByIds(shop.Id, product.Id);

            product.Shops.Remove(productShop);
            shop.Products.Remove(productShop);

            dataManager.Shops.SaveShop(shop);
            dataManager.Products.SaveProduct(product);
            dataManager.ProductShop.DeleteProductShop(productShop);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

    }
}
