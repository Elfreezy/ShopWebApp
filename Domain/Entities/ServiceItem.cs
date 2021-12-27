using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название услуги")]
        [Display(Name = "Название услуги")]
        public override string Title { set; get; } = "Информационная страница";

        [Display(Name = "Краткое описание услуги")]
        public override string Subtitle { set; get; } = "Содержание заполняется администратором";

        [Display(Name = "Описание услуги")]
        public override string Text { set; get; } = "Содержание заполняется администратором";
    }
}
