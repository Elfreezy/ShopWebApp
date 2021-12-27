using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Логин")]
        [Required]
        public string UserName { get; set; }

        [UIHint("password")]
        [Display(Name = "Пароль")]
        [Required]
        public string UserPassword { get; set; }

        [Display(Name = "Запомнить устройство")]
        public bool RememberMe { get; set; }
    }
}
