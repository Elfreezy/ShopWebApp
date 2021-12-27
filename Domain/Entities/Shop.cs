using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApp.Domain.Entities;

namespace ShopWebApp.Domain.Entities
{
    public class Shop : EntityBase
    {
        public virtual ICollection<ProductShop> Products { get; set; }

        public Shop()
        {
            this.Products = new List<ProductShop>();
        }

        [Required(ErrorMessage = "Заполните название магазина")]
        [Display(Name = "Название магазина")]
        public override string Title { set; get; } = "Название магазина";

        [Display(Name = "Краткое описание магазина")]
        public override string Subtitle { set; get; } = "Краткое описание магазина";

        [Display(Name = "Описание магазина")]
        public override string Text { set; get; } = "Полное описание магазина";

        [Display(Name = "Телефон магазина")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { set; get; } = "Телефон магазина";
    }
}
