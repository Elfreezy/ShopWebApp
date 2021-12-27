using ShopWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Domain.Repositories.Abstract
{
    // Интерфейс класса для взаимодействие с БД
    // Реализация интерфейса в EntityFramework
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProductById(Guid id);
        void SaveProduct(Product entity);
        void DeleteProduct(Guid id);
    }
}
