using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdd = DateTime.UtcNow;
        [Required]
        public Guid Id { set; get; }

        [Display(Name = "Название (заголовок)")]
        public virtual string Title { set; get; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { set; get; }

        [Display(Name = "Описание")]
        public virtual string Text { set; get; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { set; get; }

        [DataType(DataType.Time)]
        public DateTime DateAdd { set; get; }
    }
}
