using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Entities;
using ShopWebApp.Domain.Repositories.Abstract;

namespace ShopWebApp.Domain.Repositories.EntityFramework
{
    public class EFShopsRepository : IShopsRepository
    {
        private readonly AppDbContext context;
        public EFShopsRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public IQueryable<Shop> GetShops()
        {
            return context.Shops;
        }

        public Shop GetShopById(Guid id)
        {
            return context.Shops.FirstOrDefault(x => x.Id == id);
        }
        
        public void SaveShop(Shop entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteShop(Guid id)
        {
            context.Shops.Remove(new Shop() { Id = id });
            context.SaveChanges();
        }

        /*IQueryable<Product> GetProductsByShopId(Guid id)
        {
            return context.Shops.FirstOrDefault(x => x.Id == id).Products.AsQueryable();
        }*/

    }
}
