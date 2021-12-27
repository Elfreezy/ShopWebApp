using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Entities;
using ShopWebApp.Domain.Repositories.Abstract;

namespace ShopWebApp.Domain.Repositories.EntityFramework
{
    public class EFProductShopRepository : IProductShopRepository
    {
        private readonly AppDbContext context;
        public EFProductShopRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<ProductShop> GetProductShop()
        {
            return context.ProductShop;
        }
        public IQueryable<Product> GetProductsByShop(Guid id) 
        {
            return context.Products.Where(x => x.Id == id);
        }
        public void SaveProductShop(ProductShop entity)
        {
            if (entity.ProductsId == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public ProductShop GetProductShopItemByIds(Guid ShopId, Guid ProductId)
        {
            var productShop = context.ProductShop.Where(x => x.ProductsId == ProductId);
            return productShop.FirstOrDefault(x => x.ShopsId == ShopId);
        }

        public void ModifyProductShop(ProductShop entity)
        {
            return;
        }

        public void DeleteProductShop(ProductShop entity)
        {
            context.ProductShop.Remove(entity);
            context.SaveChanges();
        }
    }
}
