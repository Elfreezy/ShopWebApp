using ShopWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Domain.Repositories.Abstract
{
    // Интерфейс класса для взаимодействие с БД
    // Реализация интерфейса в EntityFramework
    public interface IShopsRepository
    {
        IQueryable<Shop> GetShops();
        Shop GetShopById(Guid id);
        void SaveShop(Shop entity);
        void DeleteShop(Guid id);

        //IQueryable<Product> GetProductsByShopId(Guid id);
    }
}
