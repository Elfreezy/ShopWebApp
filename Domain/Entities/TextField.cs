using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { set; get; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { set; get; } = "Информационная страница";

        [Display(Name = "Содержание страницы")]
        public override string Text { set; get; } = "Содержание заполняется администратором";
    }
}
