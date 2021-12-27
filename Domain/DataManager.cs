using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Repositories.Abstract;

namespace ShopWebApp.Domain
{
    // Контроллер для управления классами интерфейсами реализующими взаимодействие с БД
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }

        public IShopsRepository Shops { get; set; }
        public IProductsRepository Products { get; set; }

        public IProductShopRepository ProductShop { get; set; }

        public DataManager  (ITextFieldsRepository textFieldsRepository, 
                             IServiceItemsRepository serviceItemsRepository,
                             IShopsRepository shopsRepository,
                             IProductsRepository productsRepository,
                             IProductShopRepository productShopRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            Shops = shopsRepository;
            Products = productsRepository;
            ProductShop = productShopRepository;
        }
    }
}
