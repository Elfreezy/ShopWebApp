using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Entities;
using ShopWebApp.Domain.Repositories.Abstract;

namespace ShopWebApp.Domain.Repositories.EntityFramework
{
    public class EFProductsRepository : IProductsRepository
    {
        private readonly AppDbContext context;
        public EFProductsRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public IQueryable<Product> GetProducts()
        {
            return context.Products;
        }
        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void SaveProduct(Product entity)
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

        public void DeleteProduct(Guid id)
        {
            context.Shops.Remove(new Shop() { Id = id });
            context.SaveChanges();
        }
    }
}
