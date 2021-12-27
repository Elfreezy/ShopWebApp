using ShopWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Domain.Repositories.Abstract
{
    // Интерфейс класса для взаимодействие с БД
    // Реализация интерфейса в EntityFramework
    public interface IProductShopRepository
    {
        public IQueryable<ProductShop> GetProductShop();
        public IQueryable<Product> GetProductsByShop(Guid id);
        void SaveProductShop(ProductShop entity);
        public ProductShop GetProductShopItemByIds(Guid ShopId, Guid ProductId);
        public void ModifyProductShop(ProductShop entity);
        void DeleteProductShop(ProductShop entity);
    }
}
