using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Domain.Entities
{
    public class ProductShop
    {
        [Column(Order = 1)]
        [Display(Name = "Товар")]
        public Guid ProductsId { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Магазин")]
        public Guid ShopsId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Количество товара")]
        public int Cnt { get; set; }
    }
}
