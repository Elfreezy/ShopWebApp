using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Entities;

namespace ShopWebApp.Domain.Entities
{
    public class Product : EntityBase
    {
        public virtual ICollection<ProductShop> Shops { get; set; }

        public Product()
        {
            this.Shops = new List<ProductShop>();
        }


        [Required(ErrorMessage = "Заполните название товара")]
        [Display(Name = "Название товара")]
        public override string Title { set; get; } = "Название товара";

        [Display(Name = "Краткое описание товара")]
        public override string Subtitle { set; get; } = "Краткое описание товара";

        [Display(Name = "Описание товара")]
        public override string Text { set; get; } = "Полное описание товара";

        [Display(Name = "Количество товара")]
        public int Count { set; get; } = 0;

        [Display(Name = "Количество товара на складе")]
        public int TotalCount { set; get; } = 1;

        [Display(Name = "Единица измерения")]
        public string UniteOfMeasure { set; get; } = "шт.";

        [Display(Name = "Вес товара, кг")]
        public double Weigth { set; get; } = 1.0;

        [Display(Name = "Цена товара")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float? Price { set; get; } = 1;
    }
}
